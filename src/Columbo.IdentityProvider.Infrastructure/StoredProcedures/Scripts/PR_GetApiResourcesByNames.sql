USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE Name = 'PR_GetApiResourcesByNames')
	DROP PROCEDURE PR_GetApiResourcesByNames
GO
-- =============================================
-- Author:		PB
-- Create date: 01.01.2019
-- Description:	Procedure gets api resources by names
-- =============================================
CREATE PROCEDURE [dbo].[PR_GetApiResourcesByNames] 
	@apiResourcesNames StringList READONLY
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
	FROM [dbo].[ApiResource] resources
	INNER JOIN @apiResourcesNames list ON resources.Name = list.Value
END
GO
