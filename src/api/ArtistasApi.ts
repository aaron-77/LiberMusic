import { Router, Request, Response,NextFunction,Express } from "express";
import express from 'express';
import {servicioArtistas} from '../services/ServicioArtistas';





class ArtistasApi {
    
    router: Router;
    storage: any;
    upload: any;
    app:Express;
 

    constructor() {
     
        this.app = express();
        this.router = Router();
        this.routes();
       


    }
    routes(): void {   
        this.router.post('/crear',express.json(),this.registrarArtista); // ?ids=12345...,23426...,63464....
        this.router.put('/actualizar',express.json() ,this.actualizarArtista);
        this.router.get('/buscar',express.json() ,this.buscarArtistaPorId);
    }

    async registrarArtista(req: any, res: any, nextFunction: NextFunction) {
        try {
                  
            await servicioArtistas.registrarArtista(req.body);

        } catch (error) {
            console.log(error);
        }
    }

    async actualizarArtista(req: any, res: any, nextFunction: NextFunction) {
        try {
            await servicioArtistas.actualizarArtista(req.body);
        } catch (error) {
            console.log(error);
        }
    }

    async buscarArtistaPorId(req: any, res: any, nextFunction: NextFunction) {
        try{
            if(req.query.idArtista != undefined){
                await servicioArtistas.buscarArtistaPorId(req.query.idArtista);
            }else if(req.query.nombreArtista != undefined){
                await servicioArtistas.buscarArtistaPorNombre(req.query.nombreArtista);
            }
        }catch(error){
            console.log(error)
        }

    }

}
export let artistasApi = new ArtistasApi().router;

