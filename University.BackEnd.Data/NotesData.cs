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
    public class NotesData : BaseData
    {
        /// <summary>
        /// Constructor de la clase que inicializa la conexión con la base de datos
        /// </summary>
        public NotesData() : base(new SqlConnection(ConfigurationManager.ConnectionStrings["ProdDB"].ConnectionString))
        {
        }

        /// <summary>
        /// Método que se utiliza para hacer Insert en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Add(Notes data)
        {
            using (this._conn)
            {
                this.Open();

                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@NotesID",data.NotesID),
                new SqlParameter("@NotePeriod1",data.NotePeriod1),
                new SqlParameter("@NotePeriod2",data.NotePeriod2),
                new SqlParameter("@ProgramSubjectPersonID",data.ProgramSubjectPerson.ProgramSubjectPersonID),
                 };

                SqlCommand command = new SqlCommand("Operation.prcNotes_ADD", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(param);
                var i = Activator.CreateInstance<Notes>();
                if (command.ExecuteNonQuery() < 1)
                    throw new ApplicationException("El registro no se creó");
            }
        }

        /// <summary>
        /// Método que se utiliza para hacer Delete en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Delete(Notes data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@NotesID",data.NotesID),
                 };

                SqlCommand command = new SqlCommand("Operation.prcNotes_DEL", this._conn);
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
        public void Update(Notes data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@NotesID",data.NotesID),
                new SqlParameter("@NotePeriod1",data.NotePeriod1),
                new SqlParameter("@NotePeriod2",data.NotePeriod2),
                new SqlParameter("@ProgramSubjectPersonID",data.ProgramSubjectPerson.ProgramSubjectPersonID),
                };

                SqlCommand command = new SqlCommand("Operation.prcNotes_UPD", this._conn);
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
        public Notes Get(Guid identifer)
        {
            SqlParameter param = new SqlParameter("@NotesID", identifer);
            SqlDataReader reader = null;
            var entity = Activator.CreateInstance<Notes>();

            using (this._conn)
            {
                this.Open();
                SqlCommand command = new SqlCommand("Operation.prcGetNotes", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(param);
                reader = command.ExecuteReader();

                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            entity.NotesID = SqlClientExtensions.GetSqlGuid(reader, "NotesID");
                            ProgramSubjectPersonData _ProgramSubjectPersonData = new ProgramSubjectPersonData();
                            entity.ProgramSubjectPerson = _ProgramSubjectPersonData.Get(SqlClientExtensions.GetSqlGuid(reader, "ProgramSubjectPersonID"));
                            entity.NotePeriod1 = SqlClientExtensions.GetSqlDecimal(reader, "NotePeriod1");
                            entity.NotePeriod2 = SqlClientExtensions.GetSqlDecimal(reader, "NotePeriod2");
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
        public List<Notes> GetList()
        {
            List<Notes> ListEntities = new List<Notes>();

            SqlDataReader reader = null;
            string prc = "Operation.prcGetNotesList";

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
                            var entity = Activator.CreateInstance<Notes>();

                            entity.NotesID = SqlClientExtensions.GetSqlGuid(reader, "NotesID");
                            ProgramSubjectPersonData _ProgramSubjectPersonData = new ProgramSubjectPersonData();
                            entity.ProgramSubjectPerson = _ProgramSubjectPersonData.Get(SqlClientExtensions.GetSqlGuid(reader, "ProgramSubjectPersonID"));
                            entity.NotePeriod1 = SqlClientExtensions.GetSqlDecimal(reader, "NotePeriod1");
                            entity.NotePeriod2 = SqlClientExtensions.GetSqlDecimal(reader, "NotePeriod2");

                            ListEntities.Add(entity);
                        }
                    }
                }
            }
            return ListEntities;
        }
    }
}