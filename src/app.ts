import "reflect-metadata";
import * as path       from 'path';
var express = require('express');
import morgan from 'morgan';
import * as bodyParser from 'body-parser';
import {artistasApi} from "./api/ArtistasApi";
import {ListaReproduccionApi} from "./api/ListaReproduccionApi";
import { ListaReproduccion } from "./bd/entity/ListaReproduccion";


 class App{

    express : any;
    upload : any;
 

    constructor(){
        //inicializa la conexion a bd , asi esta disponible en toda la app aunque no se use explicitamente aqui
  
        this.express = express();
        this.middleware();
        this.routes();
    }

    private middleware(): void{

        this.express.use(morgan('dev'));
      

    }

    private routes(){

        let RootRouter = express.Router();
        RootRouter.get('/',(req,res,next) =>{
            res.json({
                message:'B'

            });

        });
        this.express.use('/',RootRouter);
        this.express.use('/artistas',artistasApi);
        //this.express.use('/albumes',);
        //this.express.use('/canciones', );
        this.express.use('ListaDeReproduccion', ListaReproduccionApi)
        //this.express.use('/streaming', );
        //this.express.use('*',);

    }


}

export default new App().express;