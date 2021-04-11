import {getConnection,getRepository,getConnectionManager,createConnection} from "typeorm";
import {Artista} from "../../entity/Artista";
import {Album} from "../../entity/Album";
import {v4 as uuidv4} from "uuid";


export class ArtistasRepository {

    public  async  crearArtista(datosartista){
  
         
        try{
            await createConnection();
            
           let  artista = new Artista()
            artista.id = uuidv4();
	    artista.nombre = datosartista.nombre;
            artista.nombreArtistico = datosartista.nombreArtistico;
            artista.anoDeNacimiento = datosartista.anoDeNacimiento;
            artista.nacionalidad = datosartista.nacionalidad;
            artista.web = datosartista.web;
            const user =await getConnection().manager.save(artista);
         
            console.log("artista guardado exitosamente: "+artista.nombre);
        }catch(excepcion){
            console.log(excepcion);
        } 
    }

    public async actualizarArtista (artistaP:Artista):Promise<Artista>{
            
        try{
            await createConnection();
            const artista =await getRepository(Artista).findOne(artistaP.id);
            if(artista == null){
                return null;
            }
            
            artista.nombre = artistaP.nombre;
            artista.nombreArtistico = artistaP.nombreArtistico;
            artista.anoDeNacimiento = artistaP.anoDeNacimiento;
            artista.web = artistaP.web;
            artista.nacionalidad = artistaP.nacionalidad;
            artista.fkIdEstatus = artistaP.fkIdEstatus;
            await getRepository(Artista).save(artistaP);
            console.log("artista actualizado exitosamente: "+artistaP.nombre);
        }catch(excepcion){
            console.log(excepcion);
        } 

    }

    public async buscarArtistaPorId(idArtista:string):Promise<Artista>{
        
        
        let result:Artista;
        try{
            await createConnection();
            const artista = await getRepository(Artista).findOneOrFail({where:{id:idArtista}});
            result = artista;
            
        }catch(excepcion){
                console.log(excepcion);
                result = null;
        }
        
        return result;

    }

    public async buscarArtistaPorNombre(nombreArtista:string):Promise<Artista>{
        
       
        let artista = null;
        
        try{
            await createConnection();
            artista = await getRepository(Artista).findOneOrFail({where:{nombreArtistico:nombreArtista}});
        }catch(excepcion){
            console.log(excepcion);
            artista = null;
        }
       
       
        return artista;

    }


   
}

