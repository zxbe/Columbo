USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 01.01.2019
-- Description:	Procedure gets all api resources
-- =============================================
CREATE PROCEDURE [dbo].[PR_Resource_GetAllApiResources]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		apiResource.[Id],
		apiResource.[CreatorId],
		apiResource.[CreateDate],
		apiResource.[UpdateDate],
		apiResource.[ApiGuid],
		apiResource.[Name],
		apiResource.[Description],
		apiResource.[InstanceId],
		claim.[Type] ClaimType
	FROM [dbo].[ApiResource] apiResource
	INNER JOIN [dbo].[ApiResourceClaim] apiResourceClaim ON apiResource.Id = apiResourceClaim.ApiResourceId
	INNER JOIN [dbo].[ClaimType] claim ON apiResourceClaim.ClaimTypeId = claim.Id
END
GO
