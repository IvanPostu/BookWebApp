
USE books_demo;

-- TABLE VARIABLE
DECLARE @t TABLE (id INTEGER);
INSERT INTO @t SELECT TOP 5 (book_id) FROM dbo.books;
SELECT * FROM @t;
GO
SELECT * FROM @t;

-- LOCAL TEMPORARY TABLE
CREATE TABLE #t1 (id INTEGER);

-- GLOBAL TEMPORARY TABLE
CREATE TABLE ##t2 (id INTEGER);

--TEMPBD PERMANENT TABLE
USE tempdb;
CREATE TABLE t(id INTEGER);

SELECT * FROM tempdb.sys.objects ORDER BY modify_date DESC;


------------------------------------------------------------------------------------

USE books_demo;

-- Create table and indexes
CREATE TABLE testtable ([col1]  [int] NOT NULL PRIMARY KEY CLUSTERED,
                        [col2] [int]  NULL,
                        [col3] [int]  NULL,
                        [col4] [varchar](50) NULL,
                        [col5] uniqueidentifier); 
 
-- Load sample data into table
DECLARE @val INT
SELECT @val=1
WHILE @val < 5000000
BEGIN  
   INSERT INTO testtable (col1, col2, col3, col4, col5) 
       VALUES (@val,round(rand()*100000,0),
               round(rand()*100000,0),'TEST' + cast(@val AS VARCHAR), newid())
   SELECT @val=@val+1
END
GO
 
-- Create sample table and indexes
CREATE TABLE testtable2 ([col1]  [int] NOT NULL PRIMARY KEY NONCLUSTERED,
                         [col2] [int]  NULL,
                         [col3] [int]  NULL,
                         [col4] [varchar](50) NULL,
                         [col5] uniqueidentifier); 
 
INSERT INTO testtable2 SELECT * FROM testtable;

EXECUTE sp_helpindex testtable2;


-- clusterizat 304k reads 

DECLARE @val INT
SELECT @val=5000000
WHILE @val < 5100000
BEGIN  
   INSERT INTO testtable (col1, col2, col3, col4, col5) 
       VALUES (@val,round(rand()*100000,0),
               round(rand()*100000,0),'TEST' + cast(@val AS VARCHAR), newid())
   SELECT @val=@val+1
END
GO

-- nonclusterizat 406k reads 

DECLARE @val INT
SELECT @val=5000000
WHILE @val < 5100000
BEGIN  
   INSERT INTO testtable2 (col1, col2, col3, col4, col5) 
       VALUES (@val,round(rand()*100000,0),
               round(rand()*100000,0),'TEST' + cast(@val AS VARCHAR), newid())
   SELECT @val=@val+1
END
GO




GO

-- clusterizat 3068k reads 
DELETE FROM testtable WHERE col1 in (SELECT TOP 1000000 col1 FROM testtable ORDER BY newid());
-- nonclusterizat 4343k reads 
DELETE FROM testtable2 WHERE col1 not in (SELECT col1 FROM testtable);

GO

-- clusterizat 304k reads 
DECLARE @val INT
SELECT @val=5100000
WHILE @val < 5200000
BEGIN  
   INSERT INTO testtable (col1, col2, col3, col4, col5) 
       VALUES (@val,round(rand()*100000,0),
               round(rand()*100000,0),'TEST' + cast(@val AS VARCHAR), newid())
   SELECT @val=@val+1
END
GO
 
 -- nonclusterizat 422k reads 
DECLARE @val INT
SELECT @val=5100000
WHILE @val < 5200000
BEGIN  
   INSERT INTO testtable2 (col1, col2, col3, col4, col5) 
       VALUES (@val,round(rand()*100000,0),
               round(rand()*100000,0),'TEST' + cast(@val AS VARCHAR), newid())
   SELECT @val=@val+1
END
GO




SELECT COUNT(*) FROM dbo.testtable2 WITH (NOLOCK);


EXEC sp_who2



SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

