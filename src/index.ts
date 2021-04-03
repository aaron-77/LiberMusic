import "reflect-metadata";
import {ArtistasRepository} from "./bd/controllersBd/ArtistasRepository"
import {ArtistaParser} from "./Parser/ArtistaParser";
import {Artista} from "./entity/Artista";
import * as aplicattion from "./app";
import {createConnection} from "typeorm";
var express = require('express');
var app = express();
var path = require('path');
var http = require('http');
var https = require('https');


let server = http.createServer();
const port = 4001;
const ip = 'localhost';


 async function crearConexion() {
   

 } 
server.listen(port, ip, function () {
 
    let artistaRepository = new ArtistasRepository();
    
    let datosartista = {
        id:3,
        nombre:"Gary Moore Mcarty Dylan",
        nombreArtistico:"Gary Moore",
        fechaDeNacimiento:"1992-11-13 17:00:00",
        web:"www.gary.com",
        estado:"activo",
        nacionalidad:"Irlanda"
    }
    let artistaUpdate = ArtistaParser.jsonToArtista(datosartista);
    //artista.crearArtista(datosartista);
    artistaRepository.actualizarArtista(artistaUpdate)
    console.log("2"+__dirname); 
    console.log("corriendo en: "+ip+" "+port);
    
});

