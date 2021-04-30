--------------------
--Data Definition---
--------------------
USE master;

GO
	DROP DATABASE IF EXISTS books_demo;
	CREATE DATABASE books_demo;
GO


USE books_demo;

GO
	IF OBJECT_ID(N'dbo.books', N'U') IS NULL
	BEGIN
		CREATE TABLE dbo.books (
			book_id INTEGER PRIMARY KEY IDENTITY(1, 1),
			title VARCHAR(256),
			content VARCHAR(2560),
			author_id INTEGER
		);
	END
GO

GO
	IF OBJECT_ID(N'dbo.authors', N'U') IS NULL
	BEGIN
		CREATE TABLE dbo.authors (
			author_id INTEGER PRIMARY KEY IDENTITY(1, 1),
			fullname VARCHAR(256)
		);
	END
GO

GO
ALTER TABLE dbo.books
ADD CONSTRAINT fk_author_book
FOREIGN KEY (author_id) REFERENCES dbo.authors(author_id);
GO



--------------------
--Data Insert    ---
--------------------
INSERT INTO dbo.authors (fullname)
VALUES
('Jim'),
('Maxim'),
('Mihai')
;

INSERT INTO dbo.books (author_id, title, content)
VALUES
(1, 'C++ for kids', 'Basic C++ '),
(1, 'JS fundamentals', 'JS book content'),
(2, 'C#', 'content...'),
(2, 'Java', 'content...'),
(2, 'Python', 'content...'),
(3, 'Pascal', 'content...'),
(3, 'Assembler', 'content...')
;

GO

--------------------
-- Procedures    ---
--------------------




DROP PROCEDURE IF EXISTS GetBooks;

CREATE PROCEDURE GetBooks
(
	@with_autors BIT
)
AS
BEGIN

	IF @with_autors = 1
		SELECT * FROM dbo.books AS b
		INNER JOIN dbo.authors AS a ON a.author_id=b.author_id;
		

END
;


EXEC GetBooks 1;


GO
DROP PROCEDURE IF EXISTS AddBook;
GO

GO
CREATE PROCEDURE AddBook
(
	@title VARCHAR(256),
	@content VARCHAR(256),
	@author_id INTEGER,
	@inserted_id INTEGER OUT
)
AS
BEGIN
	SET @inserted_id = -1;

	INSERT INTO dbo.books (author_id, title, content)
	VALUES
	(@author_id, @title, @content);

	SET @inserted_id = (SELECT SCOPE_IDENTITY());
END
;
GO

DECLARE @result INTEGER;

EXEC AddBook  'Harry Potter', 'dfladkf;ka.......', 1, @result OUTPUT;
SELECT (@result);






GO
DROP PROCEDURE IF EXISTS UpdateBook;
GO

GO
CREATE PROCEDURE UpdateBook
(
	@book_id INTEGER,
	@title VARCHAR(256),
	@content VARCHAR(256),
	@author_id INTEGER
)
AS
BEGIN

	UPDATE dbo.books
	SET author_id = @author_id, title= @title, content = @content
	WHERE book_id = @book_id;

END
;
GO


EXEC UpdateBook 1, 'Harry Potter', 'dfladkf;ka.......', 1;






GO
DROP PROCEDURE IF EXISTS DeleteBookById;
GO

GO
CREATE PROCEDURE DeleteBookById
(
	@book_id INTEGER
)
AS
BEGIN
	DELETE FROM dbo.books WHERE book_id=@book_id;
END
;
GO

EXEC DeleteBookById 2;



--/////////////////////////BACKUP//


USE master;


GO
BACKUP DATABASE books_demo
TO DISK = 'D:\books_demo.bak'
   WITH FORMAT,
      MEDIANAME = 'SQLServerBackups',
      NAME = 'Full Backup of SQLTestDB';
GO

GO
BACKUP LOG books_demo TO DISK = 'D:\books_demo.bak'
GO



USE books_demo;


DECLARE @result INTEGER;
EXEC AddBook  'Harry Potter', 'dfladkf;ka.......', 1, @result OUTPUT;
SELECT (@result);




