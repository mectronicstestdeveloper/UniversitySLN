using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BackEnd.Entities
{
    /// <summary>
    /// Clase que opera sobre la entidad
    /// </summary>
    public class PersonType
    {
        /// <summary>
        /// Atributo que se refiere el identificador de la clase
        /// </summary>
        public Guid PersonTypeID { get; set; }

        /// <summary>
        /// Atributo que se refiere el nombre de la clase
        /// </summary>
        public string PersonTypeName { get; set; }

        /// <summary>
        /// Atributo que se refiere SI ESTUDIANTE
        /// </summary>
        public bool PersonStudent { get; set; }
    }
}