/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
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
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusNotes created</response>
        [HttpPost]
        [Route("/api/schoolbusnotes/bulk")]
        [SwaggerOperation("SchoolbusnotesBulkPost")]
        public virtual void SchoolbusnotesBulkPost([FromBody]List<SchoolBusNote> body)
        { 
            throw new NotImplementedException();
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
        [HttpDelete]
        [Route("/api/schoolbusnotes/{id}")]
        [SwaggerOperation("SchoolbusnotesIdDelete")]
        public virtual void SchoolbusnotesIdDelete([FromRoute]int id)
        { 
            throw new NotImplementedException();
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
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusNote not found</response>
        [HttpPut]
        [Route("/api/schoolbusnotes/{id}")]
        [SwaggerOperation("SchoolbusnotesIdPut")]
        [SwaggerResponse(200, type: typeof(SchoolBusNote))]
        public virtual IActionResult SchoolbusnotesIdPut([FromRoute]int id)
        { 
            return this._service.SchoolbusnotesIdPutAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusNote created</response>
        [HttpPost]
        [Route("/api/schoolbusnotes")]
        [SwaggerOperation("SchoolbusnotesPost")]
        [SwaggerResponse(200, type: typeof(SchoolBusNote))]
        public virtual IActionResult SchoolbusnotesPost([FromBody]SchoolBusNote body)
        { 
            return this._service.SchoolbusnotesPostAsync(body);
        }
    }
}