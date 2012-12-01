attach database "test2.db" as dt;

DROP INDEX IF EXISTS dt.idx_statname;
DROP INDEX IF EXISTS dt.idx_id_statname;
CREATE INDEX IF NOT EXISTS dt.idx3 ON stats (id, statname, statvalue);
VACUUM;

.output "calc_feat1.csv"

create table if not exists dt.feature(statname string, feature string, value float);

insert or replace into feature
	select statname, "max", max(statvalue)
	from stats
	group by statname
;

insert or replace into feature
	select statname, "min", min(statvalue)
	from stats
	group by statname
;

insert or replace into feature
	select statname, "max_min", max(statvalue)-min(statvalue)
	from stats
	group by statname
;

insert or replace into feature
	select statname, "mean", avg(statvalue)
	from stats
	group by statname
;

select statname, max(statvalue), min(statvalue), avg(statvalue), max(statvalue)-min(statvalue)
from stats
group by statname
order by statname
;

DROP INDEX IF EXISTS dt.idx_statname_feat;
DROP INDEX IF EXISTS dt.idx_statname;
CREATE INDEX IF NOT EXISTS dt.idx_statname_feat ON feature (statname, feature, value);
CREATE INDEX IF NOT EXISTS dt.idx_statname ON feature (statname, value);