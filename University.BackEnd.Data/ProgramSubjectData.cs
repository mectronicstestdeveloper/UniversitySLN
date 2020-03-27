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
    public class ProgramSubjectData : BaseData
    {
        /// <summary>
        /// Constructor de la clase que inicializa la conexión con la base de datos
        /// </summary>
        public ProgramSubjectData() : base(new SqlConnection(ConfigurationManager.ConnectionStrings["ProdDB"].ConnectionString))
        {
        }

        /// <summary>
        /// Método que se utiliza para hacer Insert en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Add(ProgramSubject data)
        {
            using (this._conn)
            {
                this.Open();

                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ProgramSubjectID",data.ProgramSubjectID),
                new SqlParameter("@ProgramID",data.Program.ProgramID),
                new SqlParameter("@SubjectID",data.Subject.SubjectID),
                 };

                SqlCommand command = new SqlCommand("Administrative.prcProgramSubject_ADD", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(param);
                var i = Activator.CreateInstance<ProgramSubject>();
                if (command.ExecuteNonQuery() < 1)
                    throw new ApplicationException("El registro no se creó");
            }
        }

        /// <summary>
        /// Método que se utiliza para hacer Delete en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Delete(ProgramSubject data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                  new SqlParameter("@ProgramSubjectID",data.ProgramSubjectID)
                 };

                SqlCommand command = new SqlCommand("Administrative.prcProgramSubject_DEL", this._conn);
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
        public void Update(ProgramSubject data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ProgramSubjectID",data.ProgramSubjectID),
                new SqlParameter("@ProgramID",data.Program.ProgramID),
                new SqlParameter("@SubjectID",data.Subject.SubjectID),
                };

                SqlCommand command = new SqlCommand("Administrative.prcProgramSubject_UPD", this._conn);
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
        public ProgramSubject Get(Guid identifer)
        {
            SqlParameter param = new SqlParameter("@Program_SubjectID", identifer);
            SqlDataReader reader = null;
            var entity = Activator.CreateInstance<ProgramSubject>();

            using (this._conn)
            {
                this.Open();
                SqlCommand command = new SqlCommand("Administrative.prcGetProgram_Subject", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(param);
                reader = command.ExecuteReader();

                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            entity.ProgramSubjectID = SqlClientExtensions.GetSqlGuid(reader, "ProgramSubjectID");
                            ProgramData _ProgramData = new ProgramData();
                            entity.Program = _ProgramData.Get(SqlClientExtensions.GetSqlGuid(reader, "ProgramID"));
                            SubjectData _SubjectData = new SubjectData();
                            entity.Subject = _SubjectData.Get(SqlClientExtensions.GetSqlGuid(reader, "SubjectID"));

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
        public List<ProgramSubject> GetList()
        {
            List<ProgramSubject> ListEntities = new List<ProgramSubject>();

            SqlDataReader reader = null;
            string prc = "Administrative.prcGetProgram_SubjectList";

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
                            var entity = Activator.CreateInstance<ProgramSubject>();

                            entity.ProgramSubjectID = SqlClientExtensions.GetSqlGuid(reader, "ProgramSubjectID");
                            ProgramData _ProgramData = new ProgramData();
                            entity.Program = _ProgramData.Get(SqlClientExtensions.GetSqlGuid(reader, "ProgramID"));
                            SubjectData _SubjectData = new SubjectData();
                            entity.Subject = _SubjectData.Get(SqlClientExtensions.GetSqlGuid(reader, "SubjectID"));

                            ListEntities.Add(entity);
                        }
                    }
                }
            }
            return ListEntities;
        }
    }
}