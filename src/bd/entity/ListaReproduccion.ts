import {Entity, PrimaryGeneratedColumn, Column,BaseEntity,OneToMany,ManyToOne,PrimaryColumn} from "typeorm";
import { usuariobd } from "../../config/global";
import {Cancion} from "./Cancion";
@Entity("ListaReproduccion")
export class ListaReproduccion extends BaseEntity {
 
    
    @PrimaryColumn("varchar",{length:200})

    
    id: string;

    @Column("varchar",{length:200})
    fkIdUsuario :string;
    
    @Column("varchar",{length:200})
    nombre: string;

    @Column("int")
    numeroDeTracks :number;

       
    @Column("int",{unsigned:true,
		          nullable:false,
                   default:1
                  })
    fkIdEstatus: number;

    /*@ManyToOne((type) => , usuario => usuario.id)
    artista:Artista;

    @OneToMany((type) => Cancion, (cancion) => cancion.id)
    canciones: ListaReproduccion[];
    */

   
}