USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 01.01.2019
-- Description:	Procedure gets api resources by names
-- =============================================
CREATE PROCEDURE [dbo].[PR_Resource_GetApiResourcesByNames] 
	@apiResourcesNames StringList READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		resources.[Id],
		resources.[CreatorId],
		resources.[CreateDate],
		resources.[UpdateDate],
		resources.[ApiGuid],
		resources.[Name],
		resources.[Description],
		resources.[InstanceId],
		claim.[Type] ClaimType
	FROM [dbo].[ApiResource] resources
	INNER JOIN [dbo].[ApiResourceClaim] apiResourceClaim ON resources.Id = apiResourceClaim.ApiResourceId
	INNER JOIN [dbo].[ClaimType] claim ON apiResourceClaim.ClaimTypeId = claim.Id
	INNER JOIN @apiResourcesNames list ON resources.Name = list.Value
END
GO
