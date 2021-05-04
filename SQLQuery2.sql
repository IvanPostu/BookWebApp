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

EXECUTE dbo.generate_books 22100;


SELECT * FROM dbo.books WHERE title='17FAE0B';
SELECT * FROM dbo.books;

GO


IF EXISTS (SELECT name FROM sys.indexes  
            WHERE name = N'IX_books_title')   
    DROP INDEX IX_books_title ON books;   
GO  

CREATE NONCLUSTERED INDEX IX_books_title   
    ON books (title);   


--INDEX


SET STATISTICS IO OFF;
SET STATISTICS IO ON;





