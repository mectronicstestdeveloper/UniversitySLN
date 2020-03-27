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
    public class Person
    {
        /// <summary>
        /// Atributo que se refiere el identificador de la clase
        /// </summary>
        public string PersonID { get; set; }

        /// <summary>
        /// Atributo que se refiere el nombre de la clase
        /// </summary>
        public string PersonName { get; set; }

        /// <summary>
        /// Atributo que se refiere el primer apellido de la clase
        /// </summary>
        public string PersonFirstLastName { get; set; }

        /// <summary>
        /// Atributo que se refiere el segundo apellido de la clase
        /// </summary>
        public string PersonSecondLastName { get; set; }

        /// <summary>
        /// Atributo que se refiere el sexo de la clase
        /// </summary>
        public string PersonPersonSex { get; set; }

        /// <summary>
        /// Atributo que se refiere la direccion de la clase
        /// </summary>
        public string PersonPersonAddress { get; set; }

        /// <summary>
        /// Atributo que se refiere el telefono de la clase
        /// </summary>
        public string PersonPersonPhone { get; set; }

        // <summary>
        /// Atributo que se refiere el año de nacimiento de la clase
        /// </summary>
        public DateTime PersonBirthDate { get; set; }

        /// <summary>
        /// Atributo que se refiere a la entidad City
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Atributo que se refiere a la entidad PersonType
        /// </summary>
        public PersonType PersonType { get; set; }

        /// <summary>
        /// Atributo que se refiere a la fecha de ingreso
        /// </summary>
        public DateTime PersonSingUp { get; set; }
    }
}