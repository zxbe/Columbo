USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 05.01.2019
-- Description:	Procedure gets claim types of an identity resource
-- =============================================
CREATE PROCEDURE [dbo].[PR_GetIdentityResourceClaims]
	@identityResourceId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		claim.[Type]
	FROM [dbo].[IdentityResourceClaim] identityResourceClaim
	INNER JOIN [dbo].[ClaimType] claim ON identityResourceClaim.ClaimTypeId = claim.Id
	WHERE identityResourceClaim.IdentityResourceId = @identityResourceId
END
GO
