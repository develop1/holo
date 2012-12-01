attach database "test.db" as dt;

explain select 
	b.id, 
	sum(((a.statvalue - b.statvalue)*(a.statvalue - b.statvalue))/(c.value*c.value)) as distance
from 
	stats a, stats b, feature c
where 
	a.id in (33) and
	b.id not in (33) and
	a.statname = b.statname and
	a.statname = c.statname and
	c.feature = "mean"
and
--	a.statname in (
--	"b_median_FFT1_01", "b_median_FFT1_02", "b_median_FFT1_03", "b_median_FFT1_04", "b_median_FFT1_05", "b_median_FFT1_06", "b_median_FFT1_07", "b_median_FFT1_08", "b_median_FFT1_09", "b_median_FFT1_10", "b_median_FFT1_11",
--	"b_stdev_FFT1_01",  "b_stdev_FFT1_02",  "b_stdev_FFT1_03",  "b_stdev_FFT1_04",  "b_stdev_FFT1_05",  "b_stdev_FFT1_06", "b_stdev_FFT1_07", "b_stdev_FFT1_08", "b_stdev_FFT1_09", "b_stdev_FFT1_10", "b_stdev_FFT1_11",
--	"b_skewn_FFT1_01",  "b_skewn_FFT1_02",  "b_skewn_FFT1_03",  "b_skewn_FFT1_04",  "b_skewn_FFT1_05",  "b_skewn_FFT1_06", "b_skewn_FFT1_07", "b_skewn_FFT1_08", "b_skewn_FFT1_09", "b_skewn_FFT1_10", "b_skewn_FFT1_11",
--	"b_kurto_FFT1_01",  "b_kurto_FFT1_02",  "b_kurto_FFT1_03",  "b_kurto_FFT1_04",  "b_kurto_FFT1_05",  "b_kurto_FFT1_06", "b_kurto_FFT1_07", "b_kurto_FFT1_08", "b_kurto_FFT1_09", "b_kurto_FFT1_10", "b_kurto_FFT1_11"
--	)
	--a.statname like "%median%FFT%"
	--a.statname not like 'middle_%' and
	--a.statname like '%_ED' or a.statname like '%_ASC'
	--a.statname like 'stdev_%'
	--a.statname like 'mean_%' and a.statname not like 'mean_FFT%'
	--and a.statname not like 'middle_mean_FFT1_s%'
	--(a.statname like 'middle_mean_FFT2%' or a.statname like '%_ED')
	--a.statname in ('mean_ASC', 'mean_ED')
group by b.id
order by distance
limit 30
;

