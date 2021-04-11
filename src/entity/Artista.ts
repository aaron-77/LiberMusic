import {Entity, PrimaryGeneratedColumn, Column,BaseEntity,OneToMany, PrimaryColumn} from "typeorm";
import {Album} from "./Album";

@Entity("artistas")
export class Artista extends BaseEntity {
 
    
    @PrimaryColumn("varchar",{length:200})
    id: string;

    @Column("varchar",{length:200
                     ,comment:"nombre real del arista"
                      })
    nombre: string;

    @Column("varchar",{length:200
                      ,comment:"nombre real del arista"
                      })
    nombreArtistico: string;

    @Column("int",{nullable:true})
    anoDeNacimiento: number;

    @Column("longtext")
    web: string;
    
    @Column("varchar",{length:100})
    nacionalidad: string; 

    @Column("int",{ unsigned:true,
	 	            nullable:true,   
                    default:1
                       ,comment:"estado del registro (activo,inactivo)"
                   })
    fkIdEstatus: number;

    

    @OneToMany(type => Album, album => album.artista,{cascade:true})
    albumes: Album[];
    
   
}

