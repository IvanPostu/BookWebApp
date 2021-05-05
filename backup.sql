 
USE master;
USE books_demo;


GO
DROP PROCEDURE IF EXISTS  dbo.backup_name_generate;
GO
CREATE PROCEDURE dbo.backup_name_generate(@pre_text VARCHAR(64), @post_text VARCHAR(64), @res VARCHAR(256) OUTPUT)
AS
BEGIN

	DECLARE @time VARCHAR(16)	= GETDATE()
	DECLARE @year VARCHAR(16)   = (SELECT CONVERT(VARCHAR(4), DATEPART(yy, @time)))
	DECLARE @month VARCHAR(16)	= (SELECT CONVERT(VARCHAR(2), FORMAT(DATEPART(mm,@time),'00')))
	DECLARE @day VARCHAR(16)	= (SELECT CONVERT(VARCHAR(2), FORMAT(DATEPART(dd,@time),'00')))

	DECLARE @date_separator VARCHAR(128) = CONCAT('__', @year, '_', @month, '_', @day, '_', REPLACE(CONVERT(VARCHAR(8),GETDATE(),108), ':', '_') ); 

	SET @res = CONCAT(@pre_text, @date_separator, @post_text );

END;
GO
--//////////////////////////////////////////////////////////////////////////////////////////////////////

DECLARE @BackupFileName VARCHAR(256);
EXECUTE dbo.backup_name_generate 'D:\books_demo_FULL', '.BAK', @BackupFileName OUTPUT;
BACKUP DATABASE books_demo
TO DISK = @BackupFileName
   WITH FORMAT,
      MEDIANAME = 'SQLServerBooksDBBackups',
      NAME = 'Full Backup of Books Database';
GO

EXECUTE dbo.generate_books 200;

GO
DECLARE @BackupFileName VARCHAR(256) ;
EXECUTE dbo.backup_name_generate 'D:\books_demo_DIFF', '.DIF', @BackupFileName OUTPUT;
BACKUP DATABASE books_demo
   To DISK=@BackupFileName
   WITH DIFFERENTIAL,
      MEDIANAME = 'SQLServerBooksDBBackups',
      NAME = 'Full Backup of Books Database';
GO

EXECUTE dbo.generate_books 200;

GO
DECLARE @BackupFileName VARCHAR(256);
EXECUTE dbo.backup_name_generate 'D:\books_demo_LOG', '.TRN', @BackupFileName OUTPUT;
BACKUP LOG [books_demo]
   To DISK=@BackupFileName
   WITH
      MEDIANAME = 'SQLServerBooksDBBackups',
      NAME = 'Full Backup of Books Database';
GO

SELECT * FROM dbo.books b ORDER BY b.book_id DESC;

--//////////////////////////////////////////////////////////////////////////////////////////////////////


RESTORE DATABASE qq
FROM DISK = 'D:\books_demo_FULL__2021_05_05_15_40_27.BAK'
    WITH NORECOVERY,
      MOVE 'books_demo' TO 'D:\db\data.mdf',
      MOVE 'books_demo_log' TO 'D:\db\logs.ldf';

RESTORE DATABASE qq
FROM DISK = 'D:\books_demo_DIFF__2021_05_05_15_40_31.DIF'
    WITH NORECOVERY,
      MOVE 'books_demo' TO 'D:\db\data.mdf',
      MOVE 'books_demo_log' TO 'D:\db\logs.ldf';

RESTORE DATABASE qq
FROM DISK = 'D:\books_demo_LOG__2021_05_05_15_40_36.TRN'
    WITH NORECOVERY,
      MOVE 'books_demo' TO 'D:\db\data.mdf',
      MOVE 'books_demo_log' TO 'D:\db\logs.ldf';

RESTORE DATABASE qq
FROM DISK = 'D:\books_demo_LOG__2021_05_05_15_40_40.TRN'
    WITH NORECOVERY,
      MOVE 'books_demo' TO 'D:\db\data.mdf',
      MOVE 'books_demo_log' TO 'D:\db\logs.ldf';

GO
RESTORE DATABASE qq WITH RECOVERY;
GO

SELECT * FROM qq.dbo.books b ORDER BY b.book_id DESC;




