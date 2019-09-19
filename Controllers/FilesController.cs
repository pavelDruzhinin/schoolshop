using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolShop.Controllers
{
    [Route("api")]
    public class FilesController : Controller
    {
        [HttpPost]
        public IActionResult Upload(List<IFormFile> files)
        {
            return Ok(files.Count);
        }
    }
}