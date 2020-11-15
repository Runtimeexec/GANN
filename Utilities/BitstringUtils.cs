using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Utilities
{
    public static class BitstringUtils
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
    }
}

public class DatabaseUtils
{
    public int InsertFloatsIntoEvolvedTinyInts(string filename, float[] fltarray)
    {
        string connectionString = "Server=GANN;Database=gann;User Id=gann_user;Password=[PASSWORD];";
        int modified = 0;

        //example filename:
        //0000000001_4208_6_6814d7af-0394-40de-9149-96470bd702d5.txt
        //[Generation]_[Hamming Fitness]_[Target File Database ID]_[Thread GUID For Evolution To Target File]

        var arr = filename.Split('_');
        var str_Generation = arr[0];
        var str_Fitness = arr[1];
        var str_ID = arr[2];
        //var str_guidAndExt = arr[3];
        //var str_guid = str_guidAndExt.Substring(0, arr[3].IndexOf('.'));

        var str_FileNumber = str_Generation + str_Fitness + str_ID;
        var FileNumber = Convert.ToInt32(str_FileNumber);
        StringBuilder sb = new StringBuilder();

        sb.Append("INSERT INTO [gann].[dbo].[EvolvedTinyInts] ([Filename], [FileNumber]");
        for (int i = 1; i <= fltarray.Length; i++)
        {
            sb.Append(",[Tinyint" + i + "]");
        }

        sb.Append(") VALUES(");
        sb.Append(filename + " ," + FileNumber);

        for (int i = 1; i <= fltarray.Length; i++)
        {
            sb.Append("," + fltarray[i]);
        }

        sb.Append(")");

        string statement = sb.ToString();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {

            using SqlCommand command = new SqlCommand(statement, connection);
            connection.Open();
            modified = (int)command.ExecuteScalar();

            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        return modified;
    }

    public int InsertOrUpdateEvolvedFilesMeta(int ID_EvolvedTinyIntsFK, string filename, float CNTK_Probability, float TF_Probability)
    {
        string connectionString = "Server=GANN;Database=gann;User Id=gann_user;Password=[PASSWORD];";
        int modified = 0;

        var arr = filename.Split('_');
        var str_Generation = arr[0];
        var str_Fitness = arr[1];
        var str_ID = arr[2];
        var str_guidAndExt = arr[3];
        var str_guid = str_guidAndExt.Substring(0, arr[3].IndexOf('.'));
        Guid FileSessionGUID = new Guid(str_guid);

        var str_FileNumber = str_Generation + str_Fitness + str_ID;
        var FileNumber = Convert.ToInt32(str_FileNumber);

        string statement = "SELECT * FROM [gann].[dbo].[EvolvedFilesMeta] WHERE [ID_EvolvedTinyInts] =" + ID_EvolvedTinyIntsFK;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {

            using SqlCommand command = new SqlCommand(statement, connection);
            connection.Open();
            var count = command.ExecuteNonQuery();

            if (count > 0)
            {
                //Update Statement
                if (CNTK_Probability > float.Epsilon)
                {
                    string updateStatement = "UPDATE [gann].[dbo].[EvolvedFilesMeta] SET [ID_EvolvedTinyInts] =" + ID_EvolvedTinyIntsFK + " ,[Filename] =" + filename + " ,[FileNumber] =" + FileNumber + " ,[FileSessionGUID] =" + FileSessionGUID + ",[TF_Probability] =" + TF_Probability + " ,[CNTK_Probability] =" + CNTK_Probability + "  WHERE [ID_EvolvedTinyInts] =" + ID_EvolvedTinyIntsFK;
                    modified = command.ExecuteNonQuery();
                }
                else if (TF_Probability > float.Epsilon)
                {

                    string updateStatement = "UPDATE [gann].[dbo].[EvolvedFilesMeta] SET [ID_EvolvedTinyInts] =" + ID_EvolvedTinyIntsFK + " ,[Filename] =" + filename + " ,[FileNumber] =" + FileNumber + " ,[FileSessionGUID] =" + FileSessionGUID + ",[TF_Probability] =" + TF_Probability + " ,[CNTK_Probability] =" + CNTK_Probability + "  WHERE [ID_EvolvedTinyInts] =" + ID_EvolvedTinyIntsFK;
                    modified = command.ExecuteNonQuery();

                }

            }
            else
            {
                //Insert Statement
                string updateStatement = "INSERT INTO [gann].[dbo].[EvolvedFilesMeta] ([ID_EvolvedTinyInts] ,[Filename] ,[FileNumber] ,[FileSessionGUID] ,[TF_Probability] ,[CNTK_Probability]) VALUES(" + ID_EvolvedTinyIntsFK + " ," + filename + " ," + FileNumber + " ," + FileSessionGUID + " ," + TF_Probability + " ," + CNTK_Probability + ")";
                modified = command.ExecuteNonQuery();
            }

            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        return modified;
    }
}
