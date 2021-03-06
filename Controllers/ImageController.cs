using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using content.ImageHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace content.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {

        private readonly IImageHandler _imageHandler;
        private readonly IOptions<content.Helpers.CloudinaryKeys> _options;

        public ImageController(IImageHandler imageHandler, IOptions<content.Helpers.CloudinaryKeys> options)
        {
            _imageHandler = imageHandler;
            _options = options;
            Console.WriteLine(_options.Value.CloudName);
            
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
            var rv = new content.Helpers.CloudinaryStorage(_options.Value).UploadFile(path);
            // TODO: add to database
            return Ok(rv);
        }


    }
}
