attach database "test.db" as dt;

select count(maxdiff), count(meandiff), count(mindiff)
from (
select a.statname,
max((a.statvalue - b.statvalue)*(a.statvalue - b.statvalue)/(c2.value*c2.value)) as maxdiff,
avg((a.statvalue - b.statvalue)*(a.statvalue - b.statvalue)/(c2.value*c2.value)) as meandiff,
min((a.statvalue - b.statvalue)*(a.statvalue - b.statvalue)/(c2.value*c2.value)) as mindiff
from stats a, stats b, feature c1, feature c2
where 
a.id in (505, 506, 507) and 
b.id in (505, 506, 507) and 
a.id <> b.id and
a.statname = b.statname and 
a.statname = c1.statname and c1.feature = 'min' and 
a.statname = c2.statname and c2.feature = 'max_min' and 
c1.statname = c2.statname 
group by a.statname 
order by a.statname
)
where maxdiff < 0.3
;