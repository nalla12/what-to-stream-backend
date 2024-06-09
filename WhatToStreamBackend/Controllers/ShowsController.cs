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
        private IShowsDbRepository _showsDbRepository;

        public ShowsController(IShowsDbRepository showsDbRepository)
        {
            _showsDbRepository = showsDbRepository;
        }

        // GET: api/Shows
        [HttpGet]
        public ActionResult<IEnumerable<Show>> GetAllShows()
        {
            return _showsDbRepository.GetAllShows();
        }

        // GET: api/Shows/5
        [HttpGet("{id}")]
        public ActionResult<Show> GetShow(string id)
        {
            var show = _showsDbRepository.GetShowById(id);

            if (show == null)
            {
                return NotFound();
            }

            return show;
        }

        // PUT: api/Shows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateShow(Show show)
        {
            var showInRepo = _showsDbRepository.GetShowById(show.Id);

            if (showInRepo != null)
            {
                _showsDbRepository.UpdateShow(show);
                return Ok();
            }

            return NotFound($"Show with Id: {show.Id} does not exist.");
        }

        // DELETE: api/Shows/5
        [HttpDelete("{id}")]
        public IActionResult DeleteShow(string id)
        {
            var showInRepo = _showsDbRepository.GetShowById(id);
            
            if (showInRepo != null)
            {
                
                _showsDbRepository.DeleteShow(showInRepo);
                return Ok();
            }

            return NotFound($"Show with Id: {id} does not exist.");
        }
        
        // POST: api/Shows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Show> CreateShow(Show show)
        {
            // TODO: not efficient. Maybe try to insert and check Db conflict error
            if (_showsDbRepository.GetAllShows().Any(s => s.Id == show.Id))
            {
                return Conflict($"A show with ID {show.Id} already exist.");
            }
            return _showsDbRepository.CreateShow(show);
            
            /*try
            {
                _showsDbRepository.CreateShow(show);
            }
            catch (DbUpdateException)
            {
                if (ShowExists(show.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShow", new { id = show.Id }, show);*/
        }

        // TODO: delete this?
        private bool ShowExists(string id)
        {
            return _showsDbRepository.GetAllShows().Any(e => e.Id == id);
        }
    }
}
