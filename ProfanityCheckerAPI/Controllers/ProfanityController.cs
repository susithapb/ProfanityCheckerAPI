using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProfanityCheckerAPI.Data;
using ProfanityFilter;
using System.IO;
using System;
using System.Text;
using System.Threading.Tasks;
using ProfanityCheckerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProfanityCheckerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfanityController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProfanityController(StoreContext context)
        {
            _context = context;
        }

        [HttpPost("[action]"), ActionName("upload")]
        public async Task<ActionResult<List<string>>> UploadFile()
        {
            string[] words;
            bool check;

            List<string> profanityWords = new List<string>();
            var filter = new ProfanityFilter.ProfanityFilter();
            try
            {
                var file = Request.Form.Files[0];
                var fileText = new StringBuilder();
                var folderName = Path.Combine("Resources");
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    using (var stream = new StreamReader(file.OpenReadStream()))
                    {
                        while (stream.Peek() >= 0)
                        {
                            fileText.AppendLine(await stream.ReadLineAsync());
                        }

                        words = fileText.ToString().Split(" ");
                        foreach (var w in words)
                        {
                            check = filter.IsProfanity(w);
                            if (check == true)
                            {
                                profanityWords.Add(w);
                                _context.Add(new BadWord
                                {
                                    Word = w,
                                    IsDeleted = false
                                });

                                //_context.Add(new ProfanityDocument
                                //{
                                //    DocumentId = 
                                //});
                            }
                        }
                    }
                    _context.Add(new Document
                    {
                        FileName = file.FileName,
                        FileSize = ((int)file.Length),
                        CreatedDate = DateTime.Today
                    });
                }
                //_context.SaveChanges();
            }


            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

            return Ok();
        }

        [HttpPost("[action]"), ActionName("save")]
        public string SaveProfanityWords()
        {
            return "file details";
        }

        [HttpGet]
        public async Task<ActionResult<List<BadWord>>> GetProfanityWords()
        {
            var badWords = await _context.BadWords.ToListAsync();

            return Ok(badWords);
        }

        [HttpDelete]
        public bool RemoveBadWordsList()
        {
            return true;
        }
    }
}