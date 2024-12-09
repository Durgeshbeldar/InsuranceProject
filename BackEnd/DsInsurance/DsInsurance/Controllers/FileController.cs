using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DsInsurance.DTOs;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly CloudinaryDotNet.Cloudinary _cloudinary;
        public FileController(IConfiguration configuration)
        {
            var cloudName = configuration["Cloudinary:CloudName"];
            var apiKey = configuration["Cloudinary:ApiKey"];
            var apiSecret = configuration["Cloudinary:ApiSecret"];

            _cloudinary = new CloudinaryDotNet.Cloudinary(new Account(cloudName, apiKey, apiSecret));
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = "aspnet_core_uploads" //define a folder in Cloudinary
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
                return StatusCode((int)uploadResult.StatusCode, "Upload failed.");

            var response = new FileUploadDto
            {
                PublicId = uploadResult.PublicId,
                FileUrl = uploadResult.Url.ToString()
            };

            return Ok(response);
        }
    }
}
