USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 01.01.2019
-- Description:	Procedure gets an api resource by name
-- =============================================
CREATE PROCEDURE [dbo].[PR_GetApiResourceByName]
	@apiResourceName nvarchar(50)
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
		[ApiGuid],
		[Name],
		[Description],
		[InstanceId]
	FROM [dbo].[ApiResource]
	WHERE [Name] = @apiResourceName
END
GO
