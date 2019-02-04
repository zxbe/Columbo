USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 01.01.2019
-- Description:	Procedure gets all identity resources
-- =============================================
CREATE PROCEDURE [dbo].[PR_Resource_GetAllIdentityResources]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		identityResource.[Id],
		identityResource.[CreatorId],
		identityResource.[CreateDate],
		identityResource.[UpdateDate],
		identityResource.[Name],
		identityResource.[Description],
		identityResource.[ShowInDiscoveryDocument],
		claim.[Type] ClaimType
	FROM [dbo].[IdentityResource] identityResource
	INNER JOIN [dbo].[IdentityResourceClaim] identityResourceClaim ON identityResource.Id = identityResourceClaim.IdentityResourceId
	INNER JOIN [dbo].[ClaimType] claim ON identityResourceClaim.ClaimTypeId = claim.Id
END
GO
