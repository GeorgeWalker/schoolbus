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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;

namespace SchoolBusAPI.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class DistrictApiService : IDistrictApiService
    {
        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public DistrictApiService(DbAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a number of districts.</remarks>
        /// <param name="items"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult DistrictsBulkPostAsync(District[] items)
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (District item in items)
            {
                // avoid inserting a Region if possible.
                int region_id = item.Region.Id;
                var exists = _context.Regions.Any(a => a.Id == region_id);
                if (exists)
                {
                    Region region = _context.Regions.First(a => a.Id == region_id);
                    item.Region = region;
                }

                exists = _context.Districts.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.Districts.Update(item);
                }
                else
                {
                    _context.Districts.Add(item);
                }               
            }
            // Save the changes
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of available districts</remarks>
        /// <response code="200">OK</response>
        public virtual IActionResult DistrictsGetAsync()
        {
            // eager loading of regions
            var result = _context.Districts
                    .Include(x => x.Region)
                    .ToList();
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Deletes a district</remarks>
        /// <param name="id">id of District to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">District not found</response>
        public virtual IActionResult DistrictsIdDeletePostAsync(int id)
        {
            var exists = _context.Districts.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.Districts.First(a => a.Id == id);
                if (item != null)
                {
                    _context.Districts.Remove(item);
                    // Save the changes
                    _context.SaveChanges();
                }
                return new ObjectResult(item);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a specific district</remarks>
        /// <param name="id">id of Districts to fetch</param>
        /// <response code="200">OK</response>
        public virtual IActionResult DistrictsIdGetAsync(int id)
        {
            var exists = _context.Districts.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.Districts
                    .Where(a => a.Id == id)
                    .Include(a => a.Region)
                    .FirstOrDefault();
                    
                return new ObjectResult(result);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Updates a district</remarks>
        /// <param name="id">id of District to update</param>
        /// <param name="item"></param>
        /// <response code="200">OK</response>
        /// <response code="404">District not found</response>
        public virtual IActionResult DistrictsIdPutAsync(int id, District body)
        {
            var exists = _context.Districts.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.Districts.Update(body);
                // Save the changes
                _context.SaveChanges();
                return new ObjectResult(body);
            }
            else
            {
                // record not found
                return new StatusCodeResult(404);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns the Service Areas for a specific region</remarks>
        /// <param name="id">id of District for which to fetch the ServiceAreas</param>
        /// <response code="200">OK</response>
        public virtual IActionResult DistrictsIdServiceareasGetAsync(int id)
        {
            var result = "";
            return new ObjectResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Adds a district</remarks>
        /// <param name="body"></param>
        /// <response code="200">OK</response>
        public virtual IActionResult DistrictsPostAsync(District body)
        {
            // adjust region
            int region_id = body.Region.Id;
            var exists = _context.Regions.Any(a => a.Id == region_id);
            if (exists)
            {
                Region region = _context.Regions.First(a => a.Id == region_id);
                body.Region = region;
            }
            _context.Districts.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }

        
    }
}
