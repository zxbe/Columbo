USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 11.01.2019
-- Description:	Procedure gets claims of recources
-- =============================================
CREATE PROCEDURE [dbo].[PR_GetApiResourcesClaims]
	@apiResourcesId IntList READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		apiResourceClaim.ApiResourceId,
		claim.Type
	FROM [dbo].[ApiResourceClaim] apiResourceClaim
	INNER JOIN [dbo].[ClaimType] claim ON apiResourceClaim.ClaimTypeId = claim.Id
	INNER JOIN @apiResourcesId list ON apiResourceClaim.ApiResourceId = list.Value
END
GO
