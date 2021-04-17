import {getConnection,getRepository,getConnectionManager,createConnection} from "typeorm";
import {Album} from "../bd/entity/Album";
import {AlbumParser} from "../Utilities/Parser/AlbumesParser";
import {AlbumesRepository} from "../bd/controllersBd/AlbumesRepository";
//import {AlbumParser} from "../../Parser/AlbumesParser";
//import {Cancion} from "../../entity/Cancion";
//import {Artista} from "../../entity/Artista";
//import {v4 as uuidv4} from "uuid";
export class ServicioAlbumes {

    public  async  crearAlbum(datosalbum){
        let  albumParseado = AlbumParser.jsonToAlbum(datosalbum);
        let resultadoDeOperacion;
        try{
            let repositorioAlbum = new AlbumesRepository();
            resultadoDeOperacion = await repositorioAlbum.crearAlbum(albumParseado);
            console.log(resultadoDeOperacion.mensaje);
            console.log(resultadoDeOperacion.erroresDeValidacion);
            console.log(resultadoDeOperacion.erroresDeGuardado);
            return resultadoDeOperacion;   
        }catch(errores){
            console.log("errores: "+ errores);
        }
       return resultadoDeOperacion;
     
    }

    public async actualizarAlbum (albumP){
        let  albumParseado = AlbumParser.jsonToAlbum(albumP);
        let resultadoDeOperacion;
        try{
            let repositorioAlbum = new AlbumesRepository();
            resultadoDeOperacion = await repositorioAlbum.actualizarAlbum(albumParseado);
            console.log(resultadoDeOperacion.mensaje);
            console.log(resultadoDeOperacion.erroresDeValidacion);
            console.log(resultadoDeOperacion.erroresDeGuardado);
            return resultadoDeOperacion;   
        }catch(errores){
            console.log("errores: "+ errores);
        }
       return resultadoDeOperacion;
     
    }

    public async obtenerAlbumPorId(idAlbum){
        let resultadoDeOperacion;
        try{
            let repositorioAlbum = new AlbumesRepository();
            resultadoDeOperacion = await repositorioAlbum.obtenerAlbumPorId(idAlbum);
            console.log(resultadoDeOperacion.mensaje);
            console.log(resultadoDeOperacion.erroresDeValidacion);
            console.log(resultadoDeOperacion.erroresDeGuardado);
            return resultadoDeOperacion;   
        }catch(errores){
            console.log("errores: "+ errores);
        }
       return resultadoDeOperacion;

    }

    public async obtenerAlbumPorNombre(nombreAlbum){
        let resultadoDeOperacion;
        try{
            let repositorioAlbum = new AlbumesRepository();
            resultadoDeOperacion = await repositorioAlbum.obtenerAlbumPorNombre(nombreAlbum);
            console.log(resultadoDeOperacion.mensaje);
            console.log(resultadoDeOperacion.erroresDeValidacion);
            console.log(resultadoDeOperacion.erroresDeGuardado);
            return resultadoDeOperacion;   
        }catch(errores){
            console.log("errores: "+ errores);
        }
       return resultadoDeOperacion;
    }

    public async obtenerAlbumesPorIdArtista(idArtista){
        let resultadoDeOperacion;
        try{
            let repositorioAlbum = new AlbumesRepository();
            resultadoDeOperacion = await repositorioAlbum.obtenerAlbumesPorIdArtista(idArtista);
            console.log(resultadoDeOperacion.mensaje);
            console.log(resultadoDeOperacion.erroresDeValidacion);
            console.log(resultadoDeOperacion.erroresDeGuardado);
            return resultadoDeOperacion;   
        }catch(errores){
            console.log("errores: "+ errores);
        }
       return resultadoDeOperacion;
    }

    
}

