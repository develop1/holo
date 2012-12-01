attach database "test.db" as dt;
.output "select_song.csv"

select a.path, b.statname, b.statvalue from main a, stats b
where a.id in (17975, 7165, 2213, 2217) and a.id = b.id
order by a.path, b.statname
;

.output "select_stats4.csv"
select a.id, a.statvalue, b.statvalue from stats a, stats b
where a.id = b.id and 
a.statname = 'b_skewn_FFT1_10'
and
b.statname = 'b_kurto_FFT1_10'
;
