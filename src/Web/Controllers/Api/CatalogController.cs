using System;
using System.Collections.Generic;
using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Javeriana.Pica.Web.Controllers.Api
{
    //TODO Implemente los demás controladores de acuerdo a lo descrito en el contexto del taller
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        // GET: api/catalog
        [HttpGet]
        public ActionResult<IEnumerable<CatalogItem>> Get()
        {
            return Ok(_catalogService.GetCatalogItems());
        }

        // GET: api/catalog/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/catalog
        [HttpPost]
        public void Post([FromBody] CatalogItem value)
        {
        }

        // PUT: api/catalog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CatalogItem value)
        {
        }

        // DELETE: api/catalog/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
