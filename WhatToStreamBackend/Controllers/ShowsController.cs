using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatToStreamBackend.Models;

namespace WhatToStreamBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly IShowsDbRepository _showsDbRepository;

        public ShowsController(IShowsDbRepository showsDbRepository)
        {
            _showsDbRepository = showsDbRepository;
        }

        // GET: api/Shows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Show>>> GetAllShows()
        {
            var shows = await _showsDbRepository.GetAllShowsAsync();
            return Ok(shows);
        }

        // GET: api/Shows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> GetShowById(string id)
        {
            var show = await _showsDbRepository.GetShowByIdAsync(id);
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
                await _showsDbRepository.CreateShowAsync(show);
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
                await _showsDbRepository.UpdateShowAsync(show);
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
            var showInRepo = await _showsDbRepository.GetShowByIdAsync(id);
            if (showInRepo == null)
            {
                return NotFound($"Show with Id: {id} does not exist.");
            }
            
            await _showsDbRepository.DeleteShowAsync(id);
            return Ok();
        }

        private async Task<bool> ShowExists(string id)
        {
            return await _showsDbRepository.GetShowByIdAsync(id) != null;
        }
    }
}
