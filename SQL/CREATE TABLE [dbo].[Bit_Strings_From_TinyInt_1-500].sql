USE [gann]
GO

/****** Object:  Table [dbo].[Bit_Strings_From_TinyInt]    Script Date: 14/07/2020 22:16:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bit_Strings_From_TinyInt_1-500](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[idx_TinyInt] [int] NOT NULL,
	[BitString1] [varchar](8) NULL,
	[BitString2] [varchar](8) NULL,
	[BitString3] [varchar](8) NULL,
	[BitString4] [varchar](8) NULL,
	[BitString5] [varchar](8) NULL,
	[BitString6] [varchar](8) NULL,
	[BitString7] [varchar](8) NULL,
	[BitString8] [varchar](8) NULL,
	[BitString9] [varchar](8) NULL,
	[BitString10] [varchar](8) NULL,
	[BitString11] [varchar](8) NULL,
	[BitString12] [varchar](8) NULL,
	[BitString13] [varchar](8) NULL,
	[BitString14] [varchar](8) NULL,
	[BitString15] [varchar](8) NULL,
	[BitString16] [varchar](8) NULL,
	[BitString17] [varchar](8) NULL,
	[BitString18] [varchar](8) NULL,
	[BitString19] [varchar](8) NULL,
	[BitString20] [varchar](8) NULL,
	[BitString21] [varchar](8) NULL,
	[BitString22] [varchar](8) NULL,
	[BitString23] [varchar](8) NULL,
	[BitString24] [varchar](8) NULL,
	[BitString25] [varchar](8) NULL,
	[BitString26] [varchar](8) NULL,
	[BitString27] [varchar](8) NULL,
	[BitString28] [varchar](8) NULL,
	[BitString29] [varchar](8) NULL,
	[BitString30] [varchar](8) NULL,
	[BitString31] [varchar](8) NULL,
	[BitString32] [varchar](8) NULL,
	[BitString33] [varchar](8) NULL,
	[BitString34] [varchar](8) NULL,
	[BitString35] [varchar](8) NULL,
	[BitString36] [varchar](8) NULL,
	[BitString37] [varchar](8) NULL,
	[BitString38] [varchar](8) NULL,
	[BitString39] [varchar](8) NULL,
	[BitString40] [varchar](8) NULL,
	[BitString41] [varchar](8) NULL,
	[BitString42] [varchar](8) NULL,
	[BitString43] [varchar](8) NULL,
	[BitString44] [varchar](8) NULL,
	[BitString45] [varchar](8) NULL,
	[BitString46] [varchar](8) NULL,
	[BitString47] [varchar](8) NULL,
	[BitString48] [varchar](8) NULL,
	[BitString49] [varchar](8) NULL,
	[BitString50] [varchar](8) NULL,
	[BitString51] [varchar](8) NULL,
	[BitString52] [varchar](8) NULL,
	[BitString53] [varchar](8) NULL,
	[BitString54] [varchar](8) NULL,
	[BitString55] [varchar](8) NULL,
	[BitString56] [varchar](8) NULL,
	[BitString57] [varchar](8) NULL,
	[BitString58] [varchar](8) NULL,
	[BitString59] [varchar](8) NULL,
	[BitString60] [varchar](8) NULL,
	[BitString61] [varchar](8) NULL,
	[BitString62] [varchar](8) NULL,
	[BitString63] [varchar](8) NULL,
	[BitString64] [varchar](8) NULL,
	[BitString65] [varchar](8) NULL,
	[BitString66] [varchar](8) NULL,
	[BitString67] [varchar](8) NULL,
	[BitString68] [varchar](8) NULL,
	[BitString69] [varchar](8) NULL,
	[BitString70] [varchar](8) NULL,
	[BitString71] [varchar](8) NULL,
	[BitString72] [varchar](8) NULL,
	[BitString73] [varchar](8) NULL,
	[BitString74] [varchar](8) NULL,
	[BitString75] [varchar](8) NULL,
	[BitString76] [varchar](8) NULL,
	[BitString77] [varchar](8) NULL,
	[BitString78] [varchar](8) NULL,
	[BitString79] [varchar](8) NULL,
	[BitString80] [varchar](8) NULL,
	[BitString81] [varchar](8) NULL,
	[BitString82] [varchar](8) NULL,
	[BitString83] [varchar](8) NULL,
	[BitString84] [varchar](8) NULL,
	[BitString85] [varchar](8) NULL,
	[BitString86] [varchar](8) NULL,
	[BitString87] [varchar](8) NULL,
	[BitString88] [varchar](8) NULL,
	[BitString89] [varchar](8) NULL,
	[BitString90] [varchar](8) NULL,
	[BitString91] [varchar](8) NULL,
	[BitString92] [varchar](8) NULL,
	[BitString93] [varchar](8) NULL,
	[BitString94] [varchar](8) NULL,
	[BitString95] [varchar](8) NULL,
	[BitString96] [varchar](8) NULL,
	[BitString97] [varchar](8) NULL,
	[BitString98] [varchar](8) NULL,
	[BitString99] [varchar](8) NULL,
	[BitString100] [varchar](8) NULL,
	[BitString101] [varchar](8) NULL,
	[BitString102] [varchar](8) NULL,
	[BitString103] [varchar](8) NULL,
	[BitString104] [varchar](8) NULL,
	[BitString105] [varchar](8) NULL,
	[BitString106] [varchar](8) NULL,
	[BitString107] [varchar](8) NULL,
	[BitString108] [varchar](8) NULL,
	[BitString109] [varchar](8) NULL,
	[BitString110] [varchar](8) NULL,
	[BitString111] [varchar](8) NULL,
	[BitString112] [varchar](8) NULL,
	[BitString113] [varchar](8) NULL,
	[BitString114] [varchar](8) NULL,
	[BitString115] [varchar](8) NULL,
	[BitString116] [varchar](8) NULL,
	[BitString117] [varchar](8) NULL,
	[BitString118] [varchar](8) NULL,
	[BitString119] [varchar](8) NULL,
	[BitString120] [varchar](8) NULL,
	[BitString121] [varchar](8) NULL,
	[BitString122] [varchar](8) NULL,
	[BitString123] [varchar](8) NULL,
	[BitString124] [varchar](8) NULL,
	[BitString125] [varchar](8) NULL,
	[BitString126] [varchar](8) NULL,
	[BitString127] [varchar](8) NULL,
	[BitString128] [varchar](8) NULL,
	[BitString129] [varchar](8) NULL,
	[BitString130] [varchar](8) NULL,
	[BitString131] [varchar](8) NULL,
	[BitString132] [varchar](8) NULL,
	[BitString133] [varchar](8) NULL,
	[BitString134] [varchar](8) NULL,
	[BitString135] [varchar](8) NULL,
	[BitString136] [varchar](8) NULL,
	[BitString137] [varchar](8) NULL,
	[BitString138] [varchar](8) NULL,
	[BitString139] [varchar](8) NULL,
	[BitString140] [varchar](8) NULL,
	[BitString141] [varchar](8) NULL,
	[BitString142] [varchar](8) NULL,
	[BitString143] [varchar](8) NULL,
	[BitString144] [varchar](8) NULL,
	[BitString145] [varchar](8) NULL,
	[BitString146] [varchar](8) NULL,
	[BitString147] [varchar](8) NULL,
	[BitString148] [varchar](8) NULL,
	[BitString149] [varchar](8) NULL,
	[BitString150] [varchar](8) NULL,
	[BitString151] [varchar](8) NULL,
	[BitString152] [varchar](8) NULL,
	[BitString153] [varchar](8) NULL,
	[BitString154] [varchar](8) NULL,
	[BitString155] [varchar](8) NULL,
	[BitString156] [varchar](8) NULL,
	[BitString157] [varchar](8) NULL,
	[BitString158] [varchar](8) NULL,
	[BitString159] [varchar](8) NULL,
	[BitString160] [varchar](8) NULL,
	[BitString161] [varchar](8) NULL,
	[BitString162] [varchar](8) NULL,
	[BitString163] [varchar](8) NULL,
	[BitString164] [varchar](8) NULL,
	[BitString165] [varchar](8) NULL,
	[BitString166] [varchar](8) NULL,
	[BitString167] [varchar](8) NULL,
	[BitString168] [varchar](8) NULL,
	[BitString169] [varchar](8) NULL,
	[BitString170] [varchar](8) NULL,
	[BitString171] [varchar](8) NULL,
	[BitString172] [varchar](8) NULL,
	[BitString173] [varchar](8) NULL,
	[BitString174] [varchar](8) NULL,
	[BitString175] [varchar](8) NULL,
	[BitString176] [varchar](8) NULL,
	[BitString177] [varchar](8) NULL,
	[BitString178] [varchar](8) NULL,
	[BitString179] [varchar](8) NULL,
	[BitString180] [varchar](8) NULL,
	[BitString181] [varchar](8) NULL,
	[BitString182] [varchar](8) NULL,
	[BitString183] [varchar](8) NULL,
	[BitString184] [varchar](8) NULL,
	[BitString185] [varchar](8) NULL,
	[BitString186] [varchar](8) NULL,
	[BitString187] [varchar](8) NULL,
	[BitString188] [varchar](8) NULL,
	[BitString189] [varchar](8) NULL,
	[BitString190] [varchar](8) NULL,
	[BitString191] [varchar](8) NULL,
	[BitString192] [varchar](8) NULL,
	[BitString193] [varchar](8) NULL,
	[BitString194] [varchar](8) NULL,
	[BitString195] [varchar](8) NULL,
	[BitString196] [varchar](8) NULL,
	[BitString197] [varchar](8) NULL,
	[BitString198] [varchar](8) NULL,
	[BitString199] [varchar](8) NULL,
	[BitString200] [varchar](8) NULL,
	[BitString201] [varchar](8) NULL,
	[BitString202] [varchar](8) NULL,
	[BitString203] [varchar](8) NULL,
	[BitString204] [varchar](8) NULL,
	[BitString205] [varchar](8) NULL,
	[BitString206] [varchar](8) NULL,
	[BitString207] [varchar](8) NULL,
	[BitString208] [varchar](8) NULL,
	[BitString209] [varchar](8) NULL,
	[BitString210] [varchar](8) NULL,
	[BitString211] [varchar](8) NULL,
	[BitString212] [varchar](8) NULL,
	[BitString213] [varchar](8) NULL,
	[BitString214] [varchar](8) NULL,
	[BitString215] [varchar](8) NULL,
	[BitString216] [varchar](8) NULL,
	[BitString217] [varchar](8) NULL,
	[BitString218] [varchar](8) NULL,
	[BitString219] [varchar](8) NULL,
	[BitString220] [varchar](8) NULL,
	[BitString221] [varchar](8) NULL,
	[BitString222] [varchar](8) NULL,
	[BitString223] [varchar](8) NULL,
	[BitString224] [varchar](8) NULL,
	[BitString225] [varchar](8) NULL,
	[BitString226] [varchar](8) NULL,
	[BitString227] [varchar](8) NULL,
	[BitString228] [varchar](8) NULL,
	[BitString229] [varchar](8) NULL,
	[BitString230] [varchar](8) NULL,
	[BitString231] [varchar](8) NULL,
	[BitString232] [varchar](8) NULL,
	[BitString233] [varchar](8) NULL,
	[BitString234] [varchar](8) NULL,
	[BitString235] [varchar](8) NULL,
	[BitString236] [varchar](8) NULL,
	[BitString237] [varchar](8) NULL,
	[BitString238] [varchar](8) NULL,
	[BitString239] [varchar](8) NULL,
	[BitString240] [varchar](8) NULL,
	[BitString241] [varchar](8) NULL,
	[BitString242] [varchar](8) NULL,
	[BitString243] [varchar](8) NULL,
	[BitString244] [varchar](8) NULL,
	[BitString245] [varchar](8) NULL,
	[BitString246] [varchar](8) NULL,
	[BitString247] [varchar](8) NULL,
	[BitString248] [varchar](8) NULL,
	[BitString249] [varchar](8) NULL,
	[BitString250] [varchar](8) NULL,
	[BitString251] [varchar](8) NULL,
	[BitString252] [varchar](8) NULL,
	[BitString253] [varchar](8) NULL,
	[BitString254] [varchar](8) NULL,
	[BitString255] [varchar](8) NULL,
	[BitString256] [varchar](8) NULL,
	[BitString257] [varchar](8) NULL,
	[BitString258] [varchar](8) NULL,
	[BitString259] [varchar](8) NULL,
	[BitString260] [varchar](8) NULL,
	[BitString261] [varchar](8) NULL,
	[BitString262] [varchar](8) NULL,
	[BitString263] [varchar](8) NULL,
	[BitString264] [varchar](8) NULL,
	[BitString265] [varchar](8) NULL,
	[BitString266] [varchar](8) NULL,
	[BitString267] [varchar](8) NULL,
	[BitString268] [varchar](8) NULL,
	[BitString269] [varchar](8) NULL,
	[BitString270] [varchar](8) NULL,
	[BitString271] [varchar](8) NULL,
	[BitString272] [varchar](8) NULL,
	[BitString273] [varchar](8) NULL,
	[BitString274] [varchar](8) NULL,
	[BitString275] [varchar](8) NULL,
	[BitString276] [varchar](8) NULL,
	[BitString277] [varchar](8) NULL,
	[BitString278] [varchar](8) NULL,
	[BitString279] [varchar](8) NULL,
	[BitString280] [varchar](8) NULL,
	[BitString281] [varchar](8) NULL,
	[BitString282] [varchar](8) NULL,
	[BitString283] [varchar](8) NULL,
	[BitString284] [varchar](8) NULL,
	[BitString285] [varchar](8) NULL,
	[BitString286] [varchar](8) NULL,
	[BitString287] [varchar](8) NULL,
	[BitString288] [varchar](8) NULL,
	[BitString289] [varchar](8) NULL,
	[BitString290] [varchar](8) NULL,
	[BitString291] [varchar](8) NULL,
	[BitString292] [varchar](8) NULL,
	[BitString293] [varchar](8) NULL,
	[BitString294] [varchar](8) NULL,
	[BitString295] [varchar](8) NULL,
	[BitString296] [varchar](8) NULL,
	[BitString297] [varchar](8) NULL,
	[BitString298] [varchar](8) NULL,
	[BitString299] [varchar](8) NULL,
	[BitString300] [varchar](8) NULL,
	[BitString301] [varchar](8) NULL,
	[BitString302] [varchar](8) NULL,
	[BitString303] [varchar](8) NULL,
	[BitString304] [varchar](8) NULL,
	[BitString305] [varchar](8) NULL,
	[BitString306] [varchar](8) NULL,
	[BitString307] [varchar](8) NULL,
	[BitString308] [varchar](8) NULL,
	[BitString309] [varchar](8) NULL,
	[BitString310] [varchar](8) NULL,
	[BitString311] [varchar](8) NULL,
	[BitString312] [varchar](8) NULL,
	[BitString313] [varchar](8) NULL,
	[BitString314] [varchar](8) NULL,
	[BitString315] [varchar](8) NULL,
	[BitString316] [varchar](8) NULL,
	[BitString317] [varchar](8) NULL,
	[BitString318] [varchar](8) NULL,
	[BitString319] [varchar](8) NULL,
	[BitString320] [varchar](8) NULL,
	[BitString321] [varchar](8) NULL,
	[BitString322] [varchar](8) NULL,
	[BitString323] [varchar](8) NULL,
	[BitString324] [varchar](8) NULL,
	[BitString325] [varchar](8) NULL,
	[BitString326] [varchar](8) NULL,
	[BitString327] [varchar](8) NULL,
	[BitString328] [varchar](8) NULL,
	[BitString329] [varchar](8) NULL,
	[BitString330] [varchar](8) NULL,
	[BitString331] [varchar](8) NULL,
	[BitString332] [varchar](8) NULL,
	[BitString333] [varchar](8) NULL,
	[BitString334] [varchar](8) NULL,
	[BitString335] [varchar](8) NULL,
	[BitString336] [varchar](8) NULL,
	[BitString337] [varchar](8) NULL,
	[BitString338] [varchar](8) NULL,
	[BitString339] [varchar](8) NULL,
	[BitString340] [varchar](8) NULL,
	[BitString341] [varchar](8) NULL,
	[BitString342] [varchar](8) NULL,
	[BitString343] [varchar](8) NULL,
	[BitString344] [varchar](8) NULL,
	[BitString345] [varchar](8) NULL,
	[BitString346] [varchar](8) NULL,
	[BitString347] [varchar](8) NULL,
	[BitString348] [varchar](8) NULL,
	[BitString349] [varchar](8) NULL,
	[BitString350] [varchar](8) NULL,
	[BitString351] [varchar](8) NULL,
	[BitString352] [varchar](8) NULL,
	[BitString353] [varchar](8) NULL,
	[BitString354] [varchar](8) NULL,
	[BitString355] [varchar](8) NULL,
	[BitString356] [varchar](8) NULL,
	[BitString357] [varchar](8) NULL,
	[BitString358] [varchar](8) NULL,
	[BitString359] [varchar](8) NULL,
	[BitString360] [varchar](8) NULL,
	[BitString361] [varchar](8) NULL,
	[BitString362] [varchar](8) NULL,
	[BitString363] [varchar](8) NULL,
	[BitString364] [varchar](8) NULL,
	[BitString365] [varchar](8) NULL,
	[BitString366] [varchar](8) NULL,
	[BitString367] [varchar](8) NULL,
	[BitString368] [varchar](8) NULL,
	[BitString369] [varchar](8) NULL,
	[BitString370] [varchar](8) NULL,
	[BitString371] [varchar](8) NULL,
	[BitString372] [varchar](8) NULL,
	[BitString373] [varchar](8) NULL,
	[BitString374] [varchar](8) NULL,
	[BitString375] [varchar](8) NULL,
	[BitString376] [varchar](8) NULL,
	[BitString377] [varchar](8) NULL,
	[BitString378] [varchar](8) NULL,
	[BitString379] [varchar](8) NULL,
	[BitString380] [varchar](8) NULL,
	[BitString381] [varchar](8) NULL,
	[BitString382] [varchar](8) NULL,
	[BitString383] [varchar](8) NULL,
	[BitString384] [varchar](8) NULL,
	[BitString385] [varchar](8) NULL,
	[BitString386] [varchar](8) NULL,
	[BitString387] [varchar](8) NULL,
	[BitString388] [varchar](8) NULL,
	[BitString389] [varchar](8) NULL,
	[BitString390] [varchar](8) NULL,
	[BitString391] [varchar](8) NULL,
	[BitString392] [varchar](8) NULL,
	[BitString393] [varchar](8) NULL,
	[BitString394] [varchar](8) NULL,
	[BitString395] [varchar](8) NULL,
	[BitString396] [varchar](8) NULL,
	[BitString397] [varchar](8) NULL,
	[BitString398] [varchar](8) NULL,
	[BitString399] [varchar](8) NULL,
	[BitString400] [varchar](8) NULL,
	[BitString401] [varchar](8) NULL,
	[BitString402] [varchar](8) NULL,
	[BitString403] [varchar](8) NULL,
	[BitString404] [varchar](8) NULL,
	[BitString405] [varchar](8) NULL,
	[BitString406] [varchar](8) NULL,
	[BitString407] [varchar](8) NULL,
	[BitString408] [varchar](8) NULL,
	[BitString409] [varchar](8) NULL,
	[BitString410] [varchar](8) NULL,
	[BitString411] [varchar](8) NULL,
	[BitString412] [varchar](8) NULL,
	[BitString413] [varchar](8) NULL,
	[BitString414] [varchar](8) NULL,
	[BitString415] [varchar](8) NULL,
	[BitString416] [varchar](8) NULL,
	[BitString417] [varchar](8) NULL,
	[BitString418] [varchar](8) NULL,
	[BitString419] [varchar](8) NULL,
	[BitString420] [varchar](8) NULL,
	[BitString421] [varchar](8) NULL,
	[BitString422] [varchar](8) NULL,
	[BitString423] [varchar](8) NULL,
	[BitString424] [varchar](8) NULL,
	[BitString425] [varchar](8) NULL,
	[BitString426] [varchar](8) NULL,
	[BitString427] [varchar](8) NULL,
	[BitString428] [varchar](8) NULL,
	[BitString429] [varchar](8) NULL,
	[BitString430] [varchar](8) NULL,
	[BitString431] [varchar](8) NULL,
	[BitString432] [varchar](8) NULL,
	[BitString433] [varchar](8) NULL,
	[BitString434] [varchar](8) NULL,
	[BitString435] [varchar](8) NULL,
	[BitString436] [varchar](8) NULL,
	[BitString437] [varchar](8) NULL,
	[BitString438] [varchar](8) NULL,
	[BitString439] [varchar](8) NULL,
	[BitString440] [varchar](8) NULL,
	[BitString441] [varchar](8) NULL,
	[BitString442] [varchar](8) NULL,
	[BitString443] [varchar](8) NULL,
	[BitString444] [varchar](8) NULL,
	[BitString445] [varchar](8) NULL,
	[BitString446] [varchar](8) NULL,
	[BitString447] [varchar](8) NULL,
	[BitString448] [varchar](8) NULL,
	[BitString449] [varchar](8) NULL,
	[BitString450] [varchar](8) NULL,
	[BitString451] [varchar](8) NULL,
	[BitString452] [varchar](8) NULL,
	[BitString453] [varchar](8) NULL,
	[BitString454] [varchar](8) NULL,
	[BitString455] [varchar](8) NULL,
	[BitString456] [varchar](8) NULL,
	[BitString457] [varchar](8) NULL,
	[BitString458] [varchar](8) NULL,
	[BitString459] [varchar](8) NULL,
	[BitString460] [varchar](8) NULL,
	[BitString461] [varchar](8) NULL,
	[BitString462] [varchar](8) NULL,
	[BitString463] [varchar](8) NULL,
	[BitString464] [varchar](8) NULL,
	[BitString465] [varchar](8) NULL,
	[BitString466] [varchar](8) NULL,
	[BitString467] [varchar](8) NULL,
	[BitString468] [varchar](8) NULL,
	[BitString469] [varchar](8) NULL,
	[BitString470] [varchar](8) NULL,
	[BitString471] [varchar](8) NULL,
	[BitString472] [varchar](8) NULL,
	[BitString473] [varchar](8) NULL,
	[BitString474] [varchar](8) NULL,
	[BitString475] [varchar](8) NULL,
	[BitString476] [varchar](8) NULL,
	[BitString477] [varchar](8) NULL,
	[BitString478] [varchar](8) NULL,
	[BitString479] [varchar](8) NULL,
	[BitString480] [varchar](8) NULL,
	[BitString481] [varchar](8) NULL,
	[BitString482] [varchar](8) NULL,
	[BitString483] [varchar](8) NULL,
	[BitString484] [varchar](8) NULL,
	[BitString485] [varchar](8) NULL,
	[BitString486] [varchar](8) NULL,
	[BitString487] [varchar](8) NULL,
	[BitString488] [varchar](8) NULL,
	[BitString489] [varchar](8) NULL,
	[BitString490] [varchar](8) NULL,
	[BitString491] [varchar](8) NULL,
	[BitString492] [varchar](8) NULL,
	[BitString493] [varchar](8) NULL,
	[BitString494] [varchar](8) NULL,
	[BitString495] [varchar](8) NULL,
	[BitString496] [varchar](8) NULL,
	[BitString497] [varchar](8) NULL,
	[BitString498] [varchar](8) NULL,
	[BitString499] [varchar](8) NULL,
	[BitString500] [varchar](8) NULL,	
)