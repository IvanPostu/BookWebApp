from faker import Faker
from collections import defaultdict
from sqlalchemy import create_engine
import pymssql

fake = Faker()

fake_data = defaultdict(list)

conn = pymssql.connect("DESKTOP-B1TKCSB", "sa", "qwerty$1", "books_demo")

# for _ in range(100000):
#     print (fake.first_name())


cursor.execute("SELECT * FROM dbo.books")
row = cursor.fetchone()
while row:
    print("book_id=%d, Name=%s" % (row[0], row[1]))
    row = cursor.fetchone()

conn.close()