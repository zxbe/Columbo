USE [IdentityProvider]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PB
-- Create date: 05.01.2019
-- Description:	Procedure gets api resources of a client
-- =============================================
CREATE PROCEDURE [dbo].[PR_GetClientApiResources]
	@clientId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		apiResource.[Id],
		apiResource.[CreatorId],
		apiResource.[CreateDate],
		apiResource.[UpdateDate],
		apiResource.[ApiGuid],
		apiResource.[Name],
		apiResource.[Description],
		apiResource.[InstanceId]
	FROM [dbo].[ClientApiResource] clientApiResource
	INNER JOIN [dbo].[ApiResource] apiResource ON clientApiResource.ApiResourceId = apiResource.Id
	WHERE clientApiResource.ClientId = @clientId
END
GO
