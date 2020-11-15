select top (100000) * ,

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
where label = 'Bot' OR label = 'Benign' AND protocol = 6
order by timestamp asc