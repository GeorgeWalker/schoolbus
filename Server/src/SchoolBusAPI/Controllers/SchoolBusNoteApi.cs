/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.SwaggerGen.Annotations;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using SchoolBusAPI.Services;

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SchoolBusNoteApiController : Controller
    {
        private readonly ISchoolBusNoteApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public SchoolBusNoteApiController(ISchoolBusNoteApiService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <response code="201">SchoolBusNotes created</response>
        [HttpPost]
        [Route("/api/schoolbusnotes/bulk")]
        [SwaggerOperation("SchoolbusnotesBulkPost")]
        public virtual IActionResult SchoolbusnotesBulkPost([FromBody]SchoolBusNote[] items)
        {
            return this._service.SchoolbusnotesBulkPostAsync(items);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/schoolbusnotes")]
        [SwaggerOperation("SchoolbusnotesGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolBusNote>))]
        public virtual IActionResult SchoolbusnotesGet()
        {
            return this._service.SchoolbusnotesGetAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusNote to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusNote not found</response>
        [HttpPost]
        [Route("/api/schoolbusnotes/{id}/delete")]
        [SwaggerOperation("SchoolbusnotesIdDeletePost")]
        public virtual IActionResult SchoolbusnotesIdDeletePost([FromRoute]int id)
        {
            return this._service.SchoolbusnotesIdDeletePostAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusNote to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusNote not found</response>
        [HttpGet]
        [Route("/api/schoolbusnotes/{id}")]
        [SwaggerOperation("SchoolbusnotesIdGet")]
        [SwaggerResponse(200, type: typeof(SchoolBusNote))]
        public virtual IActionResult SchoolbusnotesIdGet([FromRoute]int id)
        {
            return this._service.SchoolbusnotesIdGetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of SchoolBusNote to fetch</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusNote not found</response>
        [HttpPut]
        [Route("/api/schoolbusnotes/{id}")]
        [SwaggerOperation("SchoolbusnotesIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusNote))]
        public virtual IActionResult SchoolbusnotesIdPut([FromRoute]int id, [FromBody]SchoolBusNote item)
        {
            return this._service.SchoolbusnotesIdPutAsync(id, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <response code="201">SchoolBusNote created</response>
        [HttpPost]
        [Route("/api/schoolbusnotes")]
        [SwaggerOperation("SchoolbusnotesPost")]
        [SwaggerResponse(200, type: typeof(SchoolBusNote))]
        public virtual IActionResult SchoolbusnotesPost([FromBody]SchoolBusNote item)
        {
            return this._service.SchoolbusnotesPostAsync(item);
        }
    }
}
