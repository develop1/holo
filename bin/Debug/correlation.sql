select 
	(count(*) * sum(x * y) - sum(x) * sum(y)) /
	(sqrt(count(*) * sum(x * x) - sum(x) * sum(x)) *
	sqrt(count(*) * sum(y * y) - sum(y) * sum(y)))
from data
;