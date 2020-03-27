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
    public class ProgramSubjectPersonData : BaseData
    {
        /// <summary>
        /// Constructor de la clase que inicializa la conexión con la base de datos
        /// </summary>
        public ProgramSubjectPersonData() : base(new SqlConnection(ConfigurationManager.ConnectionStrings["ProdDB"].ConnectionString))
        {
        }

        /// <summary>
        /// Método que se utiliza para hacer Insert en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Add(ProgramSubjectPerson data)
        {
            using (this._conn)
            {
                this.Open();

                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ProgramSubjectPersonID",data.ProgramSubjectPersonID),
                new SqlParameter("@ProgramSubjectID",data.ProgramSubject.ProgramSubjectID),
                new SqlParameter("@PersonID",data.Person.PersonID),
                new SqlParameter("@CurrentYear",data.CurrentYear),
                new SqlParameter("@Semestre",data.Semestre),
                 };

                SqlCommand command = new SqlCommand("Operation.prcProgramSubjectPerson_ADD", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(param);
                var i = Activator.CreateInstance<ProgramSubjectPerson>();
                if (command.ExecuteNonQuery() < 1)
                    throw new ApplicationException("El registro no se creó");
            }
        }

        /// <summary>
        /// Método que se utiliza para hacer Delete en la entidad
        /// </summary>
        /// <param name="data">Entidad</param>
        public void Delete(ProgramSubjectPerson data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                  new SqlParameter("@ProgramSubjectPersonID",data.ProgramSubjectPersonID)
                 };

                SqlCommand command = new SqlCommand("Operation.prcProgramSubjectPerson_DEL", this._conn);
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
        public void Update(ProgramSubjectPerson data)
        {
            using (this._conn)
            {
                this.Open();
                //componer parámetros
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ProgramSubjectPersonID",data.ProgramSubjectPersonID),
                new SqlParameter("@ProgramSubjectID",data.ProgramSubject.ProgramSubjectID),
                new SqlParameter("@PersonID",data.Person.PersonID),
                new SqlParameter("@CurrentYear",data.CurrentYear),
                new SqlParameter("@Semestre",data.Semestre),
                };

                SqlCommand command = new SqlCommand("Operation.prcProgramSubjectPerson_UPD", this._conn);
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
        public ProgramSubjectPerson Get(Guid identifer)
        {
            SqlParameter param = new SqlParameter("@ProgramSubjectPersonID", identifer);
            SqlDataReader reader = null;
            var entity = Activator.CreateInstance<ProgramSubjectPerson>();

            using (this._conn)
            {
                this.Open();
                SqlCommand command = new SqlCommand("Operation.prcGetProgram_Subject_Person", this._conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(param);
                reader = command.ExecuteReader();

                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            entity.ProgramSubjectPersonID = SqlClientExtensions.GetSqlGuid(reader, "ProgramSubjectPersonID");
                            ProgramSubjectData _ProgramSubjectData = new ProgramSubjectData();
                            entity.ProgramSubject = _ProgramSubjectData.Get(SqlClientExtensions.GetSqlGuid(reader, "ProgramSubjectID"));
                            PersonData _PersonData = new PersonData();
                            entity.Person = _PersonData.Get(SqlClientExtensions.GetSqlString(reader, "PersonID"));
                            entity.Semestre = SqlClientExtensions.GetSqlString(reader, "Semestre");
                            entity.CurrentYear = SqlClientExtensions.GetSqlDateTime(reader, "CurrentYear");
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
        public List<ProgramSubjectPerson> GetList()
        {
            List<ProgramSubjectPerson> ListEntities = new List<ProgramSubjectPerson>();

            SqlDataReader reader = null;
            string prc = "Operation.prcGetProgram_Subject_PersonList";

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
                            var entity = Activator.CreateInstance<ProgramSubjectPerson>();

                            entity.ProgramSubjectPersonID = SqlClientExtensions.GetSqlGuid(reader, "Program_Subject_PersonID");
                            ProgramSubjectData _ProgramSubjectData = new ProgramSubjectData();
                            entity.ProgramSubject = _ProgramSubjectData.Get(SqlClientExtensions.GetSqlGuid(reader, "Program_SubjectID"));
                            PersonData _PersonData = new PersonData();
                            entity.Person = _PersonData.Get(SqlClientExtensions.GetSqlString(reader, "PersonID"));
                            entity.Semestre = SqlClientExtensions.GetSqlString(reader, "Semestre");
                            entity.CurrentYear = SqlClientExtensions.GetSqlDateTime(reader, "CurrentYear");
                            ListEntities.Add(entity);
                        }
                    }
                }
            }
            return ListEntities;
        }
    }
}