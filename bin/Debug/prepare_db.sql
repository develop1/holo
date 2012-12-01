.echo ON
attach database "test.db" as dt;

DROP INDEX IF EXISTS dt.idx_statname;
DROP INDEX IF EXISTS dt.idx_id_statname;
--CREATE INDEX IF NOT EXISTS dt.idx1 ON stats (statname, statvalue);
--CREATE INDEX IF NOT EXISTS dt.idx2 ON stats (id);
CREATE INDEX IF NOT EXISTS dt.idx3 ON stats (id, statname, statvalue);
VACUUM;