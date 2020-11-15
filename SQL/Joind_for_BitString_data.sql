select  DISTINCT ti.ID, fd.*, bs1.*, --bs2.*,

CASE
    WHEN label = 'Benign' THEN 1
	ELSE 0
END AS Benign,
CASE
    WHEN label = 'Bot' THEN 1
	ELSE 0
END AS Bot

from gann.dbo.flow_data fd
inner join gann.dbo.binary_data b on b.startime = fd.timestamp
inner join gann.[dbo].[TinyInt] ti on b.idx = ti.binary_data_idx
inner join gann.dbo.Bit_Strings_From_TinyInt_1_500 bs1 on ti.ID =  bs1.[idx_TinyInt]
inner join gann.dbo.Bit_Strings_From_TinyInt_501_1000 bs2 on ti.ID =  bs2.[idx_TinyInt]
where label = 'Bot' OR label = 'Benign' AND protocol = 6
order by timestamp asc