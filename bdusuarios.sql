-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema libermusicusuarios
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema libermusicusuarios
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `libermusicusuarios` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `libermusicusuarios` ;

-- -----------------------------------------------------
-- Table `libermusic`.`usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `libermusicusuarios`.`usuarios` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `fkIdArtista` INT UNSIGNED NULL,
  `nombreDeUsuario` VARCHAR(200) NOT NULL COMMENT 'nombre de usuario(nickname) de la cuenta que se esta creando',
  `nombreDelPropietario` VARCHAR(200) NOT NULL COMMENT 'nombre de la persona a quien pertenece la cuenta de usuario',
  `contrasena` VARCHAR(200) NOT NULL,
  `email` VARCHAR(200) NOT NULL,
  `pais` VARCHAR(200) NOT NULL COMMENT 'pais de origen del usuario',
  `estado` VARCHAR(20) NULL DEFAULT 'activo' COMMENT 'estatus de guardado(activo,inactivo)',
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

SET SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';
CREATE USER 'admin' IDENTIFIED WITH mysql_native_password BY 'admin';
-- GRANT ALL PRIVILEGES ON *.* TO 'admin'@'localhost' WITH GRANT OPTION;
GRANT ALL PRIVILEGES ON *.* TO 'admin'@'%' WITH GRANT OPTION;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- REGISTRO DE USUARIOS  INICIALES
START TRANSACTION;
INSERT INTO `libermusicusuarios`.`usuarios` (  `nombreDeUsuario`,`nombreDelPropietario`,`contrasena`,`email`,`pais`) VALUES (' AaronHL99' ,'Aaron Hernandez Lara','admin99','aaronhl99@aaron.com','Mexico');
INSERT INTO `libermusicusuarios`.`usuarios` ( `fkIdArtista` ,`nombreDeUsuario`,`nombreDelPropietario`,`contrasena`,`email`,`pais`) VALUES (1,'dreamtheather99' ,' Mike Portnoy, John Petrucci, James LaBrie','admin99','dreamtheather@dreamtheather.com','EUA');
COMMIT;