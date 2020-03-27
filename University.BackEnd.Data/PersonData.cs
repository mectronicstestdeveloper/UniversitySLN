using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BackEnd.Entities;

namespace University.BackEnd.Data
{
    /// <summary>
    /// Clase que administra el acceso a datos de la entidad
    /// </summary>
    /// <typeparam name="T">Entidad</typeparam>
    public class PersonData : BaseData
    {
        /// <summary>
        /// Constructor de la clase que inicializa la conexión con la base de datos
        /// </summary>
        public PersonData() : base(new SqlConnection(ConfigurationManager.ConnectionStrings["ProdDB"].ConnectionString))
        {
        }

        /// <summary>
        /// Método que se utiliza para hacer Insert en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Add(Person data)
        {
            using (this._conn)
            {
                this.Open();

                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@PersonID",data.PersonID),
                new SqlParameter("@PersonName",data.PersonName),
                new SqlParameter("@PersonFirstLastName",data.PersonFirstLastName),
                new SqlParameter("@PersonSecondLastName",data.PersonSecondLastName),
                new SqlParameter("@PersonPersonSex",data.PersonPersonSex),
                new SqlParameter("@PersonPersonAddress",data.PersonPersonAddress),
                new SqlParameter("@PersonPersonPhone",data.PersonPersonPhone),
                new SqlParameter("@PersonBirthDate",data.PersonBirthDate),
                new SqlParameter("@CityID",data.City.CityID),
                new SqlParameter("@PersonTypeID",data.PersonType.PersonTypeID),
                 new SqlParameter("@PersonSingUp",data.PersonSingUp),
                 };

                SqlCommand command = new SqlCommand("Personal.prcPerson_ADD", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(param);
                var i = Activator.CreateInstance<Person>();
                if (command.ExecuteNonQuery() < 1)
                    throw new ApplicationException("El registro no se creó");
            }
        }

        /// <summary>
        /// Método que se utiliza para hacer Delete en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Delete(Person data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                  new SqlParameter("@PersonID",data.PersonID)
                 };

                SqlCommand command = new SqlCommand("Personal.prcPerson_DEL", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(param);
                int i = command.ExecuteNonQuery();
                if (i < 1)
                    throw new ApplicationException("El registro no se eliminó");
            }
        }

        /// <summary>
        /// Método que se utiliza para hacer Update en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Update(Person data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@PersonID",data.PersonID),
                new SqlParameter("@PersonName",data.PersonName),
                new SqlParameter("@PersonFirstLastName",data.PersonFirstLastName),
                new SqlParameter("@PersonSecondLastName",data.PersonSecondLastName),
                new SqlParameter("@PersonPersonSex",data.PersonPersonSex),
                new SqlParameter("@PersonPersonAddress",data.PersonPersonAddress),
                new SqlParameter("@PersonPersonPhone",data.PersonPersonPhone),
                new SqlParameter("@PersonBirthDate",data.PersonBirthDate),
                new SqlParameter("@CityID",data.City.CityID),
                new SqlParameter("@PersonTypeID",data.PersonType.PersonTypeID),

                 new SqlParameter("@PersonSingUp",data.PersonSingUp),
                };

                SqlCommand command = new SqlCommand("Personal.prcPerson_UPD", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(param);
                int i = command.ExecuteNonQuery();
                if (i < 1)
                    throw new ApplicationException("El registro no fue actualizado");
            }
        }

        /// <summary>
        /// Método que obtiene el registro por llave primaria de la entidad
        /// </summary>
        /// <param name="identifer">Llave primaria</param>
        /// <returns>Entidad</returns>
        public Person Get(string identifer)
        {
            SqlParameter param = new SqlParameter("@PersonID", identifer);
            SqlDataReader reader = null;
            var entity = Activator.CreateInstance<Person>();

            using (this._conn)
            {
                this.Open();
                SqlCommand command = new SqlCommand("Personal.prcGetPerson", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(param);
                reader = command.ExecuteReader();

                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            entity.PersonID = SqlClientExtensions.GetSqlString(reader, "PersonID");
                            entity.PersonName = SqlClientExtensions.GetSqlString(reader, "PersonName");

                            entity.PersonFirstLastName = SqlClientExtensions.GetSqlString(reader, "PersonFirstLastName");
                            entity.PersonSecondLastName = SqlClientExtensions.GetSqlString(reader, "PersonSecondLastName");
                            entity.PersonPersonSex = SqlClientExtensions.GetSqlString(reader, "PersonSex");
                            entity.PersonPersonAddress = SqlClientExtensions.GetSqlString(reader, "PersonAddress");
                            entity.PersonPersonPhone = SqlClientExtensions.GetSqlString(reader, "PersonPersonPhone");
                            entity.PersonBirthDate = SqlClientExtensions.GetSqlDateTime(reader, "PersonBirthDate");

                            entity.PersonSingUp = SqlClientExtensions.GetSqlDateTime(reader, "PersonSingUp");
                            CityData _CityData = new CityData();
                            entity.City = _CityData.Get(SqlClientExtensions.GetSqlGuid(reader, "CityID"));
                            PersonTypeData _PersonTypeData = new PersonTypeData();
                            entity.PersonType = _PersonTypeData.Get(SqlClientExtensions.GetSqlGuid(reader, "PersonTypeID"));

                            return entity;
                        }
                    }
                }
            }
            return entity;
        }

        /// <summary>
        /// Método que obtiene todos los registros de la entidad
        /// </summary>
        /// <returns>Lista de registros</returns>
        public List<Person> GetList()
        {
            List<Person> ListEntities = new List<Person>();

            SqlDataReader reader = null;
            string prc = "Personal.prcGetPersonList";

            using (this._conn)
            {
                this.Open();
                SqlCommand command = new SqlCommand(prc, this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                reader = command.ExecuteReader();

                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var entity = Activator.CreateInstance<Person>();

                            entity.PersonID = SqlClientExtensions.GetSqlString(reader, "PersonID");
                            entity.PersonName = SqlClientExtensions.GetSqlString(reader, "PersonName");

                            entity.PersonFirstLastName = SqlClientExtensions.GetSqlString(reader, "PersonFirstLastName");
                            entity.PersonSecondLastName = SqlClientExtensions.GetSqlString(reader, "PersonSecondLastName");
                            entity.PersonPersonSex = SqlClientExtensions.GetSqlString(reader, "PersonSex");
                            entity.PersonPersonAddress = SqlClientExtensions.GetSqlString(reader, "PersonAddress");
                            entity.PersonPersonPhone = SqlClientExtensions.GetSqlString(reader, "PersonPersonPhone");
                            entity.PersonBirthDate = SqlClientExtensions.GetSqlDateTime(reader, "PersonBirthDate");

                            entity.PersonSingUp = SqlClientExtensions.GetSqlDateTime(reader, "PersonSingUp");
                            CityData _CityData = new CityData();
                            entity.City = _CityData.Get(SqlClientExtensions.GetSqlGuid(reader, "CityID"));
                            PersonTypeData _PersonTypeData = new PersonTypeData();
                            entity.PersonType = _PersonTypeData.Get(SqlClientExtensions.GetSqlGuid(reader, "PersonTypeID"));

                            ListEntities.Add(entity);
                        }
                    }
                }
            }
            return ListEntities;
        }
    }
}