import {getConnection,getRepository,getConnectionManager,createConnection} from "typeorm";
import {Album} from "../../entity/Album";
import {AlbumParser} from "../../Parser/AlbumesParser";
import {Cancion} from "../../entity/Cancion";
import {Artista} from "../../entity/Artista";
import {v4 as uuidv4} from "uuid";
export class AlbumesRepository {

    public  async  crearAlbum(datosalbum){
  
         
        try{
            await createConnection();
            
           let  album =  AlbumParser.jsonToAlbum(datosalbum);
    
            album.id = uuidv4();
            album.fkIdArtista = datosalbum.fkIdArtista; 
            album.titulo = datosalbum.titulo;
            album.duracion = datosalbum.duracion;
            album.numeroDeTracks = datosalbum.numeroDeTracks;
            album.companiaProductora = datosalbum.companiaProductora;
            album.tipoDeAlbum = datosalbum.tipoDeAlbum;
            album.fechaDeLanzamiento = datosalbum.fechaDeLanzamiento;
          
            if(album.canciones == (undefined|| null))
            {

            }
            const albumRegistrado =await getConnection().manager.save(album);
            console.log("album guardado exitosamente: "+albumRegistrado.titulo);
        }catch(excepcion){
            console.log(excepcion);
        } 
    }

    public async actualizarAlbum (albumP:Album):Promise<Album>{
            
        try{
            await createConnection();
            const album =await getRepository(Album).findOne(albumP.id);
            if(album == null){
                return null;
            }
            album.fkIdArtista = albumP.fkIdArtista; 
            album.titulo = albumP.titulo;
            album.duracion = albumP.duracion;
            album.numeroDeTracks = albumP.numeroDeTracks;
            album.companiaProductora = albumP.companiaProductora;
            album.tipoDeAlbum = albumP.tipoDeAlbum;
            album.fechaDeLanzamiento = albumP.fechaDeLanzamiento;
            album.fkIdEstatus = albumP.fkIdEstatus;
            await getRepository(Album).save(album);
            console.log("album actualizado exitosamente: "+albumP.titulo);
        }catch(excepcion){
            console.log(excepcion);
        } 
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

    public async obtenerCanciones():Promise<Album[]>{
        await createConnection();

        //let album3 = await getRepository(Album).findOne(3);
        let artistas = await getRepository(Artista).find({ relations: ["albumes"] });
        let  album  =await artistas[2].albumes;
        
        //let artistaalbum3 = await album3.
        //let canicon =  await getRepository(Cancion).createQueryBuilder("cancion").leftJoinAndSelect("cancion.album","canciones").where("cancion.id= :id",{id:1}).getOne();
        //let album = canicon.album;
        console.log(album);
        let albumess :Promise<Album[]> ;
        
        return albumess;
    }
}

