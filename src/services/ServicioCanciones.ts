import {getConnection,getRepository,getConnectionManager,createConnection} from "typeorm";
import {Album} from "../bd/entity/Album";
//import {AlbumParser} from "../../Parser/AlbumesParser";
//import {Cancion} from "../../entity/Cancion";
//import {Artista} from "../../entity/Artista";
//import {v4 as uuidv4} from "uuid";
export class ServicioCanciones {

    public  async  crearAlbum(datosalbum){
  
     
    }

    public async actualizarAlbum (albumP:Album){
            
     
    }

    public async obtenerAlbumPorId(idAlbum:string){
       

    }

    public async obtenerAlbumPorNombre(nombreAlbum : string){
        
    }

    public async obtenerAlbumesPorIdArtista(idArtista:string){
      
    }

    public async obtenerCanciones(){
    }
}

