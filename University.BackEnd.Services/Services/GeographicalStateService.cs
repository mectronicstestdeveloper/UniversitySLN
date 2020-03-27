using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using University.BackEnd.Business;
using University.BackEnd.Entities;
using University.BackEnd.Services.Contracts;

namespace University.BackEnd.Services.Services
{
    /// <summary>
    /// Clase que opera como servicio Web para ejecutar funciones
    /// </summary>
    public class GeographicalStateServices : IGeographicalState
    {
        /// <summary>
        /// Constructor de la clase que instancia la capa de negocio
        /// </summary>
        public GeographicalStateServices() => this._business = new GeographicalStateBusiness();

        /// <summary>
        /// Clase que opera como capa de negocio
        /// </summary>
        public GeographicalStateBusiness _business;

        /// <summary>
        /// Servicio web para agregar un registro
        /// </summary>
        /// <param name="element">Entidad</param>
        /// <returns></returns>
        public async Task Add(GeographicalState element)
        {
            try
            {
                await Task.Run(() => this._business.Add(element));
            }
            catch (Exception err)
            {
                throw new FaultException("Error in Service" + err);
            }
        }

        /// <summary>
        /// Servicio web para eliminar un registro
        /// </summary>
        /// <param name="element">Entidad</param>
        /// <returns></returns>
        public async Task Delete(GeographicalState element)
        {
            try
            {
                await Task.Run(() => { this._business.Delete(element); });
            }
            catch (Exception err)
            {
                throw new FaultException("Error in Service" + err);
            }
        }

        /// <summary>
        /// Servicio web para actualizar un registro
        /// </summary>
        /// <param name="element">Entidad</param>
        /// <returns></returns>
        public async Task Update(GeographicalState element)
        {
            try
            {
                await Task.Run(() => { this._business.Update(element); });
            }
            catch (Exception err)
            {
                throw new FaultException("Error in Service" + err);
            }
        }

        /// <summary>
        /// Servicio web para obtener por la llave primaria un registro
        /// </summary>
        /// <param name="identifer">Llave primaria</param>
        /// <returns></returns>
        public async Task<GeographicalState> Get(Guid identifer)
        {
            try
            {
                return await Task.Run<GeographicalState>(() =>
                {
                    return this._business.Get(identifer);
                });
            }
            catch (Exception err)
            {
                throw new FaultException("Error in Service" + err);
            }
        }

        /// <summary>
        /// Servicio web para obtener todos los registros
        /// </summary>
        /// <returns></returns>
        public async Task<List<GeographicalState>> GetList()
        {
            try
            {
                return await Task.Run<List<GeographicalState>>(() =>
                {
                    var data = this._business.GetList();
                    return data;
                });
            }
            catch (Exception err)
            {
                throw new FaultException("Error in Service" + err);
            }
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
                    this._business.Dispose();
                }
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