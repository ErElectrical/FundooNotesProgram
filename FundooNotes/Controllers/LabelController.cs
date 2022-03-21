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
    public class LabelController : Controller
    {
        private readonly ILabelBL labelBL;
        private readonly IMemoryCache memoryCache;

        private readonly IDistributedCache distributedCache;
        public LabelController(ILabelBL labelBL, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.labelBL = labelBL;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
        }

        [HttpPost("Create")]
        public IActionResult AddLabel(long noteId, LabelRequest label)
        {
            try
            {
                var result = this.labelBL.AddLabel(noteId, label);
                if(result == true)
                {
                    return this.Ok(new { Success = true, message = "lable added SuccessFully." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "lable not added" });
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("Delete")]

        public IActionResult DeleteLabel(long labelId)
        {
            try
            {
                var result = this.labelBL.DeleteLabel(labelId);
                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "lable Deleted SuccessFully" });

                }
                else
                {
                    return this.Ok(new { Success = true, message = "lable deletion unsuccessFull" });
                }
            }
            catch(Exception)
            {
                throw;
            }



        }

        [HttpPut("Update")]
        public IActionResult UpdateLabel(long LabelId,LabelRequest Label)
        {
            try
            {
                var result = this.labelBL.UpdateLabel(LabelId, Label);
                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "lable Updated SuccessFully" ,Data=result});

                }
                else
                {
                    return this.Ok(new { Success = true, message = "lablel updated  unsuccessFull" });
                }

            }
            catch(Exception)
            {
                throw;
            }
        }
        
        [HttpGet("Retrive")]
        public IActionResult GetAllNoteOfLabel(long LabelId)
        {
            try
            {
                var result = this.labelBL.GetAllNoteOfLabel(LabelId);
                if(result != null)
                {
                    return this.Ok(new { Success = true, message = "lable retrived SuccessFully", Data = result });

                }
                else
                {
                    return this.Ok(new { Success = true, message = "lablel retrived  unsuccessFull" });
                }

            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("Redis")]

        public async Task<IActionResult> GetAllLabelNoteUsingMemoryCache(long LabelId)
        {
            var cacheKey = "LabelNoteList";
            string serializedLabelNoteList;
            var LabelNoteList = new List<long>();
            var redisLabelNoteList = await distributedCache.GetAsync(cacheKey);
            if (redisLabelNoteList != null)
            {
                serializedLabelNoteList = Encoding.UTF8.GetString(redisLabelNoteList);
                LabelNoteList = JsonConvert.DeserializeObject<List<long>>(serializedLabelNoteList);
            }
            else
            {
               // var LabelId = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "LabelId").Value);
                LabelNoteList = this.labelBL.GetAllNoteOfLabel(LabelId);
                serializedLabelNoteList = JsonConvert.SerializeObject(LabelNoteList);
                redisLabelNoteList = Encoding.UTF8.GetBytes(serializedLabelNoteList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributedCache.SetAsync(cacheKey, redisLabelNoteList, options);
            }
            return Ok(LabelNoteList);
        }



    }
}
