DROP DATABASE IF EXISTS peliculasdb;

CREATE DATABASE peliculasdb CHARACTER SET utf8mb4;

USE peliculasdb;

-- data for use

-- Tabla pelicula
CREATE TABLE pelicula (
    id INT NOT NULL AUTO_INCREMENT,
    titulo VARCHAR(50) NOT NULL UNIQUE,
    director VARCHAR(50) NOT NULL,
    anio INT(4) NOT NULL, -- Se puede cambiar datatype YEAR
    genero VARCHAR(50) NOT NULL,
    PRIMARY KEY (id)
);

-- data for security

-- user definition
CREATE TABLE
    user (
        id int NOT NULL AUTO_INCREMENT,
        nombre varchar(100) NOT NULL,
        correo varchar(100) NOT NULL,
        password varchar(255) NOT NULL,
        PRIMARY KEY (id)
    );

-- role definition
CREATE TABLE
    role (
        id int NOT NULL AUTO_INCREMENT,
        roleName varchar(50) NOT NULL,
        PRIMARY KEY (id)
    );

-- refreshtoken definition
CREATE TABLE
    refreshtoken (
        id int NOT NULL AUTO_INCREMENT,
        idUserFk int NOT NULL,
        token longtext DEFAULT NULL,
        expires datetime(6) NOT NULL,
        created datetime(6) NOT NULL,
        revoked datetime(6) DEFAULT NULL,
        PRIMARY KEY (id),
        FOREIGN KEY (idUserFk) REFERENCES user (id)
    );

-- userrol definition
CREATE TABLE
    roleuser (
        idUserFk int NOT NULL,
        idRoleFk int NOT NULL,
        PRIMARY KEY (idRoleFk, idUserFk),
        FOREIGN KEY (idRoleFk) REFERENCES role (id),
        FOREIGN KEY (idUserFk) REFERENCES user (id)
    );

-- index definitions
CREATE INDEX index_1
ON user (id);

CREATE INDEX index_2
ON role (id);

CREATE INDEX index_3
ON roleuser (idUserFk, idRoleFk);

CREATE INDEX index_4
ON pelicula (id, titulo);