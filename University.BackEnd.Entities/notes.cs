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
    public class Notes
    {
        /// <summary>
        /// Atributo que se refiere el identificador de la clase
        /// </summary>
        public Guid NotesID { get; set; }

        /// <summary>
        /// Atributo que se refiere el nombre de la clase
        /// </summary>
        public decimal NotePeriod1 { get; set; }

        /// <summary>
        /// Atributo que se refiere el nombre de la clase
        /// </summary>
        public decimal NotePeriod2 { get; set; }

        /// <summary>
        /// Atributo que se refiere a la entidad ProgramSubjectPerson
        /// </summary>
        public ProgramSubjectPerson ProgramSubjectPerson { get; set; }
    }
}