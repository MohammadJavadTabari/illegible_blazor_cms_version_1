﻿using AutoMapper;
using illShop.Shared.Dto.DtosRelatedIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace illShop.Server.Controllers.Identity
{
    [Route("AccountHandelMethods")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public AccountsController(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();
            var user = new IdentityUser { UserName = userForRegistration.Email, Email = userForRegistration.Email };
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }
            await _userManager.AddToRoleAsync(user, "Viewer");
            return StatusCode(201);
        }

        [HttpGet]
        [Route("GetAllSiteUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(_mapper.Map<List<UserDetailDto>>(await _userManager.Users.AsNoTracking().ToListAsync()));
        }
    }
}
