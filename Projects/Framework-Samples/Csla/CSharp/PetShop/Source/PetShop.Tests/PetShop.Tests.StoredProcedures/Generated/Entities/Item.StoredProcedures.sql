--region Drop Existing Procedures

IF OBJECT_ID(N'[dbo].[CSLA_Item_Insert]') IS NOT NULL
	DROP PROCEDURE [dbo].[CSLA_Item_Insert]

IF OBJECT_ID(N'[dbo].[CSLA_Item_Update]') IS NOT NULL
	DROP PROCEDURE [dbo].[CSLA_Item_Update]

IF OBJECT_ID(N'[dbo].[CSLA_Item_Delete]') IS NOT NULL
	DROP PROCEDURE [dbo].[CSLA_Item_Delete]

IF OBJECT_ID(N'[dbo].[CSLA_Item_Select]') IS NOT NULL
	DROP PROCEDURE [dbo].[CSLA_Item_Select]

--endregion

GO

--region [dbo].[CSLA_Item_Insert]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Blake Niemyjski using CodeSmith 5.0.0.0
-- Procedure Name: [dbo].[CSLA_Item_Insert]
-- Date Generated: Monday, January 25, 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[CSLA_Item_Insert]
	@p_ItemId varchar(10),
	@p_ProductId varchar(10),
	@p_ListPrice decimal(10, 2),
	@p_UnitCost decimal(10, 2),
	@p_Supplier int,
	@p_Status varchar(2),
	@p_Name varchar(80),
	@p_Image varchar(80)
AS

SET NOCOUNT ON

INSERT INTO [dbo].[Item] (
	[ItemId],
	[ProductId],
	[ListPrice],
	[UnitCost],
	[Supplier],
	[Status],
	[Name],
	[Image]
) VALUES (
	@p_ItemId,
	@p_ProductId,
	@p_ListPrice,
	@p_UnitCost,
	@p_Supplier,
	@p_Status,
	@p_Name,
	@p_Image
)

--endregion

GO

--region [dbo].[CSLA_Item_Update]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Blake Niemyjski using CodeSmith 5.0.0.0
-- Procedure Name: [dbo].[CSLA_Item_Update]
-- Date Generated: Monday, January 25, 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[CSLA_Item_Update]
	@p_ItemId varchar(10),
	@p_ProductId varchar(10),
	@p_ListPrice decimal(10, 2),
	@p_UnitCost decimal(10, 2),
	@p_Supplier int,
	@p_Status varchar(2),
	@p_Name varchar(80),
	@p_Image varchar(80)
AS

SET NOCOUNT ON

UPDATE [dbo].[Item] SET
	[ProductId] = @p_ProductId,
	[ListPrice] = @p_ListPrice,
	[UnitCost] = @p_UnitCost,
	[Supplier] = @p_Supplier,
	[Status] = @p_Status,
	[Name] = @p_Name,
	[Image] = @p_Image
WHERE
	[ItemId] = @p_ItemId

--endregion

GO

--region [dbo].[CSLA_Item_Delete]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Blake Niemyjski using CodeSmith 5.0.0.0
-- Procedure Name: [dbo].[CSLA_Item_Delete]
-- Date Generated: Monday, January 25, 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[CSLA_Item_Delete]
	@p_ItemId varchar(10)
AS

SET NOCOUNT ON

DELETE FROM
    [dbo].[Item]
WHERE
	[ItemId] = @p_ItemId

--endregion

GO

--region [dbo].[CSLA_Item_Select]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Blake Niemyjski using CodeSmith 5.0.0.0
-- Procedure Name: [dbo].[CSLA_Item_Select]
-- Date Generated: Monday, January 25, 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[CSLA_Item_Select]
	@p_ItemId varchar(10)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ItemId],
	[ProductId],
	[ListPrice],
	[UnitCost],
	[Supplier],
	[Status],
	[Name],
	[Image]
FROM
    [dbo].[Item]
WHERE
	[ItemId] = @p_ItemId

--endregion

GO

