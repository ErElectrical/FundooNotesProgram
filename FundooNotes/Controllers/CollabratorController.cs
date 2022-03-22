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
using System.Text;
using Newtonsoft.Json;

namespace FundooNotes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class CollabratorController : Controller
    {
        private readonly ICollabratorBL collabratorBL;

        private readonly IMemoryCache memoryCache;

        private readonly IDistributedCache distributedCache;
   

        public CollabratorController(ICollabratorBL collabratorBL, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.collabratorBL = collabratorBL;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
        }

        private long GetUserId()
        {
            long Id;
            Id = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
            return Id;
        }
        [HttpPost("AddCollabrator")]
        public IActionResult AddCollabrator(long noteId, CollabratorRequest Email)
        {
            try
            {


                var userId = GetUserId();
                var result = this.collabratorBL.AddCollabrator(userId, noteId, Email);
                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "collaborator added SuccessFully." });

                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "collaborator not added" });
                }
            }
            catch(Exception)
            {
                return this.BadRequest(new { Success = false, message = "something went wrong check me later to fix " });

            }
        }

        [HttpDelete("DeleteCollabrator")]

        public IActionResult DeleteCollabrator(long noteId,CollabratorRequest Email)
        {
            try
            {


                var userId = GetUserId();
                var result = this.collabratorBL.DeleteCollabrator(noteId, userId, Email);
                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "collaborator Deleted successfully" });

                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "collaborator not added" });

                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("RetriveCollabrator")]

        public IActionResult GetCollabrator(long noteId)
        {
            try
            {


                var userId = GetUserId();
                var result = this.collabratorBL.GetAllColabator(noteId, userId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "collaborator retrive successfully", data = result });

                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "collaborator retriving fail " });
                }
    
            
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("redis")]

        public async Task<IActionResult> GetAllCollabUsingMemoryCache(long noteId)
        {
            var cacheKey = "CollabList";
            string serializedCollabList;
            var CollabList = new List<string>();
            var redisCollabList = await distributedCache.GetAsync(cacheKey);
            if (redisCollabList != null)
            {
                serializedCollabList = Encoding.UTF8.GetString(redisCollabList);
                CollabList = JsonConvert.DeserializeObject<List<string>>(serializedCollabList);
            }
            else
            {
                var userId = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                CollabList = this.collabratorBL.GetAllColabator(userId,noteId);
                serializedCollabList = JsonConvert.SerializeObject(CollabList);
                redisCollabList = Encoding.UTF8.GetBytes(serializedCollabList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributedCache.SetAsync(cacheKey, redisCollabList, options);
            }
            return Ok(CollabList);
        }

    }
}
