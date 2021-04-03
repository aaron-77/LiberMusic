/*
    Datos de configuracion de la applicacion
 */

//modulo para manejar rutas del sistema operativo
import * as path           from "path";

//datos de conexion para la base de datos
export const bdhost = process.env.DBHOST;
export const puerto = process.env.PORT;
export const baseDeDatos = process.env.DATABASE;
export const usuariobd = process.env.DBUSER;
export const passwordbd = process.env.DBPASSWORD;


// rutas de almacenamiento de canciones e imagenes de portada de albumes
export const rutascriptStream = path.join(__dirname,'generate-dash.sh');
export const rutaCanciones = path.join(__dirname,'../','artistas','dreamtheater','whendreamanddayunite');
