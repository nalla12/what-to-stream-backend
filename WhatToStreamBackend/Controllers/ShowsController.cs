using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatToStreamBackend.Models.Db;
using WhatToStreamBackend.Repositories;

namespace WhatToStreamBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController(IShowsDbRepository showsDbRepository) : ControllerBase
    {
        // GET: api/Shows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Show>>> GetAllShows()
        {
            var shows = await showsDbRepository.GetAllShowsAsync();
            return Ok(shows);
        }

        // GET: api/Shows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> GetShowById(string id)
        {
            var show = await showsDbRepository.GetShowByIdAsync(id);
            if (show == null)
            {
                return NotFound($"Show with Id: {id} does not exist.");
            }

            return Ok(show);
        }
        
        // POST: api/Shows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Show?>> CreateShow(Show show)
        {
            try
            {
                await showsDbRepository.AddShowAsync(show);
                return CreatedAtAction(nameof(GetShowById), new { id = show.Id }, show);
            }
            catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("duplicate key") == true)
            {
                // Return a 409 Conflict response if the show ID already exists
                return Conflict(new { message = $"A show with ID {show.Id} already exists." });
            }
        }

        // PUT: api/Shows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShow(Show show)
        {
            try
            {
                await showsDbRepository.UpdateShowAsync(show);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await ShowExists(show.Id) == false)
                {
                    return NotFound($"Show with Id: {show.Id} does not exist.");
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // DELETE: api/Shows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShow(string id)
        {
            /*var showInRepo = await showsDbRepository.GetShowByIdAsync(id);
            if (showInRepo == null)
            {
                return NotFound($"Show with Id: {id} does not exist.");
            }*/
            
            string deleteResult = await showsDbRepository.DeleteShowAsync(id);
            
            if (deleteResult == "Not found")
            {
                return NotFound($"Show with Id: {id} does not exist.");
            }
            
            return Ok($"Show with Id: {id} has been deleted.");
        }
        
        // DELETE: api/Shows
        [HttpDelete]
        public async Task<IActionResult> DeleteAllShows(string check)
        {
            if (check != "delete all shows")
            {
                return BadRequest("Please provide the correct query parameter to delete all shows.");
            }
            
            string deleteResult = await showsDbRepository.DeleteAllShowsAsync();
            return Ok(deleteResult);
        }

        private async Task<bool> ShowExists(string id)
        {
            return await showsDbRepository.GetShowByIdAsync(id) != null;
        }
    }
}
