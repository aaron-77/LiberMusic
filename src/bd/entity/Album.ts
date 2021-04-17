import {Entity, PrimaryGeneratedColumn, Column,BaseEntity,OneToMany,ManyToOne,PrimaryColumn} from "typeorm";
import {Cancion} from "./Cancion";
import {Artista} from "./Artista";
@Entity("albumes")
export class Album extends BaseEntity {
 
    
    @PrimaryColumn("varchar",{length:200})
    
    id: string;

    @Column("varchar",{length:200})
    fkIdArtista :string
    
    @Column("varchar",{length:200})
    titulo: string;

    @Column("int",{unsigned:true,comment:"duracion en segundos de todo el album"})
    duracion :number
    
    @Column("int",{unsigned:true,comment:"duracion en segundos de todo el album"})
    numeroDeTracks :number

    @Column("varchar",{length:200})
    companiaProductora: string;
    
    @Column("varchar",{length:200,comment:"sencillo,edicion especial,etc."})
    tipoDeAlbum: string;

    @Column("date",{nullable:true})
    fechaDeLanzamiento: string;
    
    @Column("int",{unsigned:true,
		          nullable:true,
                   default:1
                  })
    fkIdEstatus: number;

    @ManyToOne((type) => Artista, artista => artista.albumes)
    artista:Artista;

    @OneToMany((type) => Cancion, (cancion) => cancion.album)
    canciones: Cancion[];
    

   
}

