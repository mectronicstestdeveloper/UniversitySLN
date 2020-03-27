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
    public class ProgramSubject
    {
        /// <summary>
        /// Atributo que se refiere el identificador de la clase
        /// </summary>
        public Guid ProgramSubjectID { get; set; }

        /// <summary>
        /// Atributo que se refiere el nombre de la clase
        /// </summary>
        public Program Program { get; set; }

        /// <summary>
        /// Atributo que se refiere el nombre de la clase
        /// </summary>
        public Subject Subject { get; set; }
    }
}