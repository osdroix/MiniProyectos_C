namespace RegistroSeccion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Seccion")]
    public partial class Seccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seccion()
        {
            Alumno = new HashSet<Alumno>();
        }

        [Key]
        public int id_sec { get; set; }

        public int aula_sec { get; set; }

        public int id_cur { get; set; }

        public bool estado_sec { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_registro_sec { get; set; }

        public virtual Curso Curso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumno> Alumno { get; set; }

        //--------Métodos----------

        public List<Seccion> listar()
        {
            var seccion = new List<Seccion>();
            string cadena = "SELECT * FROM SECCION";
            try
            {
                using (var contenedor = new Model1())
                {
                    seccion = contenedor.Database.SqlQuery<Seccion>(cadena).ToList();
                }
            }
            catch (Exception)
            {

                //throw;
            }
            return seccion;
        }

        public Boolean Insertar(string nu, bool es, string fe, int cu, List<string> indices)
        {
            bool estado = false;
            string cadena = "'" + nu + "',";
            cadena = cadena + "'" + cu + "',";
            cadena = cadena + "'" + es + "',";
            cadena = cadena + "'" + fe + "'";
            try
            {
                using (var cnx = new Model1())
                {
                    int r = cnx.Database.ExecuteSqlCommand("INSERT INTO Seccion VALUES(" + cadena + ")");
                    string codigo_libro = "(SELECT MAX(id_sec) FROM Seccion)";
                    if (!indices.Equals(null))
                    {
                        foreach (var i in indices)
                        {
                            cnx.Database.ExecuteSqlCommand("INSERT INTO Detalle_asig_alumno_seccion VALUES(" +
                                codigo_libro + "," + i + ")");
                        }
                    }
                    if (r == 1)
                    {
                        estado = true;
                    }
                }
            }
            catch (Exception)
            {
                estado = false;
                //throw;
            }
            return estado;
        }

        // Busqueda de Alumno
        public List<Alumno> bus_atr(string dato_bus)
        {
            var autores = new List<Alumno>();
            string cadena = "SELECT * FROM Alumno WHERE id_alu LIKE '%" + dato_bus + "%'";
            try
            {
                using (var contenedor = new Model1())
                {
                    autores = contenedor.Database.SqlQuery<Alumno>(cadena).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return autores;
        }
    }
}
