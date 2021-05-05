USE books_demo;

GO
DROP PROCEDURE IF EXISTS  dbo.generate_books;
GO
CREATE PROCEDURE dbo.generate_books(@count INTEGER)
AS
BEGIN
	DECLARE @cnt INT = 0;
	DECLARE @title VARCHAR(256);
	DECLARE @content VARCHAR(256);

	BEGIN TRANSACTION tt1;

		WHILE @cnt < @count
		BEGIN

			DECLARE @cc INTEGER = (abs(checksum(NEWID())) % 52)+1;

			SET @title = (
				SELECT TOP (1)
					LEFT (CAST (NEWID () AS NVARCHAR(MAX)) , ABS (CHECKSUM (NEWID ())) % 12 + 1)
				FROM SYS.OBJECTS A
				CROSS JOIN SYS.OBJECTS B);

			SET @content = (
				SELECT TOP (1)
					LEFT (CAST (NEWID () AS NVARCHAR(MAX)) , ABS (CHECKSUM (NEWID ())) % 12 + 1)
				FROM SYS.OBJECTS A
				CROSS JOIN SYS.OBJECTS B);

			INSERT INTO dbo.books (author_id, title, content)
			VALUES (1, @title, @content)

			SET @cnt = @cnt + 1;
		END;
	COMMIT ;
END;
GO

;

EXECUTE dbo.generate_books 2100;


SELECT * FROM dbo.books WHERE title='34DD34B';

SELECT * FROM dbo.books AS b WHERE  content='CC45' 
ORDER BY b.content
OFFSET 0 ROWS
FETCH NEXT 7 ROWS ONLY;

SELECT * FROM dbo.books WHERE title LIKE '%CAA%';
SELECT * FROM dbo.books b ORDER BY b.book_id DESC;

GO



-- INDEX
IF EXISTS (SELECT name FROM sys.indexes  
            WHERE name = N'IX_books_title')   
    DROP INDEX IX_books_title ON books;   
GO  
CREATE NONCLUSTERED INDEX IX_books_title   
    ON books (title) ;   
GO

IF EXISTS (SELECT name FROM sys.indexes  
            WHERE name = N'IX_books_content')   
    DROP INDEX IX_books_content ON books;   
GO  
CREATE NONCLUSTERED INDEX IX_books_content   
    ON books (content) ;   
GO



CREATE UNIQUE CLUSTERED INDEX PK_books_book_id
   ON dbo.books(book_id)
   WITH (DROP_EXISTING=ON, SORT_IN_TEMPDB = OFF, ONLINE = ON)
   ON [Primary]
--INDEX


SET STATISTICS IO OFF;
SET STATISTICS IO ON;

SET  STATISTICS TIME OFF;
SET  STATISTICS TIME ON;


EXECUTE sp_helpindex books;


