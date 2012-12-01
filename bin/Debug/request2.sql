attach database "test.db" as dt;

--explain query plan 
select b.id, sum(((a.statvalue - b.statvalue)*(a.statvalue - b.statvalue))/(c1.value*c1.value)) as distance,
10000*max((a.statvalue - b.statvalue)*(a.statvalue - b.statvalue)/(c2.value*c2.value)) as maxdiff,
10000*avg((a.statvalue - b.statvalue)*(a.statvalue - b.statvalue)/(c2.value*c2.value)) as meandiff
from stats a, stats b, feature c1, 
feature c2
where 
a.id in (33,34) and 
b.id not in (33,34) and 
a.statname = c1.statname and c1.feature = 'mean' and 
a.statname = c2.statname and
c2.feature = 'max_min' and 
a.statname = b.statname and 
c1.statname = c2.statname and
a.statvalue <= b.statvalue + 60*(c2.value)/100 and a.statvalue >= b.statvalue - 60*(c2.value)/100
and 
a.statname in (
'b_median_FFT1_01', 'b_median_FFT1_02', 'b_median_FFT1_03', 'b_median_FFT1_04', 'b_median_FFT1_05', 'b_median_FFT1_06', 'b_median_FFT1_07', 'b_median_FFT1_08', 'b_median_FFT1_09', 'b_median_FFT1_10', 'b_median_FFT1_11',
'b_stdev_FFT1_01',  'b_stdev_FFT1_02',  'b_stdev_FFT1_03',  'b_stdev_FFT1_04',  'b_stdev_FFT1_05',  'b_stdev_FFT1_06', 'b_stdev_FFT1_07', 'b_stdev_FFT1_08', 'b_stdev_FFT1_09', 'b_stdev_FFT1_10', 'b_stdev_FFT1_11',
'b_skewn_FFT1_01',  'b_skewn_FFT1_02',  'b_skewn_FFT1_03',  'b_skewn_FFT1_04',  'b_skewn_FFT1_05',  'b_skewn_FFT1_06', 'b_skewn_FFT1_07', 'b_skewn_FFT1_08', 'b_skewn_FFT1_09', 'b_skewn_FFT1_10', 'b_skewn_FFT1_11',
'b_kurto_FFT1_01',  'b_kurto_FFT1_02',  'b_kurto_FFT1_03',  'b_kurto_FFT1_04',  'b_kurto_FFT1_05',  'b_kurto_FFT1_06', 'b_kurto_FFT1_07', 'b_kurto_FFT1_08', 'b_kurto_FFT1_09', 'b_kurto_FFT1_10', 'b_kurto_FFT1_11'
) 
group by b.id order by distance 
limit 30;