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
    public class PersonTypeData : BaseData
    {
        /// <summary>
        /// Constructor de la clase que inicializa la conexión con la base de datos
        /// </summary>
        public PersonTypeData() : base(new SqlConnection(ConfigurationManager.ConnectionStrings["ProdDB"].ConnectionString))
        {
        }

        /// <summary>
        /// Método que se utiliza para hacer Insert en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Add(PersonType data)
        {
            using (this._conn)
            {
                this.Open();

                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@PersonTypeID",data.PersonTypeID),
                new SqlParameter("@PersonTypeName",data.PersonTypeName),

                new SqlParameter("@PersonStudent",data.PersonStudent),
                 };

                SqlCommand command = new SqlCommand("Administrative.prcPersonType_ADD", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(param);
                var i = Activator.CreateInstance<PersonType>();
                if (command.ExecuteNonQuery() < 1)
                    throw new ApplicationException("El registro no se creó");
            }
        }

        /// <summary>
        /// Método que se utiliza para hacer Delete en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Delete(PersonType data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                  new SqlParameter("@PersonTypeID",data.PersonTypeID)
                 };

                SqlCommand command = new SqlCommand("Administrative.prcPersonType_DEL", this._conn);
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
        public void Update(PersonType data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@PersonTypeID",data.PersonTypeID),
                new SqlParameter("@PersonTypeName",data.PersonTypeName),
                 new SqlParameter("@PersonStudent",data.PersonStudent),
                };

                SqlCommand command = new SqlCommand("Administrative.prcPersonType_UPD", this._conn);
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
        public PersonType Get(Guid identifer)
        {
            SqlParameter param = new SqlParameter("@PersonTypeID", identifer);
            SqlDataReader reader = null;
            var entity = Activator.CreateInstance<PersonType>();

            using (this._conn)
            {
                this.Open();
                SqlCommand command = new SqlCommand("Administrative.prcGetPersonType", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(param);
                reader = command.ExecuteReader();

                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            entity.PersonTypeID = SqlClientExtensions.GetSqlGuid(reader, "PersonTypeID");
                            entity.PersonTypeName = SqlClientExtensions.GetSqlString(reader, "PersonTypeName");
                            entity.PersonStudent = SqlClientExtensions.GetSqlBoolean(reader, "PersonStudent");
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
        public List<PersonType> GetList()
        {
            List<PersonType> ListEntities = new List<PersonType>();

            SqlDataReader reader = null;
            string prc = "Administrative.prcGetPersonTypeList";

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
                            var entity = Activator.CreateInstance<PersonType>();

                            entity.PersonTypeID = SqlClientExtensions.GetSqlGuid(reader, "PersonTypeID");
                            entity.PersonTypeName = SqlClientExtensions.GetSqlString(reader, "PersonTypeName");

                            entity.PersonStudent = SqlClientExtensions.GetSqlBoolean(reader, "PersonStudent");
                            ListEntities.Add(entity);
                        }
                    }
                }
            }
            return ListEntities;
        }
    }
}