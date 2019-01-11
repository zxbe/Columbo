USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 11.01.2019
-- Description:	Procedure gets claims of identity resources
-- =============================================
CREATE PROCEDURE [dbo].[PR_GetIdentityResourcesClaims]
	@identityResourcesId IntList READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT
		identityResourceClaim.IdentityResourceId,
		claim.Type
	FROM [dbo].[IdentityResourceClaim] identityResourceClaim
	INNER JOIN [dbo].[ClaimType] claim ON identityResourceClaim.ClaimTypeId = claim.Id
	INNER JOIN @identityResourcesId list ON identityResourceClaim.IdentityResourceId = list.Value
END
GO
