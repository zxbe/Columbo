USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 27.01.2019
-- Description:	Procedure gets user's roles by user identity id
-- =============================================
CREATE PROCEDURE [dbo].[PR_User_GetUserIdentityRoles]
	@userIdentityId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT
		r.[Id],
		r.[CreatorId],
		r.[CreateDate],
		r.[UpdateDate],
		r.[Name],
		r.[InstanceId],
		r.[RoleTypeId] RoleType
	FROM [dbo].[UserRole] userRole
	INNER JOIN [dbo].[Role] r ON userRole.RoleId = r.Id
	WHERE userRole.UserIdentityId = @userIdentityId
END
GO
