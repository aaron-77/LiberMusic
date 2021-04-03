import {getConnection,getRepository,getConnectionManager,createConnection} from "typeorm";
import {Artista} from "../../entity/Artista";


export class ArtistasRepository {

    public  async  crearArtista(datosartista){
  
         
        try{
            await createConnection();
            
           let  artista = new Artista()
            artista.nombre = datosartista.nombre;
            artista.nombreArtistico = datosartista.nombreArtistico;
            artista.fechaDeNacimiento = datosartista.fechaDeNacimiento;
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
            artista.fechaDeNacimiento = artistaP.fechaDeNacimiento;
            artista.nacionalidad = artistaP.nacionalidad;
            artista.web = artistaP.web;
            artista.estado = artistaP.estado;
            await getRepository(Artista).save(artistaP);
            console.log("artista actualizado exitosamente: "+artistaP.nombre);
        }catch(excepcion){
            console.log(excepcion);
        } 


    }
}

