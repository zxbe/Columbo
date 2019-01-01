IF EXISTS (SELECT * FROM sys.types WHERE is_table_type = 1 AND name = 'StringList')
	DROP TYPE StringList
GO
CREATE TYPE [dbo].[StringList] AS TABLE(
	[Value] [nvarchar](50) NOT NULL
)
GO