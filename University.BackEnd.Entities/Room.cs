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
    public class Room
    {
        /// <summary>
        /// Atributo que se refiere el identificador de la clase
        /// </summary>
        public Guid RoomID { get; set; }

        /// <summary>
        /// Atributo que se refiere el nombre de la clase
        /// </summary>
        public string RoomName { get; set; }
    }
}