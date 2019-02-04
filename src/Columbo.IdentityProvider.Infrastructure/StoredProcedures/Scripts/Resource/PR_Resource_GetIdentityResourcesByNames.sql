USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 01.01.2019
-- Description:	Procedure gets identity resources by names
-- =============================================
CREATE PROCEDURE [dbo].[PR_Resource_GetIdentityResourcesByNames]
	@identityResourcesNames StringList READONLY
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
		resources.[Name],
		resources.[Description],
		resources.[ShowInDiscoveryDocument],
		claim.[Type] ClaimType
	FROM [dbo].[IdentityResource] resources
	INNER JOIN [dbo].[IdentityResourceClaim] identityResourceClaim ON resources.Id = identityResourceClaim.IdentityResourceId
	INNER JOIN [dbo].[ClaimType] claim ON identityResourceClaim.ClaimTypeId = claim.Id
	INNER JOIN @identityResourcesNames list ON resources.Name = list.Value
END
GO
