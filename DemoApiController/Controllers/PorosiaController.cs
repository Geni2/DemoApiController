using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApiController.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApiController.Controllers
{


    [Route("api/Porosite")]
    [ApiController]
    
    public class PorosiaController : ControllerBase
    {
       
        public const string XML_FORMAT = "application/xml";
        protected PorositeContext Context;

        public PorosiaController(PorositeContext context)
        {
            Context = context;
        }

        [HttpGet]
        [Produces(XML_FORMAT)]
        public async Task <IActionResult> Get()
        {
            var porosite = await Context.Porosi.ToListAsync();
            return Ok(porosite);
        }

        [HttpPost]
        [Consumes(XML_FORMAT)]
        public IActionResult Create( Porosi porosi)
        {
            porosi.Id = null;
            Context.Add(porosi);
            Context.SaveChanges();
            return Ok(porosi);
        }
       
        
           
            
        
    }
}
