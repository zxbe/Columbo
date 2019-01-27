USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 27.01.2019
-- Description:	Procedure gets user identity by id
-- =============================================
CREATE PROCEDURE [dbo].[PR_User_GetUserIdentityById]
	@userIdentityId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		ui.[Id],
		ui.[CreatorId],
		ui.[CreateDate],
		ui.[UpdateDate],
		ui.[UserId],
		ui.[Login],
		ui.[IsActive],
		u.[Id],
		u.[CreatorId],
		u.[CreateDate],
		u.[UpdateDate],
		u.[Name],
		u.[Surname],
		u.[EmailAddress]
	FROM [dbo].[UserIdentity] ui
	INNER JOIN [dbo].[User] u ON ui.UserId = u.Id
	WHERE ui.[Id] = @userIdentityId
END
GO
