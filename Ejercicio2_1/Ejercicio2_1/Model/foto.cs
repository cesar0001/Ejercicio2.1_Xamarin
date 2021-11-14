using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio2_1.Model
{
    public class foto
    {

        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        public string base_64 { get; set; }

        [MaxLength(200)]
        public string nombre { get; set; }

        [MaxLength(200)]
        public string descripcion { get; set; }

    }
}
