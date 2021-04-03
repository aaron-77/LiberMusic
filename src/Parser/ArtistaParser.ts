import {Artista} from "../entity/Artista";


export class ArtistaParser{

    static jsonToArtista(datosArista):Artista{
       
        let artista = new Artista();
        artista.id = datosArista.id;
        artista.nombre = datosArista.nombre;
        artista.nombreArtistico = datosArista.nombreArtistico;
        artista.fechaDeNacimiento = datosArista.fechaDeNacimiento;
        artista.web = datosArista.web;
        artista.estado = datosArista.estado;
        artista.nacionalidad = datosArista.nacionalidad;

        return artista;
    }

    static artistaToJson(artista:Artista){
        let artistaJson ={
            id:artista.id,
            nombre:artista.nombre,
            nombreArtistico:artista.nombreArtistico,
            fechaDeNacimiento:artista.fechaDeNacimiento,
            web:artista.web,
            estado:artista.estado,
            nacionalidad:artista.nacionalidad
        }

        return artistaJson;
    }

}