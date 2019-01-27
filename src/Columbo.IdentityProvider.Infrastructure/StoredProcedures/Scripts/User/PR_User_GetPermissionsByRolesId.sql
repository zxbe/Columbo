USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 27.01.2019
-- Description:	Procedure gets permissions by role ids
-- =============================================
CREATE PROCEDURE [dbo].[PR_User_GetPermissionsByRolesId]
	@rolesId IntList READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		rolePermission.[RoleId] RoleId,
		permission.[Id] Permission
	FROM [dbo].[RolePermission] rolePermission
	INNER JOIN [dbo].[Permission] permission ON rolePermission.PermissionId = permission.Id
	INNER JOIN @rolesId roles ON rolePermission.RoleId = roles.Value
END
GO
