ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Bestellingen_BestellingId];
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Bestellingen_BestellingId1];
DROP TABLE [dbo].[Bestellingen];
