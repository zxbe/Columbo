USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 01.01.2019
-- Description:	Procedure gets a client by guid
-- =============================================
CREATE PROCEDURE [dbo].[PR_Client_GetClientByGuid]
	@clientGuid uniqueidentifier
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
		[Version],
		[ClientGuid],
		[SecretHash],
		[RedirectUri],
		[PostLogoutRedirectUri],
		[IdentityTokenLifetime],
		[AccessTokenLifetime],
		[SequrityCodeLifetiem],
		[IsActive]
	FROM [dbo].[Client]
	WHERE [ClientGuid] = @clientGuid AND [IsActive] = 1
END
GO
