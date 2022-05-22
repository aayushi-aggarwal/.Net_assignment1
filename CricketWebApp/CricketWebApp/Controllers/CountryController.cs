﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CricketWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CricketContext _cricket;
        public CountryController(CricketContext cricketcs)
        {
            _cricket = cricketcs;
        }
        // GET: api/Country
        [HttpGet]
        public IActionResult Get1()
        {
            var country = _cricket.Country.ToList();
            return Ok(country);
        }
        // GET: api/Country
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Country/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Country
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/


    }
}
