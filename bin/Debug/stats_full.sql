.output "stats_full.txt"
-- detach database dt;
attach database "test.db" as dt;

select a.id, a.path, b.statname, b.statparam1, b.statparam2, b.statvalue
from main a, stats b
where a.id = b.id
;

.exit
.quit
