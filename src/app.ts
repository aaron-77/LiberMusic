import "reflect-metadata";
import * as path       from 'path';
var express = require('express');
import * as logger from 'morgan';
import * as bodyParser from 'body-parser';


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

        this.express.use(logger('dev'));
      

        // Static files
        //this.express.use(express.static('public'));
        //this.express.use("/images", express.static(path.join(__dirname, "../storage/images")));
        //this.express.use("/artistas", express.static(path.join(__dirname, "../storage/audio")));
        // Headers, allow CORS
        /*
        this.express.use((req, res, next) => {
            console.log("CABECERAS");
            res.header("Access-Control-Allow-Origin", "*");
            res.header("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
            res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Authorization");
            next();

            
        });¨
        */
    }

    private routes(){

        let RootRouter = express.Router();
        RootRouter.get('/',(req,res,next) =>{
            res.json({
                message:'Welcome to the jungle'

            });

        });
        this.express.use('/',RootRouter);
        this.express.use('/artistas',);
        this.express.use('/albumes',);
        this.express.use('/canciones', );
        this.express.use('/streaming', );

    }


}

export default new App().express;