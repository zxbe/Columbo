USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 05.01.2019
-- Description:	Procedure gets claims of an api resource
-- =============================================
CREATE PROCEDURE [dbo].[PR_GetApiResourceClaims]
	@apiResourceId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
		claim.[Type]
	FROM [dbo].[ApiResourceClaim] apiResourceClaim
	INNER JOIN [dbo].[ClaimType] claim ON apiResourceClaim.ClaimTypeId = claim.Id
	WHERE apiResourceClaim.ApiResourceId = @apiResourceId
END
GO