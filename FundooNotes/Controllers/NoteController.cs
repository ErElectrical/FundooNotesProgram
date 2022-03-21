using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using BussinessLayer.InterFace;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using repositorylayer.entity;
using System.Text;
using Newtonsoft.Json;

namespace FundooNotes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class NoteController : ControllerBase
    {
        private readonly INoteBL noteBL;
        private readonly IMemoryCache memoryCache;
        
        private readonly IDistributedCache distributedCache;


        public NoteController(INoteBL noteBL, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.noteBL = noteBL;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
        }

        private long GetUserId()
        {
            return Convert.ToInt32(User.FindFirst("Id").Value);
        }

        [HttpPost("Create")]
        public IActionResult CreateNote(NoteCreation noteCreation)
        {
            long id = GetUserId();
            try
            {
                var result = this.noteBL.CreateNote(noteCreation, id);
                if(result != null)
                {
                    return this.Ok(new { success = true, message = "Note Created  Successful", data = result });

                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Note creation UnSuccessful" });

                }


            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("Retrive")]

        public IActionResult GetAllNotes()
        {
            long id = Convert.ToInt32(User.FindFirst("Id").Value);
            try
            {
                var result = this.noteBL.GetAllNotes(id).ToList();
                if(result != null)
                {
                    return this.Ok(new { success = true, message = "retrive notes  Successful", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "retrive Note UnSuccessful found null" });

                }
            }
            catch(Exception)
            {
                throw;
            }

        }

        [HttpGet("redis")]
        public async Task<IActionResult> GetAllNotesUsingMemoryCache()
        {
            var cacheKey = "NoteList";
            string serializedNoteList;
            var NoteList = new List<Notesentity>();
            var redisNoteList = await distributedCache.GetAsync(cacheKey);
            if (redisNoteList != null)
            {
                serializedNoteList = Encoding.UTF8.GetString(redisNoteList);
                NoteList = JsonConvert.DeserializeObject<List<Notesentity>>(serializedNoteList);
            }
            else
            {
                var userId = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                NoteList = (List<Notesentity>)this.noteBL.GetAllNotes(userId);
                serializedNoteList = JsonConvert.SerializeObject(NoteList);
                redisNoteList = Encoding.UTF8.GetBytes(serializedNoteList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributedCache.SetAsync(cacheKey, redisNoteList, options);
            }
            return Ok(NoteList);
        }

        [HttpPut("Update")]

        public IActionResult UpdateNote(long Id,NoteUpdation updation)
        {
            try
            {
                long userId = GetUserId();
                var result = this.noteBL.UpdateNotes(Id, userId, updation);
                if(result != null)
                {
                    return this.Ok(new { success = true, message = "Note updated  Successful", data = result });

                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Updation note unsuccessfull" });

                }
            }
            catch(Exception)
            {
                throw;
            }

        }

        [HttpDelete("Delete")]

        public IActionResult DeleteNote(long noteId)
        {
            try
            {
                long userId = GetUserId();
                var result = this.noteBL.DeleteNote(userId, noteId);
                if(result == true)
                {
                    return this.Ok(new { success = true, message = "Note Deleted   Successful" });

                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Note Deletion unsuccessfull" });

                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPut("IsPinned")]

        public IActionResult Pinned(long noteId)
        {
            try
            {


                long userId = GetUserId();
                var result = this.noteBL.Ispinned(userId, noteId);
                if (result == true)
                {
                    return this.Ok(new { success = false, message = "Note pinned" });

                }
                else
                {
                    return this.BadRequest(new { success = false, message = "remain same" });

                }
            }
            catch(Exception)
            {
                throw;
            }

        }

       
        [HttpPut("IsTrash")]
        public IActionResult Trash(long noteId)
        {
            try
            {


                long userId = GetUserId();
                var result = this.noteBL.IsTrash(userId, noteId);
                if (result == true)
                {
                    return this.Ok(new { success = false, message = "Note Trashed" });

                }
                else
                {
                    return this.BadRequest(new { success = false, message = "remain same" });

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPut("IsArchieve")]

        public IActionResult Archieve(long noteId)
        {
            try
            {


                long userId = GetUserId();
                var result = this.noteBL.IsArchieve(userId, noteId);
                if (result == true)
                {
                    return this.Ok(new { success = false, message = "Note Archieved" });

                }
                else
                {
                    return this.BadRequest(new { success = false, message = "remain same" });

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPut("Image")]

        public IActionResult UploadImage(IFormFile file,long noteId)
        {
            try
            {
                var result = this.noteBL.UploadImage(file, noteId);
                if(result == true)
                {
                    return this.Ok(new { success = false, message = "Note Image Added  successfully" });

                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Image uploading unsuccessful" });

                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPut("changecolor")]

        public IActionResult ChangeColor(string color,long noteId)
        {
            long Id = GetUserId();
            var result = this.noteBL.ChangeColor(color, Id, noteId);
            if(result == true)
            {
                return this.Ok(new { success = false, message = "Note color changes  successfully" });

            }
            else
            {
                return this.BadRequest(new { success = false, message = "color change unsuccessful" });

            }
        }

    }
}
