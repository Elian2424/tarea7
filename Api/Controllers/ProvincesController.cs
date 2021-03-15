using System;
using System.Linq;
using System.Collections.Generic;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvincesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Provinces> GetItems()
        {
            return new vaccineContext().Provinces;
        }

        [HttpGet("{id}")]
        public ActionResult<Provinces> GetItem(int id)
        {
            Provinces entity = new vaccineContext().Provinces.Where(p => p.Id == id).SingleOrDefault();

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
        public ActionResult<bool> CreateItem([FromBody] Provinces entity)
        {
            try
            {
                var c = new vaccineContext();
                c.Provinces.Add(entity);
                c.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public ActionResult<bool> UpdateItem(int id, [FromBody] Provinces entity)
        {

            try
            {
                var c = new vaccineContext();
                Provinces existing = c.Provinces.Where(p => p.Id == id).SingleOrDefault();
                //values
                existing.Name = entity.Name is null ? existing.Name : entity.Name;

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
                c.Provinces.Remove(new vaccineContext().Provinces.Where(p => p.Id == id).SingleOrDefault());
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