import {Entity, PrimaryGeneratedColumn, Column,BaseEntity} from "typeorm";

@Entity("artistas")
export class Artista extends BaseEntity {
 
    
    @PrimaryGeneratedColumn({unsigned:true})
    id: number;

    @Column("varchar",{length:200
                     ,comment:"nombre real del arista"
                      })
    nombre: string;

    @Column("varchar",{length:200
                      ,comment:"nombre real del arista"
                      })
    nombreArtistico: string;

    @Column("date")
    fechaDeNacimiento: string;

    @Column("longtext")
    web: string;

    @Column("varchar",{length:20
                       ,default:"activo"
                       ,comment:"nombre real del arista"
                      })
    estado: string;

    @Column("varchar",{length:100})
    nacionalidad: string;
    
   
}

