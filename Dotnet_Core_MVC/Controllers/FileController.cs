using Dotnet_Core_MVC.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Dotnet_Core_MVC.Controllers
{

    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [EnableCors("AllowOrigin")]
        [HttpGet]
        public string Get()
        {
            return "hiiiiiiiiiiii";
        }
        [EnableCors("AllowOrigin")]
        [HttpPost]
        public ActionResult Post([FromForm] FileModel file)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileName);

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
