USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 25.01.2019
-- Description:	Procedure checks if the user identity is active
-- =============================================
CREATE PROCEDURE [dbo].[PR_User_IsUserIdentityActive]
	@userIdentityId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		[IsActive]
	FROM [IdentityProvider].[dbo].[UserIdentity]
	WHERE [Id] = @userIdentityId
END
GO
