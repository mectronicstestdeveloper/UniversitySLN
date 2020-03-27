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
    public class PersonController : Controller
    {
        /// <summary>
        /// Servicio Backend de Persona
        /// </summary>
        private IPerson personService;

        /// <summary>
        /// Servicio Backend de Persona
        /// </summary>
        private IProgramSubjectPerson programSubjectPersonService;

        /// <summary>
        /// Constructor del controller donde se activan los servicios
        /// </summary>
        public PersonController(IPerson _personService, IProgramSubjectPerson _programSubjectPersonService)
        {
            this.personService = _personService;
            this.programSubjectPersonService = _programSubjectPersonService;
        }

        /// <summary>
        /// Método que renderiza la vista del formulario busqueda de estudiantes
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> PersonG()
        {
            return View();
        }

        #region Subject

        /// <summary>
        /// Método que renderiza la vista del formulario Estudiantes
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> PersonE()
        {
            return View();
        }

        /// <summary>
        /// Método que renderiza la vista del formulario materias por estudiante
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> PersonF()
        {
            return View();
        }

        /// <summary>
        /// Método que elimian profesores de una lista de personas
        /// </summary>
        /// <param name="List"></param>
        /// <returns></returns>
        private List<Person> DeleteTeachers(List<Person> List)
        {
            List.RemoveAll(p => p.PersonType.PersonStudent.Equals(false));
            return List;
        }

        /// <summary>
        /// Método que elimian profesores de una lista de personas
        /// </summary>
        /// <param name="List"></param>
        /// <returns></returns>
        private List<ProgramSubjectPerson> DeleteTeachersfromSubject(List<ProgramSubjectPerson> List)
        {
            List.RemoveAll(p => p.Person.PersonType.PersonStudent.Equals(false));
            return List;
        }

        /// <summary>
        /// Método que lista los registros de materias ordenada por fecha de ingreso
        /// </summary>
        /// <param name="request">request de la rejilla</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PersonERead([DataSourceRequest] DataSourceRequest request)
        {
            var list = await personService.GetListAsync();
            List<Person> Lista_ordenada = list.OfType<Person>().ToList().OrderBy(o => o.PersonSingUp).ToList();
            DeleteTeachers(Lista_ordenada);
            return Json(Lista_ordenada.ToDataSourceResult(request));
        }

        /// <summary>
        /// Método que lista los registros de alumnos por materia
        /// </summary>
        /// <param name="request">request de la rejilla</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PersonFRead([DataSourceRequest] DataSourceRequest request)
        {
            var list = await programSubjectPersonService.GetListAsync();
            List<ProgramSubjectPerson> Lista_ordenada = list.OfType<ProgramSubjectPerson>().ToList().OrderBy(o => o.ProgramSubject.Program.ProgramName).ToList();
            DeleteTeachersfromSubject(Lista_ordenada);
            return Json(Lista_ordenada.ToDataSourceResult(request));
        }

        #endregion Subject
    }
}