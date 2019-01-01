USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS(SELECT * FROM sys.procedures WHERE Name = 'PR_GetIdentityResources')
	DROP PROCEDURE PR_GetIdentityResources
GO
-- =============================================
-- Author:		PB
-- Create date: 01.01.2019
-- Description:	Procedure gets all identity resources
-- =============================================
CREATE PROCEDURE [dbo].[PR_GetIdentityResources]
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
		[Name],
		[Description],
		[ShowInDiscoveryDocument]
	FROM [dbo].[IdentityResource]
END
GO
