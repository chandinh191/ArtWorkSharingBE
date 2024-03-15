﻿using Microsoft.AspNetCore.Mvc;
using AWS_BusinessObjects.Models;
using AWS_Repository.Identity;




namespace ArtWorkSharingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAccountRepository accountRepository;

        public AuthController(IAccountRepository iAccountRepository)
        {
            accountRepository = iAccountRepository;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            try
            {
                var result = await accountRepository.SignUpAsync(model);
                if (result.Succeeded)
                {
                    return Ok(result.Succeeded);
                }
                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var result = await accountRepository.SignInAsync(model);
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("Sai tên đăng nhập hoặc mật khẩu!");
            }
            return Ok(result);
        }



        [HttpGet("GetAudienceAcount")]
        public async Task<IActionResult> GetAudienceAcount()
        {
            var result = await accountRepository.GetAudienceAcountAsync();
            return Ok(result);
        }
        [HttpGet("GetArtistAcount")]
        public async Task<IActionResult> GetArtistAcount()
        {
            var result = await accountRepository.GetArtistAcountAsync();
            return Ok(result);
        }
        [HttpGet("GetAdministratorAcount")]
        public async Task<IActionResult> GetAdministratorAcountAsync()
        {
            var result = await accountRepository.GetAdministratorAcountAsync();
            return Ok(result);
        }

    }
}
