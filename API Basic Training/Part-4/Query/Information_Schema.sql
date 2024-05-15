SELECT table_name, table_type, engine,table_schema
       FROM information_schema.tables
       WHERE table_schema in('inventory_management','practice_db','ormdemo')
       ORDER BY table_name;