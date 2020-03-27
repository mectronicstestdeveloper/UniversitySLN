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
    public class GeographicalStateData : BaseData
    {
        /// <summary>
        /// Constructor de la clase que inicializa la conexión con la base de datos
        /// </summary>
        public GeographicalStateData() : base(new SqlConnection(ConfigurationManager.ConnectionStrings["ProdDB"].ConnectionString))
        {
        }

        /// <summary>
        /// Método que se utiliza para hacer Insert en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Add(GeographicalState data)
        {
            using (this._conn)
            {
                this.Open();

                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@GeographicalStateID",data.GeographicalStateID),
                new SqlParameter("@GeographicalStateName",data.GeographicalStateName),
                new SqlParameter("@CountryID",data.Country.CountryID),
                 };

                SqlCommand command = new SqlCommand("Administrative.prcGeographicalState_ADD", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(param);
                var i = Activator.CreateInstance<GeographicalState>();
                if (command.ExecuteNonQuery() < 1)
                    throw new ApplicationException("El registro no se creó");
            }
        }

        /// <summary>
        /// Método que se utiliza para hacer Delete en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Delete(GeographicalState data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                  new SqlParameter("@GeographicalStateID",data.GeographicalStateID)
                 };

                SqlCommand command = new SqlCommand("Administrative.prcGeographicalState_DEL", this._conn);
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
        public void Update(GeographicalState data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@GeographicalStateID",data.GeographicalStateID),
                new SqlParameter("@GeographicalStateName",data.GeographicalStateName),
                new SqlParameter("@CountryID",data.Country.CountryID),
                };

                SqlCommand command = new SqlCommand("Administrative.prcGeographicalState_UPD", this._conn);
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
        public GeographicalState Get(Guid identifer)
        {
            SqlParameter param = new SqlParameter("@GeographicalStateID", identifer);
            SqlDataReader reader = null;
            var entity = Activator.CreateInstance<GeographicalState>();

            using (this._conn)
            {
                this.Open();
                SqlCommand command = new SqlCommand("Administrative.prcGetGeographicalState", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(param);
                reader = command.ExecuteReader();

                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            entity.GeographicalStateID = SqlClientExtensions.GetSqlGuid(reader, "GeographicalStateID");
                            CountryData _CountryData = new CountryData();
                            entity.Country = _CountryData.Get(SqlClientExtensions.GetSqlGuid(reader, "CountryID"));
                            entity.GeographicalStateName = SqlClientExtensions.GetSqlString(reader, "GeographicalStateName");
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
        public List<GeographicalState> GetList()
        {
            List<GeographicalState> ListEntities = new List<GeographicalState>();

            SqlDataReader reader = null;
            string prc = "Administrative.prcGetGeographicalStateList";

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
                            var entity = Activator.CreateInstance<GeographicalState>();

                            entity.GeographicalStateID = SqlClientExtensions.GetSqlGuid(reader, "GeographicalStateID");
                            CountryData _CountryData = new CountryData();
                            entity.Country = _CountryData.Get(SqlClientExtensions.GetSqlGuid(reader, "CountryID"));
                            entity.GeographicalStateName = SqlClientExtensions.GetSqlString(reader, "GeographicalStateName");

                            ListEntities.Add(entity);
                        }
                    }
                }
            }
            return ListEntities;
        }
    }
}