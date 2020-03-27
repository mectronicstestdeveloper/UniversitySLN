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
    public class CityData : BaseData
    {
        /// <summary>
        /// Constructor de la clase que inicializa la conexión con la base de datos
        /// </summary>
        public CityData() : base(new SqlConnection(ConfigurationManager.ConnectionStrings["ProdDB"].ConnectionString))
        {
        }

        /// <summary>
        /// Método que se utiliza para hacer Insert en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Add(City data)
        {
            using (this._conn)
            {
                this.Open();

                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@CityID",data.CityID),
                new SqlParameter("@CityName",data.CityName),
                new SqlParameter("@GeographicalStateID",data.GeographicalState.GeographicalStateID),
                 };

                SqlCommand command = new SqlCommand("Administrative.prcCity_ADD", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(param);
                var i = Activator.CreateInstance<City>();
                if (command.ExecuteNonQuery() < 1)
                    throw new ApplicationException("El registro no se creó");
            }
        }

        /// <summary>
        /// Método que se utiliza para hacer Delete en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Delete(City data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                  new SqlParameter("@CityID",data.CityID)
                 };

                SqlCommand command = new SqlCommand("Administrative.prcCity_DEL", this._conn);
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
        public void Update(City data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@CityID",data.CityID),
                new SqlParameter("@CityName",data.CityName),
                new SqlParameter("@GeographicalStateID",data.GeographicalState.GeographicalStateID),
                };

                SqlCommand command = new SqlCommand("Administrative.prcCity_UPD", this._conn);
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
        public City Get(Guid identifer)
        {
            SqlParameter param = new SqlParameter("@CityID", identifer);
            SqlDataReader reader = null;
            var entity = Activator.CreateInstance<City>();

            using (this._conn)
            {
                this.Open();
                SqlCommand command = new SqlCommand("Administrative.prcGetCity", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(param);
                reader = command.ExecuteReader();

                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            entity.CityID = SqlClientExtensions.GetSqlGuid(reader, "CityID");
                            GeographicalStateData _GeographicalStateData = new GeographicalStateData();
                            entity.GeographicalState = _GeographicalStateData.Get(SqlClientExtensions.GetSqlGuid(reader, "GeographicalStateID"));
                            entity.CityName = SqlClientExtensions.GetSqlString(reader, "CityName");
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
        public List<City> GetList()
        {
            List<City> ListEntities = new List<City>();

            SqlDataReader reader = null;
            string prc = "Administrative.prcGetCityList";

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
                            var entity = Activator.CreateInstance<City>();

                            entity.CityID = SqlClientExtensions.GetSqlGuid(reader, "CityID");
                            GeographicalStateData _GeographicalStateData = new GeographicalStateData();
                            entity.GeographicalState = _GeographicalStateData.Get(SqlClientExtensions.GetSqlGuid(reader, "GeographicalStateID"));
                            entity.CityName = SqlClientExtensions.GetSqlString(reader, "CityName");

                            ListEntities.Add(entity);
                        }
                    }
                }
            }
            return ListEntities;
        }
    }
}