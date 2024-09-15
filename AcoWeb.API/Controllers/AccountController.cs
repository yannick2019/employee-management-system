using System.Security.Claims;
using AcoWeb.API.DTOs;
using AcoWeb.API.Entities;
using AcoWeb.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcoWeb.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly TokenService _tokenService;

    public AccountController(UserManager<AppUser> userManager, TokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;

    }

    /// <summary>
    /// Authenticates a user based on the provided login credentials.
    /// </summary>
    /// <param name="loginDto">The login data transfer object containing the user's email and password.</param>
    /// <returns>
    /// An ActionResult containing the authenticated user's data transfer object.
    /// If the authentication is successful, it returns an Ok result with the user data.
    /// If the user is not found or the password is incorrect, it returns an Unauthorized result.
    /// </returns>
    /// <response code="200">If the user was successfully authenticated.</response>
    /// <response code="401">If the user is not found or the password is incorrect.</response>
    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user == null) return Unauthorized();

        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (result)
        {
            return CreateUserObject(user);
        }

        return Unauthorized();
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="registerDto">The registration data transfer object containing the user's details.</param>
    /// <returns>
    /// An ActionResult containing the registered user's data transfer object.
    /// If the registration is successful, it returns an Ok result with the user data.
    /// If the username or email is already taken, it returns a BadRequest result.
    /// If the registration fails, it returns a BadRequest result with the errors.
    /// </returns>
    /// <response code="200">If the user was successfully registered.</response>
    /// <response code="400">If the username or email is already taken, or if the registration fails.</response>
    [AllowAnonymous]
    [HttpPost("register")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
        {
            return BadRequest("Username is already taken");
        }

        if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
        {
            return BadRequest("Email is already taken");
        }

        var user = new AppUser
        {
            DisplayName = registerDto.DisplayName,
            Email = registerDto.Email,
            UserName = registerDto.Username
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (result.Succeeded)
        {
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Image = null,
                Username = user.UserName!
            };
        }

        return BadRequest(result.Errors);
    }

    /// <summary>
    /// Retrieves the currently authenticated user.
    /// </summary>
    /// <returns>
    /// An ActionResult containing the current user's data transfer object.
    /// If the user is authenticated, it returns an Ok result with the user data.
    /// </returns>
    /// <response code="200">If the user is successfully retrieved.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email)!);

        return CreateUserObject(user!);
    }

    /// <summary>
    /// Deletes an existing user.
    /// </summary>
    /// <param name="email">The email of the user to be deleted.</param>
    /// <returns>
    /// An IActionResult indicating the result of the delete operation.
    /// If the operation is successful, it returns a NoContent result.
    /// If the user is not found, it returns a NotFound result.
    /// </returns>
    /// <response code="204">If the user was successfully deleted.</response>
    /// <response code="404">If the user is not found.</response>
    [Authorize]
    [HttpDelete("{email}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return NotFound("User not found");
        }

        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded)
        {
            return NoContent();
        }

        return BadRequest("Error deleting user");
    }

    /// <summary>
    /// Creates a UserDto object from an AppUser object.
    /// </summary>
    /// <param name="user">The AppUser object containing the user's details.</param>
    /// <returns>
    /// A UserDto object containing the user's display name, image, token, and username.
    /// </returns>
    private UserDto CreateUserObject(AppUser user)
    {
        return new UserDto
        {
            DisplayName = user.DisplayName,
            Image = null,
            Token = _tokenService.CreateToken(user),
            Username = user.UserName!
        };
    }
}
