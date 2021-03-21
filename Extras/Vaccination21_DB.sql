DROP TABLE IF EXISTS `Vaccines`;
DROP TABLE IF EXISTS `Citizens`;
DROP TABLE IF EXISTS `Records`;
DROP TABLE IF EXISTS `provinces`;


CREATE TABLE `Vaccines` (
`id` INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
`name` VARCHAR(100) NOT NULL,
`amounted` int NOT NULL);

CREATE TABLE `Citizens` (
`id` INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
`first_name` VARCHAR(55) NOT NULL,
`last_name` VARCHAR(55) NOT NULL,
`phone` VARCHAR(15) NOT NULL,
`birth_date` DATE,
`id_number` VARCHAR(11) NOT NULL);

CREATE TABLE `Records` (
`id` INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
`citizen` INT NOT NULL,
`vaccine` INT NOT NULL,
`province` INT NOT NULL,
`first_vac_date` TIMESTAMP NULL DEFAULT NULL,
`last_vac_date` TIMESTAMP NULL DEFAULT NULL,
`latitude` DECIMAL(18,15),
`longitude` DECIMAL(18,15));


CREATE TABLE `provinces` (
`id` INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
`name` VARCHAR(60) NOT NULL);

ALTER TABLE `Records` ADD CONSTRAINT `Records_citizen_Citizens_id` FOREIGN KEY (`citizen`) REFERENCES `Citizens`(`id`);
ALTER TABLE `Records` ADD CONSTRAINT `Records_vaccine_Vaccines_id` FOREIGN KEY (`vaccine`) REFERENCES `Vaccines`(`id`);
ALTER TABLE `Records` ADD CONSTRAINT `Records_province_provinces_id` FOREIGN KEY (`province`) REFERENCES `provinces`(`id`);
