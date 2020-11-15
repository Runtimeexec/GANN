﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Utilities
{
    public static class BitStringUtils
    {
        public static BitArray BitArray(BitArray current, BitArray after)
        {
            var bools = new bool[current.Count + after.Count];
            current.CopyTo(bools, 0);
            after.CopyTo(bools, current.Count);
            return new BitArray(bools);
        }

        /// <summary>
        ///Use to convert every eight bits in a Bitarray to a Bitstring, 
        ///these will need to be converted to tinyints for the NN and storage in the db 
        ///and concatenated so that the Hammer Algorithm can be used
        /// </summary>
        /// <param name="bits">BitArry</param>
        /// <returns>BitString</returns>
        public static string ConvertShort2Bitstring(BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            //return bytes[0];

            byte decimalNumber = bytes[0]; ;
            string result = string.Empty;

            while (decimalNumber > 0)
            {

                int remainder = decimalNumber % 2;
                decimalNumber /= 2;
                result += remainder.ToString();

            }
            return result;
        }

        public static IList<Int16> Bytearray2Short(byte[] b)
        {
            Int16[] shrts = new Int16[b.Length];
            Buffer.BlockCopy(b, 0, shrts, 0, b.Length);

            return shrts;
        }

        public static string ShortListToString(IList<Int16> i)
        {
            string shrts = "";
            foreach (Int16 int16 in i)
            {
                shrts += int16.ToString();
            }
            return shrts;
        }

        public static BitArray ConvertBitstring2BitArray(string s)
        {
            var res = new BitArray(s.Select(c => c == '1').ToArray());
            return res;
        }

        public static string ConvertDecimal2Bitstring(byte decimalNumber)
        {
            byte remainder;
            string result = string.Empty;
            while (decimalNumber > 0)
            {
                remainder = (byte)(decimalNumber % 2);
                decimalNumber /= 2;
                result = remainder.ToString() + result;
            }
            return result;
        }

        public static string ConvertTinyintToBitString(short decimalNumber)
        {
            int remainder;
            string result = string.Empty;
            while (decimalNumber > 0)
            {
                remainder = decimalNumber % 2;
                decimalNumber /= 2;
                result = remainder.ToString() + result;
            }
            return result;
        }

        public static List<byte> BoolList2ByteList(List<bool> values)
        {

            List<byte> ret = new List<byte>();
            int count = 0;
            byte currentByte = 0;

            foreach (bool b in values)
            {

                if (b) currentByte |= (byte)(1 << count);
                count++;
                if (count == 7) { ret.Add(currentByte); currentByte = 0; count = 0; };

            }

            if (count < 7) ret.Add(currentByte);

            return ret;

        }

        public static byte[] ConvertBitstring2ByteArray(string str)
        {
            byte[] byt = new byte[1000];
            var enuble = SplitInParts(str, 8);

            for (int i = 0; i < enuble.Count(); i++)
            {
                short num = Convert.ToInt16(enuble.ElementAt(i), 2);
                byt[i] = (byte)num;
            }
            return byt;
        }

        public static short ConvertBitArray2Short(BitArray bits)
        {

            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }

            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            byte decimalNumber = bytes[0];

            return decimalNumber;
        }

        public static IEnumerable<string> SplitInParts(this string s, byte partLength)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", nameof(partLength));

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }
    }

    public static class InsertFileBytes
    {
        //public delegate void FileHandler(object sender, InsertFileArgs myArgs);
        //public event FileHandler OnLineHandler;

        public static string ExceptionMessage { get; set; }


        public static List<FilePaths> GetFilePathsAndBinaryIdx(List<FilePaths> filePaths)
        {
            using var cn = new SqlConnection() { ConnectionString = "Data Source = GANN; " + "Initial Catalog=gann;" + "User id=gann_user;" + "Password=[PASSWORD];" };
            const string statement = "SELECT idx, filename  FROM [gann].[dbo].[binary_data];";

            using var cmd = new SqlCommand() { Connection = cn, CommandText = statement };
            try
            {
                cn.Open();
                FilePaths filepath = null;
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        if (!reader.IsDBNull("filename"))
                        {
                            var idx = reader.GetInt64("idx");

                            // the blob column
                            var filename = reader.GetString("filename");
                            string replacement = Regex.Replace(filename, @"\t|\n|\r", "");

                            filepath = new FilePaths()
                            {
                                Idx = idx,
                                FilePath = replacement
                            };

                            if (filepath.FilePath != null)
                                filePaths.Add(filepath);
                        }

                    }

                }
                return filePaths;

            }

            catch (Exception ex)
            {
                ExceptionMessage = ex.Message;
                return null;
            }
        }


        /// <summary>
        /// Takes a list of files and inserts them into a table with a delegate
        /// which provides the caller information to see what's going on in real time.
        /// </summary>
        /// <param name="files">List of files including their path</param>
        /// <returns>Success or failure</returns>
        public static bool InsertFiles(List<FilePaths> filepaths)
        {
            /*
             * in line method to get a file byte array suitable for inserting
             * a new record into a table.
             */
            static byte[] GetFileBytes(string fileName)
            {
                byte[] fileByes;

                using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using var reader = new BinaryReader(stream);
                    fileByes = reader.ReadBytes((int)stream.Length);
                }

                return fileByes;
            }

            //const string statement1 = "INSERT INTO Table1 (FileContents,FileName)" + " VALUES (@FileContents,@FileName);" +  "SELECT CAST(scope_identity() AS int);";

            foreach (FilePaths path in filepaths)
            {

                var idx = path.Idx;
                var FullBytes = GetFileBytes(path.FilePath);

                string statement = string.Empty;
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO[dbo].[Bytes] ([binary_data_idx] ,[Byte1], [Byte2] ,[Byte3] ,[Byte4] ,[Byte5] ,[Byte6] ,[Byte7] ,[Byte8] ,[Byte9] ,[Byte10] ,[Byte11] ,[Byte12] ,[Byte13] ,[Byte14] ,[Byte15] ,[Byte16] ,[Byte17] ,[Byte18] ,[Byte19] ,[Byte20] ,[Byte21] ,[Byte22] ,[Byte23] ,[Byte24] ,[Byte25] ,[Byte26] ,[Byte27] ,[Byte28] ,[Byte29] ,[Byte30] ,[Byte31] ,[Byte32] ,[Byte33] ,[Byte34] ,[Byte35] ,[Byte36] ,[Byte37] ,[Byte38] ,[Byte39] ,[Byte40] ,[Byte41] ,[Byte42] ,[Byte43] ,[Byte44] ,[Byte45] ,[Byte46] ,[Byte47] ,[Byte48] ,[Byte49] ,[Byte50] ,[Byte51] ,[Byte52] ,[Byte53] ,[Byte54] ,[Byte55] ,[Byte56] ,[Byte57] ,[Byte58] ,[Byte59] ,[Byte60] ,[Byte61] ,[Byte62] ,[Byte63] ,[Byte64] ,[Byte65] ,[Byte66] ,[Byte67] ,[Byte68] ,[Byte69] ,[Byte70] ,[Byte71] ,[Byte72] ,[Byte73] ,[Byte74] ,[Byte75] ,[Byte76] ,[Byte77] ,[Byte78] ,[Byte79] ,[Byte80] ,[Byte81] ,[Byte82] ,[Byte83] ,[Byte84] ,[Byte85] ,[Byte86] ,[Byte87] ,[Byte88] ,[Byte89] ,[Byte90] ,[Byte91] ,[Byte92] ,[Byte93] ,[Byte94] ,[Byte95] ,[Byte96] ,[Byte97] ,[Byte98] ,[Byte99] ,[Byte100] ,[Byte101] ,[Byte102] ,[Byte103] ,[Byte104] ,[Byte105] ,[Byte106] ,[Byte107] ,[Byte108] ,[Byte109] ,[Byte110] ,[Byte111] ,[Byte112] ,[Byte113] ,[Byte114] ,[Byte115] ,[Byte116] ,[Byte117] ,[Byte118] ,[Byte119] ,[Byte120] ,[Byte121] ,[Byte122] ,[Byte123] ,[Byte124] ,[Byte125] ,[Byte126] ,[Byte127] ,[Byte128] ,[Byte129] ,[Byte130] ,[Byte131] ,[Byte132] ,[Byte133] ,[Byte134] ,[Byte135] ,[Byte136] ,[Byte137] ,[Byte138] ,[Byte139] ,[Byte140] ,[Byte141] ,[Byte142] ,[Byte143] ,[Byte144] ,[Byte145] ,[Byte146] ,[Byte147] ,[Byte148] ,[Byte149] ,[Byte150] ,[Byte151] ,[Byte152] ,[Byte153] ,[Byte154] ,[Byte155] ,[Byte156] ,[Byte157] ,[Byte158] ,[Byte159] ,[Byte160] ,[Byte161] ,[Byte162] ,[Byte163] ,[Byte164] ,[Byte165] ,[Byte166] ,[Byte167] ,[Byte168] ,[Byte169] ,[Byte170] ,[Byte171] ,[Byte172] ,[Byte173] ,[Byte174] ,[Byte175] ,[Byte176] ,[Byte177] ,[Byte178] ,[Byte179] ,[Byte180] ,[Byte181] ,[Byte182] ,[Byte183] ,[Byte184] ,[Byte185] ,[Byte186] ,[Byte187] ,[Byte188] ,[Byte189] ,[Byte190] ,[Byte191] ,[Byte192] ,[Byte193] ,[Byte194] ,[Byte195] ,[Byte196] ,[Byte197] ,[Byte198] ,[Byte199] ,[Byte200] ,[Byte201] ,[Byte202] ,[Byte203] ,[Byte204] ,[Byte205] ,[Byte206] ,[Byte207] ,[Byte208] ,[Byte209] ,[Byte210] ,[Byte211] ,[Byte212] ,[Byte213] ,[Byte214] ,[Byte215] ,[Byte216] ,[Byte217] ,[Byte218] ,[Byte219] ,[Byte220] ,[Byte221] ,[Byte222] ,[Byte223] ,[Byte224] ,[Byte225] ,[Byte226] ,[Byte227] ,[Byte228] ,[Byte229] ,[Byte230] ,[Byte231] ,[Byte232] ,[Byte233] ,[Byte234] ,[Byte235] ,[Byte236] ,[Byte237] ,[Byte238] ,[Byte239] ,[Byte240] ,[Byte241] ,[Byte242] ,[Byte243] ,[Byte244] ,[Byte245] ,[Byte246] ,[Byte247] ,[Byte248] ,[Byte249] ,[Byte250] ,[Byte251] ,[Byte252] ,[Byte253] ,[Byte254] ,[Byte255] ,[Byte256] ,[Byte257] ,[Byte258] ,[Byte259] ,[Byte260] ,[Byte261] ,[Byte262] ,[Byte263] ,[Byte264] ,[Byte265] ,[Byte266] ,[Byte267] ,[Byte268] ,[Byte269] ,[Byte270] ,[Byte271] ,[Byte272] ,[Byte273] ,[Byte274] ,[Byte275] ,[Byte276] ,[Byte277] ,[Byte278] ,[Byte279] ,[Byte280] ,[Byte281] ,[Byte282] ,[Byte283] ,[Byte284] ,[Byte285] ,[Byte286] ,[Byte287] ,[Byte288] ,[Byte289] ,[Byte290] ,[Byte291] ,[Byte292] ,[Byte293] ,[Byte294] ,[Byte295] ,[Byte296] ,[Byte297] ,[Byte298] ,[Byte299] ,[Byte300] ,[Byte301] ,[Byte302] ,[Byte303] ,[Byte304] ,[Byte305] ,[Byte306] ,[Byte307] ,[Byte308] ,[Byte309] ,[Byte310] ,[Byte311] ,[Byte312] ,[Byte313] ,[Byte314] ,[Byte315] ,[Byte316] ,[Byte317] ,[Byte318] ,[Byte319] ,[Byte320] ,[Byte321] ,[Byte322] ,[Byte323] ,[Byte324] ,[Byte325] ,[Byte326] ,[Byte327] ,[Byte328] ,[Byte329] ,[Byte330] ,[Byte331] ,[Byte332] ,[Byte333] ,[Byte334] ,[Byte335] ,[Byte336] ,[Byte337] ,[Byte338] ,[Byte339] ,[Byte340] ,[Byte341] ,[Byte342] ,[Byte343] ,[Byte344] ,[Byte345] ,[Byte346] ,[Byte347] ,[Byte348] ,[Byte349] ,[Byte350] ,[Byte351] ,[Byte352] ,[Byte353] ,[Byte354] ,[Byte355] ,[Byte356] ,[Byte357] ,[Byte358] ,[Byte359] ,[Byte360] ,[Byte361] ,[Byte362] ,[Byte363] ,[Byte364] ,[Byte365] ,[Byte366] ,[Byte367] ,[Byte368] ,[Byte369] ,[Byte370] ,[Byte371] ,[Byte372] ,[Byte373] ,[Byte374] ,[Byte375] ,[Byte376] ,[Byte377] ,[Byte378] ,[Byte379] ,[Byte380] ,[Byte381] ,[Byte382] ,[Byte383] ,[Byte384] ,[Byte385] ,[Byte386] ,[Byte387] ,[Byte388] ,[Byte389] ,[Byte390] ,[Byte391] ,[Byte392] ,[Byte393] ,[Byte394] ,[Byte395] ,[Byte396] ,[Byte397] ,[Byte398] ,[Byte399] ,[Byte400] ,[Byte401] ,[Byte402] ,[Byte403] ,[Byte404] ,[Byte405] ,[Byte406] ,[Byte407] ,[Byte408] ,[Byte409] ,[Byte410] ,[Byte411] ,[Byte412] ,[Byte413] ,[Byte414] ,[Byte415] ,[Byte416] ,[Byte417] ,[Byte418] ,[Byte419] ,[Byte420] ,[Byte421] ,[Byte422] ,[Byte423] ,[Byte424] ,[Byte425] ,[Byte426] ,[Byte427] ,[Byte428] ,[Byte429] ,[Byte430] ,[Byte431] ,[Byte432] ,[Byte433] ,[Byte434] ,[Byte435] ,[Byte436] ,[Byte437] ,[Byte438] ,[Byte439] ,[Byte440] ,[Byte441] ,[Byte442] ,[Byte443] ,[Byte444] ,[Byte445] ,[Byte446] ,[Byte447] ,[Byte448] ,[Byte449] ,[Byte450] ,[Byte451] ,[Byte452] ,[Byte453] ,[Byte454] ,[Byte455] ,[Byte456] ,[Byte457] ,[Byte458] ,[Byte459] ,[Byte460] ,[Byte461] ,[Byte462] ,[Byte463] ,[Byte464] ,[Byte465] ,[Byte466] ,[Byte467] ,[Byte468] ,[Byte469] ,[Byte470] ,[Byte471] ,[Byte472] ,[Byte473] ,[Byte474] ,[Byte475] ,[Byte476] ,[Byte477] ,[Byte478] ,[Byte479] ,[Byte480] ,[Byte481] ,[Byte482] ,[Byte483] ,[Byte484] ,[Byte485] ,[Byte486] ,[Byte487] ,[Byte488] ,[Byte489] ,[Byte490] ,[Byte491] ,[Byte492] ,[Byte493] ,[Byte494] ,[Byte495] ,[Byte496] ,[Byte497] ,[Byte498] ,[Byte499] ,[Byte500] ,[Byte501] ,[Byte502] ,[Byte503] ,[Byte504] ,[Byte505] ,[Byte506] ,[Byte507] ,[Byte508] ,[Byte509] ,[Byte510] ,[Byte511] ,[Byte512] ,[Byte513] ,[Byte514] ,[Byte515] ,[Byte516] ,[Byte517] ,[Byte518] ,[Byte519] ,[Byte520] ,[Byte521] ,[Byte522] ,[Byte523] ,[Byte524] ,[Byte525] ,[Byte526] ,[Byte527] ,[Byte528] ,[Byte529] ,[Byte530] ,[Byte531] ,[Byte532] ,[Byte533] ,[Byte534] ,[Byte535] ,[Byte536] ,[Byte537] ,[Byte538] ,[Byte539] ,[Byte540] ,[Byte541] ,[Byte542] ,[Byte543] ,[Byte544] ,[Byte545] ,[Byte546] ,[Byte547] ,[Byte548] ,[Byte549] ,[Byte550] ,[Byte551] ,[Byte552] ,[Byte553] ,[Byte554] ,[Byte555] ,[Byte556] ,[Byte557] ,[Byte558] ,[Byte559] ,[Byte560] ,[Byte561] ,[Byte562] ,[Byte563] ,[Byte564] ,[Byte565] ,[Byte566] ,[Byte567] ,[Byte568] ,[Byte569] ,[Byte570] ,[Byte571] ,[Byte572] ,[Byte573] ,[Byte574] ,[Byte575] ,[Byte576] ,[Byte577] ,[Byte578] ,[Byte579] ,[Byte580] ,[Byte581] ,[Byte582] ,[Byte583] ,[Byte584] ,[Byte585] ,[Byte586] ,[Byte587] ,[Byte588] ,[Byte589] ,[Byte590] ,[Byte591] ,[Byte592] ,[Byte593] ,[Byte594] ,[Byte595] ,[Byte596] ,[Byte597] ,[Byte598] ,[Byte599] ,[Byte600] ,[Byte601] ,[Byte602] ,[Byte603] ,[Byte604] ,[Byte605] ,[Byte606] ,[Byte607] ,[Byte608] ,[Byte609] ,[Byte610] ,[Byte611] ,[Byte612] ,[Byte613] ,[Byte614] ,[Byte615] ,[Byte616] ,[Byte617] ,[Byte618] ,[Byte619] ,[Byte620] ,[Byte621] ,[Byte622] ,[Byte623] ,[Byte624] ,[Byte625] ,[Byte626] ,[Byte627] ,[Byte628] ,[Byte629] ,[Byte630] ,[Byte631] ,[Byte632] ,[Byte633] ,[Byte634] ,[Byte635] ,[Byte636] ,[Byte637] ,[Byte638] ,[Byte639] ,[Byte640] ,[Byte641] ,[Byte642] ,[Byte643] ,[Byte644] ,[Byte645] ,[Byte646] ,[Byte647] ,[Byte648] ,[Byte649] ,[Byte650] ,[Byte651] ,[Byte652] ,[Byte653] ,[Byte654] ,[Byte655] ,[Byte656] ,[Byte657] ,[Byte658] ,[Byte659] ,[Byte660] ,[Byte661] ,[Byte662] ,[Byte663] ,[Byte664] ,[Byte665] ,[Byte666] ,[Byte667] ,[Byte668] ,[Byte669] ,[Byte670] ,[Byte671] ,[Byte672] ,[Byte673] ,[Byte674] ,[Byte675] ,[Byte676] ,[Byte677] ,[Byte678] ,[Byte679] ,[Byte680] ,[Byte681] ,[Byte682] ,[Byte683] ,[Byte684] ,[Byte685] ,[Byte686] ,[Byte687] ,[Byte688] ,[Byte689] ,[Byte690] ,[Byte691] ,[Byte692] ,[Byte693] ,[Byte694] ,[Byte695] ,[Byte696] ,[Byte697] ,[Byte698] ,[Byte699] ,[Byte700] ,[Byte701] ,[Byte702] ,[Byte703] ,[Byte704] ,[Byte705] ,[Byte706] ,[Byte707] ,[Byte708] ,[Byte709] ,[Byte710] ,[Byte711] ,[Byte712] ,[Byte713] ,[Byte714] ,[Byte715] ,[Byte716] ,[Byte717] ,[Byte718] ,[Byte719] ,[Byte720] ,[Byte721] ,[Byte722] ,[Byte723] ,[Byte724] ,[Byte725] ,[Byte726] ,[Byte727] ,[Byte728] ,[Byte729] ,[Byte730] ,[Byte731] ,[Byte732] ,[Byte733] ,[Byte734] ,[Byte735] ,[Byte736] ,[Byte737] ,[Byte738] ,[Byte739] ,[Byte740] ,[Byte741] ,[Byte742] ,[Byte743] ,[Byte744] ,[Byte745] ,[Byte746] ,[Byte747] ,[Byte748] ,[Byte749] ,[Byte750] ,[Byte751] ,[Byte752] ,[Byte753] ,[Byte754] ,[Byte755] ,[Byte756] ,[Byte757] ,[Byte758] ,[Byte759] ,[Byte760] ,[Byte761] ,[Byte762] ,[Byte763] ,[Byte764] ,[Byte765] ,[Byte766] ,[Byte767] ,[Byte768] ,[Byte769] ,[Byte770] ,[Byte771] ,[Byte772] ,[Byte773] ,[Byte774] ,[Byte775] ,[Byte776] ,[Byte777] ,[Byte778] ,[Byte779] ,[Byte780] ,[Byte781] ,[Byte782] ,[Byte783] ,[Byte784] ,[Byte785] ,[Byte786] ,[Byte787] ,[Byte788] ,[Byte789] ,[Byte790] ,[Byte791] ,[Byte792] ,[Byte793] ,[Byte794] ,[Byte795] ,[Byte796] ,[Byte797] ,[Byte798] ,[Byte799] ,[Byte800] ,[Byte801] ,[Byte802] ,[Byte803] ,[Byte804] ,[Byte805] ,[Byte806] ,[Byte807] ,[Byte808] ,[Byte809] ,[Byte810] ,[Byte811] ,[Byte812] ,[Byte813] ,[Byte814] ,[Byte815] ,[Byte816] ,[Byte817] ,[Byte818] ,[Byte819] ,[Byte820] ,[Byte821] ,[Byte822] ,[Byte823] ,[Byte824] ,[Byte825] ,[Byte826] ,[Byte827] ,[Byte828] ,[Byte829] ,[Byte830] ,[Byte831] ,[Byte832] ,[Byte833] ,[Byte834] ,[Byte835] ,[Byte836] ,[Byte837] ,[Byte838] ,[Byte839] ,[Byte840] ,[Byte841] ,[Byte842] ,[Byte843] ,[Byte844] ,[Byte845] ,[Byte846] ,[Byte847] ,[Byte848] ,[Byte849] ,[Byte850] ,[Byte851] ,[Byte852] ,[Byte853] ,[Byte854] ,[Byte855] ,[Byte856] ,[Byte857] ,[Byte858] ,[Byte859] ,[Byte860] ,[Byte861] ,[Byte862] ,[Byte863] ,[Byte864] ,[Byte865] ,[Byte866] ,[Byte867] ,[Byte868] ,[Byte869] ,[Byte870] ,[Byte871] ,[Byte872] ,[Byte873] ,[Byte874] ,[Byte875] ,[Byte876] ,[Byte877] ,[Byte878] ,[Byte879] ,[Byte880] ,[Byte881] ,[Byte882] ,[Byte883] ,[Byte884] ,[Byte885] ,[Byte886] ,[Byte887] ,[Byte888] ,[Byte889] ,[Byte890] ,[Byte891] ,[Byte892] ,[Byte893] ,[Byte894] ,[Byte895] ,[Byte896] ,[Byte897] ,[Byte898] ,[Byte899] ,[Byte900] ,[Byte901] ,[Byte902] ,[Byte903] ,[Byte904] ,[Byte905] ,[Byte906] ,[Byte907] ,[Byte908] ,[Byte909] ,[Byte910] ,[Byte911] ,[Byte912] ,[Byte913] ,[Byte914] ,[Byte915] ,[Byte916] ,[Byte917] ,[Byte918] ,[Byte919] ,[Byte920] ,[Byte921] ,[Byte922] ,[Byte923] ,[Byte924] ,[Byte925] ,[Byte926] ,[Byte927] ,[Byte928] ,[Byte929] ,[Byte930] ,[Byte931] ,[Byte932] ,[Byte933] ,[Byte934] ,[Byte935] ,[Byte936] ,[Byte937] ,[Byte938] ,[Byte939] ,[Byte940] ,[Byte941] ,[Byte942] ,[Byte943] ,[Byte944] ,[Byte945] ,[Byte946] ,[Byte947] ,[Byte948] ,[Byte949] ,[Byte950] ,[Byte951] ,[Byte952] ,[Byte953] ,[Byte954] ,[Byte955] ,[Byte956] ,[Byte957] ,[Byte958] ,[Byte959] ,[Byte960] ,[Byte961] ,[Byte962] ,[Byte963] ,[Byte964] ,[Byte965] ,[Byte966] ,[Byte967] ,[Byte968] ,[Byte969] ,[Byte970] ,[Byte971] ,[Byte972] ,[Byte973] ,[Byte974] ,[Byte975] ,[Byte976] ,[Byte977] ,[Byte978] ,[Byte979] ,[Byte980] ,[Byte981] ,[Byte982] ,[Byte983] ,[Byte984] ,[Byte985] ,[Byte986] ,[Byte987] ,[Byte988] ,[Byte989] ,[Byte990] ,[Byte991] ,[Byte992] ,[Byte993] ,[Byte994] ,[Byte995] ,[Byte996] ,[Byte997] ,[Byte998] ,[Byte999] ,[Byte1000])");
                sb.Append("VALUES");
                sb.Append("(");

                sb.Append(idx);

                var length = FullBytes.Length;

                int i;
                for (i = 0; i < 1000; i++)
                {
                    if (i < 1000 && length >= 1000)
                    {
                        var bte = FullBytes[i];
                        sb.Append(",");
                        sb.Append(bte);
                    }
                    else if (i < 1000 && length < 1000)
                    {
                        if (i >= length)
                        {
                            sb.Append(",");
                            sb.Append(0x00);
                        }
                        else
                        {
                            var bte = FullBytes[i];
                            sb.Append(",");
                            sb.Append(bte);
                        }

                    }
                    else
                    {
                        break;
                    }


                }

                sb.Append(")");

                statement = sb.ToString();

                using var cn = new SqlConnection() { ConnectionString = "Data Source = GANN; " + "Initial Catalog=gann;" + "User id=gann_user;" + "Password=[PASSWORD];" };
                using var cmd = new SqlCommand() { Connection = cn, CommandText = statement };
                cn.Open();
                Convert.ToInt32(cmd.ExecuteScalar()).ToString();
            }

            return true;

        }

        public class FilePaths
        {
            private long _idx;
            private string _filePath;

            public long Idx
            {
                get { return _idx; }
                set { _idx = value; }
            }

            public string FilePath
            {
                get { return _filePath; }
                set { _filePath = value; }
            }

        }
    }
    public class DatabaseUtils
    {
        public int InsertFloatsIntoEvolvedTinyInts(string filename, float[] fltarray)
        {
            string connectionString = "Server=GANN;Database=gann;User Id=gann_user;Password=[PASSWORD];";
            int modified;
            int EvolvedTinyIntsID = 0;

            //example filename:
            //0000000001_4208_6_6814d7af-0394-40de-9149-96470bd702d5.txt
            //[Generation]_[Hamming Fitness]_[Target File Database ID]_[Thread GUID For Evolution To Target File]

            filename = Path.GetFileName(filename);
            var arr = filename.Split('_');
            var str_Generation = arr[0];
            var str_Fitness = arr[1];
            var str_ID = arr[2];

            var str_FileNumber = str_Generation + str_Fitness + str_ID;
            var FileNumber = Convert.ToInt64(str_FileNumber);
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO [gann].[dbo].[EvolvedTinyInts] ([Filename], [FileNumber]");
            for (int i = 1; i <= fltarray.Length; i++)
            {
                sb.Append(",[Tinyint" + i + "]");
            }

            sb.Append(") VALUES (");
            sb.Append("'" + filename + "'," + FileNumber);

            for (int i = 0; i < fltarray.Length; i++)
            {
                sb.Append("," + (byte)fltarray[i]);
            }

            sb.Append(")");

            string insertStatement = sb.ToString();
            string selectStatement = "SELECT TOP(1) ID FROM [gann].[dbo].[EvolvedTinyInts] GROUP BY ID, Timestamp ORDER BY Timestamp DESC";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using SqlCommand command = new SqlCommand(insertStatement, connection);
                modified = command.ExecuteNonQuery();

                using SqlCommand command2 = new SqlCommand(selectStatement, connection);
                var reader = command2.ExecuteReader();

                while (reader.Read())
                {
                    var record = (IDataRecord)reader;
                    EvolvedTinyIntsID = (int)record[0];
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return EvolvedTinyIntsID;
        }

        public int InsertOrUpdateEvolvedFilesMetaCNTK(int ID_EvolvedTinyIntsFK, string filename, float CNTK_Probability)
        {
            string connectionString = "Server=GANN;Database=gann;User Id=gann_user;Password=[PASSWORD];";
            int modified = 0;

            filename = Path.GetFileName(filename);
            var arr = filename.Split('_');
            var str_Generation = arr[0];
            var str_Fitness = arr[1];
            var str_ID = arr[2];
            var str_guidAndExt = arr[3];
            var str_guid = str_guidAndExt.Substring(0, arr[3].IndexOf('.'));
            Guid FileSessionGUID = new Guid(str_guid);

            var str_FileNumber = str_Generation + str_Fitness + str_ID;
            var FileNumber = Convert.ToInt64(str_FileNumber);

            string statement = "SELECT * FROM [gann].[dbo].[EvolvedFilesMeta] WHERE [ID_EvolvedTinyInts] =" + ID_EvolvedTinyIntsFK;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using SqlCommand command = new SqlCommand(statement, connection);
                connection.Open();
                var count = command.ExecuteNonQuery();

                if (count > 0)
                {
                    //Update Statements
                    if (CNTK_Probability > float.MinValue)
                    {
                        string updateStatement = "UPDATE [gann].[dbo].[EvolvedFilesMeta] SET [ID_EvolvedTinyInts] =" + ID_EvolvedTinyIntsFK + " ,[Filename] ='" + filename + "' ,[FileNumber] =" + FileNumber + " ,[FileSessionGUID] ='" + FileSessionGUID + "' ,[CNTK_Probability] =" + CNTK_Probability + "  WHERE [ID_EvolvedTinyInts] =" + ID_EvolvedTinyIntsFK;
                        using SqlCommand cmd = new SqlCommand(updateStatement, connection);
                        modified = cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    //Insert Statement
                    string insertStatement = "INSERT INTO [gann].[dbo].[EvolvedFilesMeta] ([ID_EvolvedTinyInts] ,[Filename] ,[FileNumber] ,[FileSessionGUID] ,[CNTK_Probability]) VALUES(" + ID_EvolvedTinyIntsFK + " ,'" + filename + "' ," + FileNumber + " ,'" + FileSessionGUID + "' ," + CNTK_Probability + ")";
                    using SqlCommand cmd = new SqlCommand(insertStatement, connection);
                    modified = cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return modified;
        }

        public int InsertOrUpdateEvolvedFilesMetaTF(int ID_EvolvedTinyIntsFK, string filename, float TF_Probability)
        {
            string connectionString = "Server=GANN;Database=gann;User Id=gann_user;Password=[PASSWORD];";
            int modified = 0;

            filename = Path.GetFileName(filename);
            var arr = filename.Split('_');
            var str_Generation = arr[0];
            var str_Fitness = arr[1];
            var str_ID = arr[2];
            var str_guidAndExt = arr[3];
            var str_guid = str_guidAndExt.Substring(0, arr[3].IndexOf('.'));
            Guid FileSessionGUID = new Guid(str_guid);

            var str_FileNumber = str_Generation + str_Fitness + str_ID;
            var FileNumber = Convert.ToInt64(str_FileNumber);

            string statement = "SELECT COUNT(*) FROM [gann].[dbo].[EvolvedFilesMeta] WHERE [ID_EvolvedTinyInts] =" + ID_EvolvedTinyIntsFK;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using SqlCommand command = new SqlCommand(statement, connection);
                connection.Open();

                var reader = command.ExecuteReader();
                int count = 0;

                while (reader.Read())
                {
                    var record = (IDataRecord)reader;
                    count = (int)record[0];
                }
                reader.Close();

                if (count > 0)
                {
                    if (TF_Probability > float.MinValue)
                    {
                        string updateStatement = "UPDATE [gann].[dbo].[EvolvedFilesMeta] SET [ID_EvolvedTinyInts] =" + ID_EvolvedTinyIntsFK + " ,[Filename] ='" + filename + "' ,[FileNumber] =" + FileNumber + " ,[FileSessionGUID] ='" + FileSessionGUID + "',[TF_Probability] =" + TF_Probability + "  WHERE [ID_EvolvedTinyInts] =" + ID_EvolvedTinyIntsFK;
                        using SqlCommand cmd = new SqlCommand(updateStatement, connection);
                        modified = cmd.ExecuteNonQuery();
                    }

                }
                else
                {
                    //Insert Statement
                    string insertStatement = "INSERT INTO [gann].[dbo].[EvolvedFilesMeta] ([ID_EvolvedTinyInts] ,[Filename] ,[FileNumber] ,[FileSessionGUID] ,[TF_Probability]) VALUES(" + ID_EvolvedTinyIntsFK + " ,'" + filename + "' ," + FileNumber + " ,'" + FileSessionGUID + "' ," + TF_Probability + ")";
                    using SqlCommand cmd = new SqlCommand(insertStatement, connection);
                    modified = cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return modified;
        }
    }
}
