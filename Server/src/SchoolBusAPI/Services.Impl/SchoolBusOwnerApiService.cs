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
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Services.Impl
{ 
    /// <summary>
    /// 
    /// </summary>
    public class SchoolBusOwnerApiService : ISchoolBusOwnerApiService
    {

        private readonly DbAppContext _context;

        /// <summary>
        /// Create a service and set the database context
        /// </summary>
        public SchoolBusOwnerApiService (DbAppContext context)
        {
            _context = context;
        }
	
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns list of available FavouriteContextTypes</remarks>
        /// <response code="200">OK</response>

        public virtual IActionResult FavouritecontexttypesGetAsync ()        
        {
            var result = _context.FavouriteContextTypes.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwners created</response>

        public virtual IActionResult SchoolbusownersBulkPostAsync (SchoolBusOwner[] items)        
        {
            if (items == null)
            {
                return new BadRequestResult();
            }
            foreach (SchoolBusOwner item in items)
            {
                // adjust Primary Contact.
                if (item.PrimaryContact != null)
                {
                    int primary_contact_id = item.PrimaryContact.Id;
                    var primary_contact_exists = _context.SchoolBusOwnerContacts.Any(a => a.Id == primary_contact_id);
                    if (primary_contact_exists)
                    {
                        SchoolBusOwnerContact contact = _context.SchoolBusOwnerContacts.First(a => a.Id == primary_contact_id);
                        item.PrimaryContact = contact;
                    }
                    else
                    {
                        return new ObjectResult("ERROR - Primary contact with an id of " + primary_contact_id + " does not exist, for record id " + item.Id);
                    }
                }
                else
                {
                    return new ObjectResult("ERROR - Primary contact is null.");
                }

                // adjust Service Area.
                if (item.ServiceArea != null)
                {
                    int servicearea_id = item.ServiceArea.Id;
                    var servicearea_exists = _context.ServiceAreas.Any(a => a.Id == servicearea_id);
                    if (servicearea_exists)
                    {
                        ServiceArea servicearea = _context.ServiceAreas.First(a => a.Id == servicearea_id);
                        item.ServiceArea = servicearea;
                    }
                    else
                    {
                        return new ObjectResult("ERROR - Service area with an id of " + servicearea_id + " does not exist, for record id " + item.Id);
                    }
                }
                else
                {
                    return new ObjectResult("ERROR - Primary contact is null.");
                }

                var exists = _context.SchoolBusOwners.Any(a => a.Id == item.Id);
                if (exists)
                {
                    _context.SchoolBusOwners.Update(item);
                }
                else
                {
                    _context.SchoolBusOwners.Add(item);
                }               
            }
            // Save the changes
            _context.SaveChanges();

            return new NoContentResult();
        }
        /// <summary>
        /// 
        /// </summary>
        
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersGetAsync ()        
        {
            var result = _context.SchoolBusOwners.ToList();
            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns attachments for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch attachments for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdAttachmentsGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwnerAttachments.Where(a => a.SchoolBusOwner.Id == id);
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
        /// <remarks>Returns address contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact address for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdContactaddressesGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                List<SchoolBusOwnerContactAddress> result = new List<SchoolBusOwnerContactAddress>();
                var owner = _context.SchoolBusOwners.Where(a => a.Id == id).First();
                var contacts = owner.Contacts;
                foreach (SchoolBusOwnerContact contact in contacts)
                {
                    // merge the lists
                    result = result.Concat ( contact.SchoolBusOwnerContactAddresses).ToList();
                }
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
        /// <remarks>Returns phone contacts for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch contact phone for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdContactphonesGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                List<SchoolBusOwnerContactPhone> result = new List<SchoolBusOwnerContactPhone>();
                var owner = _context.SchoolBusOwners.Where(a => a.Id == id).First();
                var contacts = owner.Contacts;
                foreach (SchoolBusOwnerContact contact in contacts)
                {
                    // merge the lists
                    result = result.Concat(contact.SchoolBusOwnerContactPhones).ToList();
                }
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
        
        /// <param name="id">id of SchoolBusOwner to delete</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>

        public virtual IActionResult SchoolbusownersIdDeletePostAsync (int id)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var item = _context.SchoolBusOwners.First(a => a.Id == id);            
                _context.SchoolBusOwners.Remove(item);
                // Save the changes
                _context.SaveChanges();            
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
        /// <remarks>Returns a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwners.First(a => a.Id == id);
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
        /// <remarks>Returns notes for a particular SchoolBusOwner</remarks>
        /// <param name="id">id of SchoolBusOwner to fetch notes for</param>
        /// <response code="200">OK</response>

        public virtual IActionResult SchoolbusownersIdNotesGetAsync (int id)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists)
            {
                var result = _context.SchoolBusOwnerNotes.Where(a => a.SchoolBusOwner.Id == id);
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
        
        /// <param name="id">id of SchoolBusOwner to fetch</param>
        /// <response code="200">OK</response>
        /// <response code="404">SchoolBusOwner not found</response>

        public virtual IActionResult SchoolbusownersIdPutAsync (int id, SchoolBusOwner body)        
        {
            var exists = _context.SchoolBusOwners.Any(a => a.Id == id);
            if (exists && id == body.Id)
            {
                _context.SchoolBusOwners.Update(body);
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
        
        /// <param name="body"></param>
        /// <response code="201">SchoolBusOwner created</response>

        public virtual IActionResult SchoolbusownersPostAsync (SchoolBusOwner body)        
        {
            _context.SchoolBusOwners.Add(body);
            _context.SaveChanges();
            return new ObjectResult(body);
        }
    }
}
