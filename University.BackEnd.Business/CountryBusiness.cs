using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BackEnd.Data;
using University.BackEnd.Entities;

namespace University.BackEnd.Business
{
    public class CountryBusiness : IDisposable
    {
        /// <summary>
        /// Interfaz que operará sobre DAL
        /// </summary>
        private CountryData _data;

        /// <summary>
        /// Instancia Singleton del componente de auditoría
        /// </summary>
        //private AuditComponent auditComponent;

        /// <summary>
        /// Constructor de la clase que inicializa DAL y Auditoría
        /// </summary>
        public CountryBusiness()
        {
            this._data = new CountryData();
            //this.auditComponent = AuditComponent.Instance;
        }

        /// <summary>
        /// Método que aplicará las reglase de negocio antes de ejecutar el método de agregar en DAL
        /// </summary>
        /// <param name="element">Elemento de la entidad</param>
        /// <returns></returns>
        public void Add(Country element)
        {
            this._data.Add(element);
        }

        /// <summary>
        /// Método que aplicará las reglase de negocio antes de ejecutar el método de actualizar en DAL
        /// </summary>
        /// <param name="element">Elemento de la entidad</param>
        /// <returns></returns>
        public void Update(Country element)
        {
            this._data.Update(element);
        }

        /// <summary>
        /// Método que aplicará las reglase de negocio antes de ejecutar el método de eliminar en DAL
        /// </summary>
        /// <param name="element">Elemento de la entidad</param>
        /// <returns></returns>
        public void Delete(Country element)
        {
            this._data.Delete(element);
        }

        /// <summary>
        ///  Método que aplicará las reglase de negocio antes de ejecutar el método de obtener por llave primaria en DAL
        /// </summary>
        /// <param name="Identifier">Llave primaria</param>
        /// <returns>Entidad</returns>
        public Country Get(Guid Identifier)
        {
            Country data = this._data.Get(Identifier);
            return data;
        }

        /// <summary>
        /// Método que aplicará las reglase de negocio antes de ejecutar el método de obtener todos los registros en DAL
        /// </summary>
        /// <returns>Lista de Registros</returns>
        public List<Country> GetList()
        {
            List<Country> data = this._data.GetList();
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