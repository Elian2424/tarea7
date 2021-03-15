using System;
using System.Linq;
using System.Collections.Generic;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitizensController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Citizens> GetItems()
        {
            return new vaccineContext().Citizens;
        }

        [HttpGet("{id}")]
        public ActionResult<Citizens> GetItem(int id)
        {
            Citizens entity = new vaccineContext().Citizens.Where(p => p.Id == id).SingleOrDefault();

            if (entity is null)
            {
                return NotFound();
            }
            else
            {
                return entity;
            }
        }

        [HttpPost]
        public ActionResult<bool> CreateItem([FromBody] Citizens entity)
        {
            try
            {
                var c = new vaccineContext();
                c.Citizens.Add(entity);
                c.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public ActionResult<bool> UpdateItem(int id, [FromBody] Citizens entity)
        {

            try
            {
                var c = new vaccineContext();
                Citizens existing = c.Citizens.Where(p => p.Id == id).SingleOrDefault();
                //values
                existing.FirstName = entity.FirstName is null ? existing.FirstName : entity.FirstName;
                existing.LastName = entity.LastName is null ? existing.LastName : entity.LastName;
                existing.Phone = entity.Phone is null ? existing.Phone : entity.Phone;
                existing.IdNumber = entity.IdNumber is null ? existing.IdNumber : entity.IdNumber;
                existing.BirthDate = entity.BirthDate is null ? existing.BirthDate : entity.BirthDate;



                c.Update(existing);
                c.SaveChanges();

                return true;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteItem(int id)
        {
            try
            {
                var c = new vaccineContext();
                c.Citizens.Remove(new vaccineContext().Citizens.Where(p => p.Id == id).SingleOrDefault());
                c.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}