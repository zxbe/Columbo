USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 05.01.2019
-- Description:	Procedure gets identity resources of a client
-- =============================================
CREATE PROCEDURE [dbo].[PR_GetClientIdentityResources]
	@clientId int
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
		identityResource.[ShowInDiscoveryDocument]
	FROM [dbo].[ClientIdentityResource] clientIdentityResource
	INNER JOIN [dbo].[IdentityResource] identityResource ON clientIdentityResource.IdentityResourceId = identityResource.Id
	WHERE clientIdentityResource.ClientId = @clientId
END
GO
