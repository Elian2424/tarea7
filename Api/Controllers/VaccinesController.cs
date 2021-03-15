using System;
using System.Linq;
using System.Collections.Generic;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VaccinesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Vaccines> GetItems()
        {
            return new vaccineContext().Vaccines;
        }

        [HttpGet("{id}")]
        public ActionResult<Vaccines> GetItem(int id)
        {
            Vaccines entity = new vaccineContext().Vaccines.Where(p => p.Id == id).SingleOrDefault();

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
        public ActionResult<bool> CreateItem([FromBody] Vaccines entity)
        {
            try
            {
                var c = new vaccineContext();
                c.Vaccines.Add(entity);
                c.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public ActionResult<bool> UpdateItem(int id, [FromBody] Vaccines entity)
        {

            try
            {
                var c = new vaccineContext();
                Vaccines existing = c.Vaccines.Where(p => p.Id == id).SingleOrDefault();
                //values
                existing.Name = entity.Name is null ? existing.Name : entity.Name;
                existing.Amounted = entity.Amounted is null ? existing.Amounted : entity.Amounted;

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
                c.Vaccines.Remove(new vaccineContext().Vaccines.Where(p => p.Id == id).SingleOrDefault());
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