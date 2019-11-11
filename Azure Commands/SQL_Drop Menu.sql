ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Menu_MenuID];
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Menu_MenuID1];
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Menu_MenuID2];
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Menu_MenuID3];
ALTER TABLE [dbo].[Restaurants] DROP CONSTRAINT [FK_Restaurants_Menu_MenuID];
DROP TABLE [dbo].[Menu];
