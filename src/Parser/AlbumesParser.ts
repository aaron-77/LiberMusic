import {Album} from "../entity/Album";


export class AlbumParser{

    static jsonToAlbum(albumJson):Album{
       
        let album = new Album();
        album.id = albumJson.id,
        album.fkIdArtista = albumJson.fkIdArtista; 
        album.titulo = albumJson.titulo;
        album.duracion = albumJson.duracion;
        album.numeroDeTracks = albumJson.numeroDeTracks;
        album.companiaProductora = albumJson.companiaProductora;
        album.tipoDeAlbum = albumJson.tipoDeAlbum;
        album.fechaDeLanzamiento = albumJson.fechaDeLanzamiento;
        album.fkIdEstatus = albumJson.fkIdEstatus;
        album.canciones = albumJson.canciones;
        album.artista = albumJson.artista;

        return album;
    }

    static albumToJson(album:Album){
        let albumJson ={
            id: album.id,
            fkIdArtista: album.fkIdArtista, 
            titulo: album.titulo,
            duracion: album.duracion, 
            numeroDeTracks: album.numeroDeTracks, 
            companiaProductora: album.companiaProductora,
            tipoDeAlbum: album.tipoDeAlbum,
            fechaDeLanzamiento: album.fechaDeLanzamiento, 
            fkIfEstatus: album.fkIdEstatus,
            canciones: album.canciones,
            artista :album.artista
        }
        return albumJson;
    }

}
