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
    public class ProgramSubjectPerson
    {
        /// <summary>
        /// Atributo que se refiere el identificador de la clase
        /// </summary>
        public Guid ProgramSubjectPersonID { get; set; }

        /// <summary>
        /// Atributo que se refiere el nombre de la clase
        /// </summary>
        public ProgramSubject ProgramSubject { get; set; }

        /// <summary>
        /// Atributo que se refiere el nombre de la clase
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Atributo que se refiere el semestre de la clase
        /// </summary>
        public string Semestre { get; set; }

        /// <summary>
        /// Atributo que se refiere el año de inscripcion de la clase
        /// </summary>
        public DateTime CurrentYear { get; set; }
    }
}