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
    public class GeographicalState
    {
        /// <summary>
        /// Atributo que se refiere el identificador de la clase
        /// </summary>
        public Guid GeographicalStateID { get; set; }

        /// <summary>
        /// Atributo que se refiere el nombre de la clase
        /// </summary>
        public string GeographicalStateName { get; set; }

        /// <summary>
        /// Atributo que se refiere a la entidad Country
        /// </summary>
        public Country Country { get; set; }
    }
}