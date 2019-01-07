using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using content.ImageHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace content.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {

        private readonly IImageHandler _imageHandler;

        public ImageController(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
        }

        /// <summary>
        /// Uplaods an image to the server.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> UploadImage(IFormFile file)
        {
            var path =  await _imageHandler.UploadImage(file);
            var rv = new content.Helpers.CloudinaryStorage().UploadFile(path);
            // TODO: add to database
            return Ok(rv);
        }


    }
}
