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
    public class CountryData : BaseData
    {
        /// <summary>
        /// Constructor de la clase que inicializa la conexión con la base de datos
        /// </summary>
        public CountryData() : base(new SqlConnection(ConfigurationManager.ConnectionStrings["ProdDB"].ConnectionString))
        {
        }

        /// <summary>
        /// Método que se utiliza para hacer Insert en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Add(Country data)
        {
            using (this._conn)
            {
                this.Open();

                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@CountryID",data.CountryID),
                new SqlParameter("@CountryName",data.CountryName),
                 };

                SqlCommand command = new SqlCommand("Administrative.prcCountry_ADD", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(param);
                var i = Activator.CreateInstance<Country>();
                if (command.ExecuteNonQuery() < 1)
                    throw new ApplicationException("El registro no se creó");
            }
        }

        /// <summary>
        /// Método que se utiliza para hacer Delete en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Delete(Country data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                  new SqlParameter("@CountryID",data.CountryID)
                 };

                SqlCommand command = new SqlCommand("Administrative.prcCountry_DEL", this._conn);
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
        public void Update(Country data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@CountryID",data.CountryID),
                new SqlParameter("@CountryName",data.CountryName),
                };

                SqlCommand command = new SqlCommand("Administrative.prcCountry_UPD", this._conn);
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
        public Country Get(Guid identifer)
        {
            SqlParameter param = new SqlParameter("@CountryID", identifer);
            SqlDataReader reader = null;
            var entity = Activator.CreateInstance<Country>();

            using (this._conn)
            {
                this.Open();
                SqlCommand command = new SqlCommand("Administrative.prcGetCountry", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(param);
                reader = command.ExecuteReader();

                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            entity.CountryID= SqlClientExtensions.GetSqlGuid(reader, "CountryID");
                            entity.CountryName= SqlClientExtensions.GetSqlString(reader, "CountryName");
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
        public List<Country> GetList()
        {
            List<Country> ListEntities = new List<Country>();

            SqlDataReader reader = null;
            string prc = "Administrative.prcGetCountryList";

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
                            var entity = Activator.CreateInstance<Country>();

                            entity.CountryID= SqlClientExtensions.GetSqlGuid(reader, "CountryID");
                            entity.CountryName= SqlClientExtensions.GetSqlString(reader, "CountryName");

                            ListEntities.Add(entity);
                        }
                    }
                }
            }
            return ListEntities;
        }
    }
}