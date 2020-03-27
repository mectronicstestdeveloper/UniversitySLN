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
    public class RoomSubjectData : BaseData
    {
        /// <summary>
        /// Constructor de la clase que inicializa la conexión con la base de datos
        /// </summary>
        public RoomSubjectData() : base(new SqlConnection(ConfigurationManager.ConnectionStrings["ProdDB"].ConnectionString))
        {
        }

        /// <summary>
        /// Método que se utiliza para hacer Insert en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Add(RoomSubject data)
        {
            using (this._conn)
            {
                this.Open();

                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@RoomSubjectID",data.RoomSubjectID),
                new SqlParameter("@RoomID",data.Room.RoomID),
                new SqlParameter("@ProgramSubjectPersonID",data.ProgramSubjectPerson.ProgramSubjectPersonID),
                 };

                SqlCommand command = new SqlCommand("Operation.prcRoomSubject_ADD", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(param);
                var i = Activator.CreateInstance<RoomSubject>();
                if (command.ExecuteNonQuery() < 1)
                    throw new ApplicationException("El registro no se creó");
            }
        }

        /// <summary>
        /// Método que se utiliza para hacer Delete en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Delete(RoomSubject data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                  new SqlParameter("@RoomSubjectID",data.RoomSubjectID)
                 };

                SqlCommand command = new SqlCommand("Operation.prcRoomSubject_DEL", this._conn);
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
        public void Update(RoomSubject data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@RoomSubjectID",data.RoomSubjectID),
                new SqlParameter("@RoomID",data.Room.RoomID),
                new SqlParameter("@ProgramSubjectPersonID",data.ProgramSubjectPerson.ProgramSubjectPersonID),
                };

                SqlCommand command = new SqlCommand("Operation.prcRoomSubject_UPD", this._conn);
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
        public RoomSubject Get(Guid identifer)
        {
            SqlParameter param = new SqlParameter("@RoomSubjectID", identifer);
            SqlDataReader reader = null;
            var entity = Activator.CreateInstance<RoomSubject>();

            using (this._conn)
            {
                this.Open();
                SqlCommand command = new SqlCommand("Operation.prcGetRoomSubject", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(param);
                reader = command.ExecuteReader();

                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            entity.RoomSubjectID = SqlClientExtensions.GetSqlGuid(reader, "RoomSubjectID");
                            RoomData _RoomData = new RoomData();
                            entity.Room = _RoomData.Get(SqlClientExtensions.GetSqlGuid(reader, "RoomID"));
                            ProgramSubjectPersonData _ProgramSubjectPersonData = new ProgramSubjectPersonData();
                            entity.ProgramSubjectPerson = _ProgramSubjectPersonData.Get(SqlClientExtensions.GetSqlGuid(reader, "ProgramSubjectPersonID"));
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
        public List<RoomSubject> GetList()
        {
            List<RoomSubject> ListEntities = new List<RoomSubject>();

            SqlDataReader reader = null;
            string prc = "Operation.prcGetRoomSubjectList";

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
                            var entity = Activator.CreateInstance<RoomSubject>();

                            entity.RoomSubjectID = SqlClientExtensions.GetSqlGuid(reader, "RoomSubjectID");
                            RoomData _RoomData = new RoomData();
                            entity.Room = _RoomData.Get(SqlClientExtensions.GetSqlGuid(reader, "RoomID"));
                            ProgramSubjectPersonData _ProgramSubjectPersonData = new ProgramSubjectPersonData();
                            entity.ProgramSubjectPerson = _ProgramSubjectPersonData.Get(SqlClientExtensions.GetSqlGuid(reader, "ProgramSubjectPersonID"));
                            ListEntities.Add(entity);
                        }
                    }
                }
            }
            return ListEntities;
        }
    }
}