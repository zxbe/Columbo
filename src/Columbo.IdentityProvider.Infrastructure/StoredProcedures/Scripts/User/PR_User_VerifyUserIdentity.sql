USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 30.01.2019
-- Description:	Procedure verifies the user identity and return its ID
-- =============================================
CREATE PROCEDURE [dbo].[PR_User_VerifyUserIdentity]
	@login nvarchar(50),
	@passwordHash char(44)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		[Id]
	FROM [dbo].[UserIdentity]
	WHERE [Login] = @login and [PasswordHash] = @passwordHash
END
GO
