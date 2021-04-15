import {getConnection,getRepository,getConnectionManager,createConnection} from "typeorm";
import {Album} from "../bd/entity/Album";
//import {AlbumParser} from "../../Parser/AlbumesParser";
//import {Cancion} from "../../entity/Cancion";
import {Artista} from "../bd/entity/Artista";
import {v4 as uuidv4} from "uuid";
import {ArtistaParser} from "../Utilities/Parser/ArtistaParser";
import {ArtistasRepository} from "../bd/controllersBd/ArtistasRepository";
class ServicioArtistas {

    public async registrarArtista (artista): Promise<any>{
        let  artistaParseado = ArtistaParser.jsonToArtista(artista);
        let resultadoDeOperacion;
        try{
            let repositorioArtistas = new ArtistasRepository();
            resultadoDeOperacion = await repositorioArtistas.crearArtista(artistaParseado);
            console.log(resultadoDeOperacion.mensaje);
            console.log(resultadoDeOperacion.erroresDeValidacion);
            console.log(resultadoDeOperacion.erroresDeGuardado);
            return resultadoDeOperacion;   
        }catch(errores){
            console.log("errores: "+ errores);
        }
       return resultadoDeOperacion;
    }

    public async actualizarArtista (artistaP){
        console.log("ejecutando actualizacion de artistas");
       
    }

    public async buscarArtistaPorId(idArtista){
        console.log("ejecutando busqueda por id de artistas");

    }

    public async buscarArtistaPorNombre(nombreArtista){
        console.log("ejecutando busqueda por nombre de artistas");

    }

   
}

export let servicioArtistas = new ServicioArtistas();

