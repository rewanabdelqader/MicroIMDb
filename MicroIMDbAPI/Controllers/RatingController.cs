using MicroIMDb.Application.Dtos;
using MicroIMDb.Application.Services.Rate;
using MicroIMDb.Infrastrcture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace MicroIMDb.API.Controllers
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost("rate-movie")]
        [Authorize(Roles = UserRoles.User)]
        public async Task<IActionResult> RateMovie(AddRatingDto addRatingDto)
        {
            var userId = User.Claims.Where(x => x.Type == JwtRegisteredClaimNames.Jti).FirstOrDefault().Value;
            addRatingDto.userId = userId;
            if (string.IsNullOrEmpty(addRatingDto.userId))
            {
                return BadRequest("User ID is required.");
            }

            var success = await _ratingService.RateMovie(addRatingDto);

            if (success)
            {
                return Ok("Movie rated successfully.");
            }

            return NotFound("Failed to rate the movie.");
        }
    }
}