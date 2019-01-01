IF EXISTS (SELECT * FROM sys.types WHERE is_table_type = 1 AND name = 'IntList')
	DROP TYPE IntList
GO
CREATE TYPE [dbo].[IntList] AS TABLE(
	[Value] [int] NOT NULL
)
GO