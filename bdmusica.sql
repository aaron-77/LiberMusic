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
CREATE SCHEMA IF NOT EXISTS `libermusicmusica` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `libermusicmusica` ;

-- -----------------------------------------------------
-- Table `libermusic`.`artistas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `libermusicmusica`.`artistas` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(200) NOT NULL COMMENT 'nombre real del arista',
  `nombreArtistico` VARCHAR(200) NOT NULL COMMENT 'nombre con el que el artista sale en sus discos o canciones(el nombre de)',
  `fechaDeNacimiento` DATE NULL COMMENT 'fecha a partir de la cual el artista empezo su carrera',
  `web` LONGTEXT NULL,
  `estado` VARCHAR(20) NULL DEFAULT 'activo' COMMENT 'estatus del registro (activo,inactivo)',
  `nacionalidad` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `libermusic`.`albumes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `libermusicmusica`.`albumes` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `fkIdArtista` INT UNSIGNED NOT NULL,
  `titulo` VARCHAR(200) NOT NULL,
  `duracion` INT UNSIGNED NOT NULL COMMENT 'duracion en segundos',
  `numeroDeTracks` INT UNSIGNED NOT NULL,
  `companiaProductora` VARCHAR(200) NOT NULL,
  `tipoDeAlbum` VARCHAR(200) NOT NULL COMMENT 'sencillo,edicion especial,etc.',
  `fechaDeLanzamiento` DATE NULL,
  `urlDePortada` LONGTEXT NULL,
  `estado` VARCHAR(20) NULL DEFAULT 'activo' COMMENT 'estado del registro (activo,inactivo)',
  PRIMARY KEY (`id`),
  INDEX `fk_albumes_artistas1_idx` (`fkIdArtista` ASC) VISIBLE,
  CONSTRAINT `fk_albumes_artistas1`
    FOREIGN KEY (`fkIdArtista`)
    REFERENCES `libermusicmusica`.`artistas` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `libermusic`.`canciones`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `libermusicmusica`.`canciones` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `fkIdAlbum` INT UNSIGNED NOT NULL,
  `titulo` VARCHAR(200) NOT NULL,
  `numeroDeTrack` INT UNSIGNED NOT NULL,
  `genero` VARCHAR(200) NOT NULL,
  `codigoIsrc` VARCHAR(12) NOT NULL,
  `tamanoEnMb` INT UNSIGNED NOT NULL,
  `duracion` INT UNSIGNED NOT NULL,
  `contenidoExplicito` TINYINT(2) UNSIGNED NOT NULL,
  `urlDeUbicacion` LONGTEXT NOT NULL,
  `estado` VARCHAR(20) NULL DEFAULT 'en revision' COMMENT 'estatus del registro(activo,inactivo,en revision)si esta inactivo debe borrarse fisicamente el archivo de la cancion en el servidor. si esta en revision no puede visualizarse en el catalogo de canciones pero si existe en la bd y su archivo de cancion',
  PRIMARY KEY (`id`),
  INDEX `fk_canciones_albumes1_idx` (`fkIdAlbum` ASC) VISIBLE,
  CONSTRAINT `fk_canciones_albumes1`
    FOREIGN KEY (`fkIdAlbum`)
    REFERENCES `libermusicmusica`.`albumes` (`id`)
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

-- REGISTRO DE ARTISTAS INICIALES
START TRANSACTION;
INSERT INTO `libermusicmusica`.`artistas` (  `nombre`,`nombreArtistico`,`fechaDeNacimiento`,`web`,`nacionalidad`) VALUES (' Mike Portnoy James LaBrie John Petrucci' ,'Dream Theather', CURDATE(),'www.dreamtheather.com','EUA');
INSERT INTO `libermusicmusica`.`albumes` ( `fkIdArtista`,`titulo`,`duracion`,`numeroDeTracks`,`companiaProductora`,`tipoDeAlbum`,`fechaDeLanzamiento`,`urlDePortada`) VALUES (1,'When dream and day unite' ,3600, 9,'Mechanic records','sencillo',CURDATE(),"ruta/de/ejemplo");
INSERT INTO `libermusicmusica`.`canciones` ( `fkIdAlbum`,`titulo`,`numeroDeTrack`,`genero`,`codigoIsrc`,`tamanoEnMb`,`duracion`,`contenidoExplicito`,`urlDeUbicacion`) VALUES (1,'A fortune in lies' ,1, 'progresive metal','kkk63nsk9843',6,300,1,"ruta/de/ejemplo");
COMMIT;
