-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema libermusic
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema libermusic
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `libermusiclistasdereproduccion` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `libermusiclistasdereproduccion` ;

-- -----------------------------------------------------
-- Table `libermusic`.`listasdereproduccion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `libermusiclistasdereproduccion`.`listasdereproduccion` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `fkIdUsuario` INT UNSIGNED NULL,
  `nombre` VARCHAR(200) NOT NULL,
  `numeroDeTracks` INT UNSIGNED NOT NULL,
  `estado` VARCHAR(20) NOT NULL DEFAULT 'activo',
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `libermusic`.`cancioneslistadereproduccion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `libermusiclistasdereproduccion`.`cancioneslistasdereproduccion` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `fkIdCancion` INT UNSIGNED NOT NULL,
  `fkListaDeReproduccion` INT UNSIGNED NOT NULL,
  `estado` VARCHAR(20) NULL DEFAULT 'activo' COMMENT 'estatus del registro (activo,inactivo)',
  PRIMARY KEY (`id`),
  INDEX `fk_cancioneslistadereproduccion_listasdereproduccion1_idx` (`fkListaDeReproduccion` ASC) VISIBLE,
  CONSTRAINT `fk_cancioneslistadereproduccion_listasdereproduccion1`
    FOREIGN KEY (`fkListaDeReproduccion`)
    REFERENCES `libermusiclistasdereproduccion`.`listasdereproduccion` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

SET SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';
CREATE USER 'admin' IDENTIFIED BY 'admin';
-- GRANT ALL PRIVILEGES ON *.* TO 'admin'@'localhost' WITH GRANT OPTION;
GRANT ALL PRIVILEGES ON *.* TO 'admin'@'%' WITH GRANT OPTION;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- REGISTRO DE LISTAS DE REPRODUCCION INICALES
START TRANSACTION;
INSERT INTO `libermusiclistasdereproduccion`.`listasdereproduccion` (  `fkIdUsuario`,`nombre`,`numeroDeTracks`) VALUES (1 ,'clasicos', 1);
INSERT INTO `libermusiclistasdereproduccion`.`cancioneslistasdereproduccion` (  `fkIdCancion`,`fkListaDeReproduccion`) VALUES (1 ,1);
COMMIT;
