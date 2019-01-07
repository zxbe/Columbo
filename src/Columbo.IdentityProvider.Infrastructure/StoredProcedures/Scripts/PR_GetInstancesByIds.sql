USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 05.01.2019
-- Description:	Procedure gets instances by id list
-- =============================================
CREATE PROCEDURE [dbo].[PR_GetInstancesByIds] 
	@idList IntList READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		[Id],
		[CreatorId],
		[CreateDate],
		[UpdateDate],
		[Name],
		[Description]
	FROM [dbo].[Instance] instance
	INNER JOIN @idList list ON instance.Id = list.Value
END
GO
