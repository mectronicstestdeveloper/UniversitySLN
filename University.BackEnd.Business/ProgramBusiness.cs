using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BackEnd.Data;
using University.BackEnd.Entities;

namespace University.BackEnd.Business
{
    public class ProgramBusiness : IDisposable
    {
        /// <summary>
        /// Interfaz que operará sobre DAL
        /// </summary>
        private ProgramData _data;

        /// <summary>
        /// Instancia Singleton del componente de auditoría
        /// </summary>
        //private AuditComponent auditComponent;

        /// <summary>
        /// Constructor de la clase que inicializa DAL y Auditoría
        /// </summary>
        public ProgramBusiness()
        {
            this._data = new ProgramData();
            //this.auditComponent = AuditComponent.Instance;
        }

        /// <summary>
        /// Método que aplicará las reglase de negocio antes de ejecutar el método de agregar en DAL
        /// </summary>
        /// <param name="element">Elemento de la entidad</param>
        /// <returns></returns>
        public void Add(Program element)
        {
            this._data.Add(element);
        }

        /// <summary>
        /// Método que aplicará las reglase de negocio antes de ejecutar el método de actualizar en DAL
        /// </summary>
        /// <param name="element">Elemento de la entidad</param>
        /// <returns></returns>
        public void Update(Program element)
        {
            this._data.Update(element);
        }

        /// <summary>
        /// Método que aplicará las reglase de negocio antes de ejecutar el método de eliminar en DAL
        /// </summary>
        /// <param name="element">Elemento de la entidad</param>
        /// <returns></returns>
        public void Delete(Program element)
        {
            this._data.Delete(element);
        }

        /// <summary>
        ///  Método que aplicará las reglase de negocio antes de ejecutar el método de obtener por llave primaria en DAL
        /// </summary>
        /// <param name="Identifier">Llave primaria</param>
        /// <returns>Entidad</returns>
        public Program Get(Guid Identifier)
        {
            Program data = this._data.Get(Identifier);
            return data;
        }

        /// <summary>
        /// Método que aplicará las reglase de negocio antes de ejecutar el método de obtener todos los registros en DAL
        /// </summary>
        /// <returns>Lista de Registros</returns>
        public List<Program> GetList()
        {
            List<Program> data = this._data.GetList();
            return data;
        }

        /// <summary>
        /// Atributo que me permite determinar si la instancia debe cerrarse.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Método que me permite cerrar la instancia del DAL
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._data.Dispose();
                }
                this._data = null;
                disposedValue = true;
            }
        }

        /// <summary>
        /// Método que me permite cerrar Instancia del objeto
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}