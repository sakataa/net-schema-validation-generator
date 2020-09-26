using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchemaValidationGenerator;

namespace WebApi.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchemaValidationController : ControllerBase
    {
        public IActionResult Index()
        {
            var schemaValidation = new SchemaReader();
            return Ok(schemaValidation.ReadFrom<Response>());
        }
    }

    public class Response
    {
        [Required]
        public int Id { get; set; }

        [Display(Description = "Name of Object")]
        [MinLength(5)]
        [MaxLength(250)]
        public string Name { get; set; }

        
        public int Age { get; set; }
    }
}
