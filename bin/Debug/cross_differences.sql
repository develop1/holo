attach database "test.db" as dt;
attach database "test_cross.db" as dtc;

create table if not exists dtc.cross(id_a int, id_b int, statname string, diff float);

insert into cross
--explain query plan
select a.id, b.id, a.statname, a.statvalue - b.statvalue
from stats a, stats b
where a.id <> b.id and a.statname = b.statname;

