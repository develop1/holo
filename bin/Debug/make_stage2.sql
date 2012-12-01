attach database "test.db" as dt;
attach database "tmp.db" as tdt;

create table if not exists tdt.stage2(b_id int, statname string, dist float, featured_dist float);

insert or replace into stage2
select b.id as b_id, a.statname as statname, (a.statvalue - b.statvalue)*(a.statvalue - b.statvalue) as dist, (a.statvalue - b.statvalue)*(a.statvalue - b.statvalue)/(c1.value*c1.value) as featured_dist
from stats a, stats b, feature c1,
feature c2, feature c3
where 
a.id in (33) and 
b.id not in (33) and 
a.statname = c1.statname and c1.feature = 'mean' and 
a.statname = b.statname
and
a.statname = c2.statname and a.statname = c3.statname and 
c2.feature = 'max' and c3.feature = 'min' and 
c1.statname = c2.statname and c1.statname = c3.statname and 
(a.statvalue - b.statvalue) <= 10*(c2.value - c3.value)/100 and (b.statvalue - a.statvalue) <= 10*(c2.value - c3.value)/100
;

select * from stage2
limit 20;