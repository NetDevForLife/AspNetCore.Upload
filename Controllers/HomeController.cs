using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using AspNetCoreUploadTest.Models.InputModels;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Ganss.XSS;
using System;

namespace AspNetCoreUploadTest.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(new ContattoInputModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContattoInputModel inputModel, [FromServices] IWebHostEnvironment env)
    {
        if (ModelState.IsValid)
        {
            // This file will be saved in the wwwroot directory, if it's <100Kb
            // That's the limit configured in the appsettings.json file
            IFormFile image = inputModel.AttachFile;

            var fileFolder = Path.Combine(Path.Combine(env.WebRootPath, "upload"), Path.Combine(DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM")));

            if (!Directory.Exists(fileFolder))
                Directory.CreateDirectory(fileFolder);

            var imageSanitize = new HtmlSanitizer(allowedTags: new string[0]).Sanitize(image.FileName);
            var filePath = Path.Combine(fileFolder, imageSanitize);

            using var fileStream = System.IO.File.OpenWrite(filePath);
            await image.CopyToAsync(fileStream);

            return View("Grazie");
        }

        return View(inputModel);
    }
}