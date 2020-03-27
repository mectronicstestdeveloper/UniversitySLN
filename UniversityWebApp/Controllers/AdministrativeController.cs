using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using University.BackEnd.Entities;
using CityService;
using CountryService;
using GeographicalStateService;
using PersonTypeService;
using ProgramSubjectService;
using ProgramSubjectPersonService;
using RoomService;
using ProgramService;
using PersonService;
using RoomSubjectService;
using NotesService;
using SubjectService;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using UniversityWebApp.Models;

namespace UniversityWebApp.Controllers
{
    public class AdministrativeController : Controller
    {
        /// <summary>
        /// Servicio Backend de Materia
        /// </summary>
        private ISubject subjectService;

        /// <summary>
        /// Servicio Backend de Salon
        /// </summary>
        private IRoom roomService;

        /// <summary>
        /// Constructor del controller donde se activan los servicios
        /// </summary>
        /// <param name="_cityService"></param>
        public AdministrativeController(ISubject _subjectService, IRoom _roomService)
        {
            this.subjectService = _subjectService;
            this.roomService = _roomService;
        }

        #region Subject

        /// <summary>
        /// Método que renderiza la vista del formulario materias FILTRADO POR MIN 4 CARACTERES
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> SubjectH()
        {
            return View();
        }

        /// <summary>
        /// Método que renderiza la vista del formulario materias
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Subject()
        {
            return View();
        }

        /// <summary>
        /// Método que lista los registros de materias
        /// </summary>
        /// <param name="request">request de la rejilla</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SubjectRead([DataSourceRequest] DataSourceRequest request)
        {
            var list = await subjectService.GetListAsync();
            return Json(list.OfType<Subject>().ToList().ToDataSourceResult(request));
        }

        /// <summary>
        /// Método que consume sl servicio de agregar un nuevo registro en materia
        /// </summary>
        /// <param name="request">request de la rejilla</param>
        /// <param name="element">materia</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SubjectCreate([DataSourceRequest] DataSourceRequest request, Subject element)
        {
            if (element != null && ModelState.IsValid)
            {
                await subjectService.AddAsync(element);
            }

            return Json(new[] { element }.ToDataSourceResult(request, ModelState));
        }

        /// <summary>
        /// método que consume el servicio de actualizar un registro materia
        /// </summary>
        /// <param name="request">request de la rejilla</param>
        /// <param name="element">materia</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SubjectUpdate([DataSourceRequest] DataSourceRequest request, Subject element)
        {
            if (element != null && ModelState.IsValid)
            {
                await subjectService.UpdateAsync(element);
            }

            return Json(new[] { element }.ToDataSourceResult(request, ModelState));
        }

        /// <summary>
        /// método que consume el servicio de eliminar un registro materia
        /// </summary>
        /// <param name="request">request de la rejilla</param>
        /// <param name="element">materia</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SubjectDestroy([DataSourceRequest] DataSourceRequest request, Subject element)
        {
            if (element != null)
            {
                await subjectService.DeleteAsync(element);
            }

            return Json(new[] { element }.ToDataSourceResult(request, ModelState));
        }

        #endregion Subject

        #region Room

        /// <summary>
        /// Método que renderiza la vista del formulario salons
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Room()
        {
            return View();
        }

        /// <summary>
        /// Método que lista los registros de salons
        /// </summary>
        /// <param name="request">request de la rejilla</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RoomRead([DataSourceRequest] DataSourceRequest request)
        {
            var list = await roomService.GetListAsync();
            return Json(list.OfType<Room>().ToList().ToDataSourceResult(request));
        }

        /// <summary>
        /// Método que consume sl servicio de agregar un nuevo registro en salon
        /// </summary>
        /// <param name="request">request de la rejilla</param>
        /// <param name="element">salon</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RoomCreate([DataSourceRequest] DataSourceRequest request, Room element)
        {
            if (element != null && ModelState.IsValid)
            {
                await roomService.AddAsync(element);
            }

            return Json(new[] { element }.ToDataSourceResult(request, ModelState));
        }

        /// <summary>
        /// método que consume el servicio de actualizar un registro salon
        /// </summary>
        /// <param name="request">request de la rejilla</param>
        /// <param name="element">salon</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RoomUpdate([DataSourceRequest] DataSourceRequest request, Room element)
        {
            if (element != null && ModelState.IsValid)
            {
                await roomService.UpdateAsync(element);
            }

            return Json(new[] { element }.ToDataSourceResult(request, ModelState));
        }

        /// <summary>
        /// método que consume el servicio de eliminar un registro salon
        /// </summary>
        /// <param name="request">request de la rejilla</param>
        /// <param name="element">salon</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RoomDestroy([DataSourceRequest] DataSourceRequest request, Room element)
        {
            if (element != null)
            {
                await roomService.DeleteAsync(element);
            }

            return Json(new[] { element }.ToDataSourceResult(request, ModelState));
        }

        #endregion Room
    }
}