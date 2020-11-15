select top (100000) * 

from gann.dbo.flow_data fd

inner join gann.dbo.binary_data b on b.startime = fd.timestamp
inner join gann.dbo.TinyInt ti on ti.bytes_idx = b.idx
where label = 'Bot' OR label = 'Benign'
order by timestamp asc