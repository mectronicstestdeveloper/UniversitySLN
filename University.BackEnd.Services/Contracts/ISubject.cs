using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using University.BackEnd.Entities;

namespace University.BackEnd.Services.Contracts
{
    /// <summary>
    /// Interfaz que funciona como contrato del servicio permitiendo administrar las operaciones del mismo.
    /// </summary>
    [ServiceContract]
    public interface ISubject : IDisposable
    {
        /// <summary>
        /// Método del contrato que permite agregar un registro en la entidad
        /// </summary>
        /// <param name="element">Objeto de dominio</param>
        /// <returns>Objeto de dominio</returns>
        [OperationContract]
        Task Add(Subject element);

        /// <summary>
        /// Método del contrato que permite eliminar un registro en la entidad
        /// </summary>
        /// <param name="element">Objeto de dominio</param>
        /// <returns></returns>
        [OperationContract]
        Task Delete(Subject element);

        /// <summary>
        /// Método del contrato que permite actualizar un registro en la entidad
        /// </summary>
        /// <param name="element">Objeto de dominio</param>
        /// <returns>Objeto de dominio</returns>
        [OperationContract]
        Task Update(Subject element);

        /// <summary>
        /// Método del contrato que permite obtener por ID
        /// </summary>
        /// <param name="identifer">Identificador</param>
        /// <returns>Objeto de dominio</returns>
        [OperationContract]
        Task<Subject> Get(Guid identifer);

        /// <summary>
        /// Método del contrato que permite listar todo
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Task<List<Subject>> GetList();
    }
}