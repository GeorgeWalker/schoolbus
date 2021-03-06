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
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;

namespace SchoolBusAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICityApiService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of cities</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        IActionResult CitiesBulkPostAsync(City[] items);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of cities</remarks>
        /// <response code="200">OK</response>
        IActionResult CitiesGetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a City</remarks>
        /// <param name="id">id of City to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">City not found</response>
        IActionResult CitiesIdDeletePostAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a specific City by ID</remarks>
        /// <param name="id">id of City to fetch</param>
        /// <response code="200">OK</response>
        IActionResult CitiesIdGetAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a City</remarks>
        /// <param name="id">id of City to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">City not found</response>
        IActionResult CitiesIdPutAsync(int id, City item);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a City</remarks>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        IActionResult CitiesPostAsync(City item);
    }
}
