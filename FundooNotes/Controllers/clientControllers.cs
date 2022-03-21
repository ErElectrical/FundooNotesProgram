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
using DotNetOpenAuth.InfoCard;
using System.Security.Claims;


namespace FundooNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;



        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;

        }
        /// <summary>
        /// IActionresult is a contract that is satisfied by the ActionResult class
        /// provide a significant chunk of the functionality you'll be using in your controllers.
        /// They return status codes, objects, files, other content, and even redirect the client. 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public IActionResult Registration(UserRegistration user)
        {
            try
            {
                var result = userBL.Registration(user);
                if (result != null)
                    return this.Ok(new { success = true, message = "Registration Successful", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Registration UnSuccessful" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("Login")]
        public IActionResult Login(UserLogin user)
        {
            try
            {
                var result = userBL.login(user);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Login Successful", data = result });

                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Login UnSuccessful" });

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("forgetpassword")]

        public IActionResult ForgetPassword(string email)
        {
            try
            {
                var result = this.userBL.ForgetPassword(email);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "mail message sent Successful", data = result });

                }
                else
                {
                    return this.BadRequest(new { success = false, message = "sent mailmessage UnSuccessful" });

                }
            }
            catch (Exception )
            {
                return this.BadRequest(new { success = false, message = "something went wrong check later" });

            }
        }

        [HttpPut("ResetPassword")]

        public IActionResult ResetPassword(string password, string confirmpassword)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = this.userBL.ResetPassWord(email, password, confirmpassword);
                if (!result)
                {
                    return this.BadRequest(new { success = false, message = "reset password is  UnSuccessful" });


                }
                else
                {
                    return this.Ok(new { success = true, message = "reset password is  Successful" });

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

    }

}
