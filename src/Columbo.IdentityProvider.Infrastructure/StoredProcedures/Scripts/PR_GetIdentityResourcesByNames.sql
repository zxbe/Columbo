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
CREATE PROCEDURE [dbo].[PR_GetIdentityResourcesByNames]
	@identityResourcesNames StringList READONLY
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
	FROM [dbo].[IdentityResource] resources
	INNER JOIN @identityResourcesNames list ON resources.Name = list.Value
END
GO
