SELECT * FROM mysql.user WHERE User = 'prince.g';

CREATE USER 'Arti'@'127.0.0.1' IDENTIFIED BY 'pass';

grant All Privileges on schoolmanagement.bnk01 to 'Arti' with grant option;

CREATE TABLE t1 (jdoc JSON);

INSERT INTO t1 VALUES('{"key1": "value1", "key2": "value2"}');

INSERT INTO t1 VALUES('[1, 2,');

SELECT JSON_ARRAY('a', 1, NOW());

SELECT JSON_OBJECT('key1', k01f02, 'key2', 'abc') from bnk01;

SELECT JSON_MERGE('["a", 1]', '{"key": "value"}');