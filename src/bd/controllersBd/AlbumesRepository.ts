import {getConnection,getRepository,getConnectionManager,createConnection,} from "typeorm";
import {Album} from "../entity/Album";
import {AlbumParser} from "../../Utilities/Parser/AlbumesParser";
import {Cancion} from "../entity/Cancion";
import {Artista} from "../entity/Artista";
import {MensajesManager} from "../../Utilities/MensajesManager/MensajesManager";
import {v4 as uuidv4} from "uuid";
import {validateOrReject} from "class-validator";

export class AlbumesRepository {

    public  async  crearAlbum(album:Album):Promise<any>{
  
         
        try{
            await createConnection();
        
            album.id = uuidv4();
            album.fkIdArtista = album.fkIdArtista; 
            album.titulo = album.titulo;
            album.duracion = album.duracion;
            album.numeroDeTracks = album.numeroDeTracks;
            album.companiaProductora = album.companiaProductora;
            album.tipoDeAlbum = album.tipoDeAlbum;
            album.fechaDeLanzamiento = album.fechaDeLanzamiento;
            album.fkIdEstatus=1;
            try{
                validateOrReject(album);
            }catch(excepcionDeValidacion){
                return MensajesManager.crearMensajeDeErrorDeValidacion(excepcionDeValidacion);
            }
            const albumRegistrado =await getConnection().manager.save(album);
         
        }catch(excepcion){
           MensajesManager.crearMensajeDeError(excepcion);
        } 

        return MensajesManager.crearMensajeDeExito("album creado con exito",album);
    }

    public async actualizarAlbum (albumP:Album):Promise<any>{
        let album;    
        try{
            await createConnection();
         album =await getRepository(Album).findOne(albumP.id);
            if(album == null){
                return MensajesManager.crearMensajeDeErrorDeValidacion(null);
            }
            album.fkIdArtista = albumP.fkIdArtista; 
            album.titulo = albumP.titulo;
            album.duracion = albumP.duracion;
            album.numeroDeTracks = albumP.numeroDeTracks;
            album.companiaProductora = albumP.companiaProductora;
            album.tipoDeAlbum = albumP.tipoDeAlbum;
            album.fechaDeLanzamiento = albumP.fechaDeLanzamiento;
            album.fkIdEstatus = albumP.fkIdEstatus;
            try{
                validateOrReject(album);
            }catch(excepcionDeValidacion){
                return MensajesManager.crearMensajeDeErrorDeValidacion(excepcionDeValidacion);
            }
            await getRepository(Album).save(album);
          
        }catch(excepcion){
            return MensajesManager.crearMensajeDeError(excepcion);
        } 
        return MensajesManager.crearMensajeDeExito("album creado con exito",album);
    }

    public async obtenerAlbumPorId(idAlbum:string):Promise<Album>{
        let album;
        try{
            
            await createConnection();
            album = await getRepository(Album).findOneOrFail({where:{id:idAlbum}});
        
            
        }catch(excepcion){
                console.log(excepcion);
        }
        
        return album;

    }

    public async obtenerAlbumPorNombre(nombreAlbum : string){
        let album = null;
        
        try{
            await createConnection();
            album = await getRepository(Album).findOneOrFail({where:{titulo:nombreAlbum}});
        }catch(excepcion){
            console.log(excepcion);
        }
       
        return album;

    }

    public async obtenerAlbumesPorIdArtista(idArtista:string):Promise<Album[]>{
        let albumesDeArtista
        await createConnection();
        try{
            albumesDeArtista = await getRepository(Album).find({where:{fkIdArtista:idArtista}});
        }catch(excepcion){
                console.log(excepcion);
                albumesDeArtista = null;
        }
    
        return albumesDeArtista;
    }

   
}

