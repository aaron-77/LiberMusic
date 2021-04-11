import {getConnection,getRepository,getConnectionManager,createConnection,In} from "typeorm";
import {Cancion} from "../../entity/Cancion";
import {CancionParser} from "../../Parser/CancionParser";
import {v4 as uuidv4} from "uuid";
export class CancionesRepository {

    public  async  crearCancion(cancionJson){
  
         
        try{
            await createConnection();
            
            let  cancion =  CancionParser.jsonToCancion(cancionJson);

            cancion.id =  uuidv4();
            cancion.fkIdAlbum = cancionJson.fkIdAlbum;
            cancion.titulo = cancionJson.titulo; 
            cancion.numeroDeTrack = cancionJson.numeroDeTrack;
            cancion.genero = cancionJson.genero;
            cancion.duracion = cancionJson.duracion;
            cancion.contenidoExplicito = cancionJson.contenidoExplicito;
            cancion.fkIdEstatus = cancionJson.estado;
            const cancionRegistrada =await getConnection().manager.save(cancion);
            console.log("cancion guardada exitosamente: "+cancionRegistrada.titulo);
        }catch(excepcion){
            console.log(excepcion);
        } 
    }

    public async actualizarCancion (cancionP:Cancion):Promise<Cancion>{
            
        try{
            await createConnection();
            const cancion =await getRepository(Cancion).findOne(cancionP.id);
            if(cancion == null){
                return null;
            }
            cancion.id = cancionP.id,
            cancion.fkIdAlbum = cancionP.fkIdAlbum;
            cancion.titulo = cancionP.titulo; 
            cancion.numeroDeTrack = cancionP.numeroDeTrack;
            cancion.genero = cancionP.genero;
            cancion.duracion = cancionP.duracion;
            cancion.contenidoExplicito = cancionP.contenidoExplicito;
            cancion.fkIdEstatus = cancionP.fkIdEstatus;

            await getRepository(Cancion).save(cancion);
            console.log("cancion actualizada exitosamente: "+cancion.titulo);
        }catch(excepcion){
            console.log(excepcion);
        } 
    }

    public async obtenerTodasLasCanciones(cancionesOmitidas:number,numeroDeCancionesEsperadas:number):Promise<Cancion[]>{
        let canciones;

        try{
            await createConnection();
            canciones = getRepository(Cancion).find({skip:cancionesOmitidas,
                                                    take:numeroDeCancionesEsperadas});
        }catch(excepcion){

        }
        return canciones;

    }

    public async obtenerCancionPorId(idCancion:string):Promise<Cancion>{
        let cancion;
        try{   
            await createConnection();
            cancion = await getRepository(Cancion).findOneOrFail({where:{id:idCancion}});
        
        }catch(excepcion){
                console.log(excepcion);
        }
        return cancion;
    }

    public async obtenerCancionPorNombre(nombreCancion:string,
                                        cancionesOmitidas:number,
                                        numeroDeCancionesEsperadas:number):Promise<Cancion[]>{
        let canciones;
        try{   
            await createConnection();
            canciones = await getRepository(Cancion).find({where:{titulo:nombreCancion},
                                                                  skip:cancionesOmitidas,
                                                                  take:numeroDeCancionesEsperadas
                                                          });
        }catch(excepcion){
                console.log(excepcion);
        }
        return canciones;
    }

    public async obtenerCancionPorAlbum(idAlbum:string,
                                        cancionesOmitidas:number,
                                        numeroDeCancionesEsperadas:number):Promise<Cancion[]>{
        let canciones;
        try{   
            await createConnection();
            canciones = await getRepository(Cancion).find({where:{fkIdAlbum:idAlbum},
                                                                  skip:cancionesOmitidas,
                                                                  take:numeroDeCancionesEsperadas
                                                          });
        }catch(excepcion){
                console.log(excepcion);
        }
        return canciones;
    }

    public async obtenerCancionesDeListaDeReproduccion(idCanciones:string[]):Promise<Cancion[]>{
        let canciones;
        try{   
            await createConnection();
            canciones = await getRepository(Cancion).find({id:In(idCanciones)});
        }catch(excepcion){
            console.log(excepcion);
        }
        return canciones;
    }
}

