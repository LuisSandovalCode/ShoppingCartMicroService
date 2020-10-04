  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
'__EFMigrationsHistory'' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

CREATE TABLE `sessionShoppingCarts` (
    `SessionShopingCartId` int NOT NULL AUTO_INCREMENT,
    `CreateDate` datetime NULL,
    PRIMARY KEY (`SessionShopingCartId`)
);

CREATE TABLE `sessionShoppingCartDetails` (
    `SessionShoppingCartDetailId` int NOT NULL AUTO_INCREMENT,
    `CreateDate` datetime NULL,
    `ProductSelected` text NULL,
    `SessionShopingCartId` int NOT NULL,
    `SessionShoppingCartSessionShopingCartId` int NULL,
    PRIMARY KEY (`SessionShoppingCartDetailId`),
    CONSTRAINT `FK_sessionShoppingCartDetails_sessionShoppingCarts_SessionShopp~` FOREIGN KEY (`SessionShoppingCartSessionShopingCartId`) REFERENCES `sessionShoppingCarts` (`SessionShopingCartId`) ON DELETE RESTRICT
);

CREATE INDEX `IX_sessionShoppingCartDetails_SessionShoppingCartSessionShoping~` ON `sessionShoppingCartDetails` (`SessionShoppingCartSessionShopingCartId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20201003235254_myMigration', '3.1.2');

