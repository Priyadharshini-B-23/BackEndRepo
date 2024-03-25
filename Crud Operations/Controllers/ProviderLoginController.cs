using Crud_Operations.Data;
using Crud_Operations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderLoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProviderLoginController(AppDbContext context)
        {
            _context = context;
        }



        [HttpPost]

        public async Task<IActionResult> ProviderLogin(LoginModel loginModel)
        {
            try
            {
                string email = loginModel.Email;
                string password = loginModel.Password;
                JobProviderSignupModel olduser = _context.ProviderSignup.Where(user1 => user1.JobProviderEmailId == email).FirstOrDefault()!;

                if (olduser.JobProviderEmailId == email && olduser != null)
                {
                    if (olduser.JobProviderPassword == password)
                    {
                        return Ok("{\"emailstatus\":true,\"passwordstatus\":true}");
                    }
                    else
                    {
                        return Ok("{\"emailstatus\":true,\"passwordstatus\":false}");
                    }
                }

            }
            catch (Exception ex)
            {
                return Ok("{\"emailstatus\":false,\"passwordstatus\":false}");

            }
            return Ok("{\"emailstatus\":false,\"passwordstatus\":false}");

        }
    }
}

