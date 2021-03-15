using System;
using System.Linq;
using System.Collections.Generic;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Records> GetItems()
        {
            return new vaccineContext().Records;
        }

        [HttpGet("{id}")]
        public ActionResult<Records> GetItem(int id)
        {
            Records entity = new vaccineContext().Records.Where(p => p.Id == id).SingleOrDefault();

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
        public ActionResult<bool> CreateItem([FromBody] Records entity)
        {
            try
            {
                var c = new vaccineContext();
                c.Records.Add(entity);
                c.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public ActionResult<bool> UpdateItem(int id, [FromBody] Records entity)
        {

            try
            {
                var c = new vaccineContext();
                Records existing = c.Records.Where(p => p.Id == id).SingleOrDefault();
                //values
                existing.Citizen = entity.Citizen == 0 ? existing.Citizen : entity.Citizen;
                existing.Vaccine = entity.Vaccine == 0 ? existing.Vaccine : entity.Vaccine;
                existing.Province = entity.Province == 0 ? existing.Province : entity.Province;
                existing.FirstVacDate = entity.FirstVacDate is null ? existing.FirstVacDate : entity.FirstVacDate;
                existing.LastVacDate = entity.LastVacDate is null ? existing.LastVacDate : entity.LastVacDate;



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
                c.Records.Remove(new vaccineContext().Records.Where(p => p.Id == id).SingleOrDefault());
                c.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("province/{id}")]
        public IEnumerable<Records> GetItemsByProvince(int id)
        {
            return new vaccineContext().Records.Where(r => r.Province == id);
        }

        [HttpGet("brand/{id}")]
        public IEnumerable<Records> GetItemsByBrand(int id)
        {
            return new vaccineContext().Records.Where(r => r.Vaccine == id);
        }

        [HttpGet("zodiac/{sign}")]
        public IEnumerable<Records> GetItemsByBrand(string sign)
        {
            return new vaccineContext().Records.Where(r => r.FirstVacDate.Value.Date >= new DateTime());
        }
    }
}