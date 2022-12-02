
namespace BlazorEcom.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly DataContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public UserController(DataContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet("{name}")]
    public IdentityUser Get(string name)
    {
        return _signInManager.UserManager.FindByNameAsync(name).Result;
    }

    //Register User
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
    {
        if (ModelState.IsValid)
        {
            var userExists = await _userManager.FindByNameAsync(registerModel.Username);
            if (userExists != null)
                return BadRequest();
            var user = new ApplicationUser
            {
                UserName = registerModel.Username
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
                await _signInManager.PasswordSignInAsync(user.UserName, registerModel.Password, false, false);
                return Ok(result);

            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt!");
        }
        return BadRequest(registerModel);
    }

    //Login User
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginModel user)
    {
        if (ModelState.IsValid) // Checks if LoginModel Is Valid 
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);
            if (result.Succeeded)
            {
                return Ok(result);
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        }

        return BadRequest();
    }
    [HttpPost("logout")]
    public async Task<IActionResult> Logout(ApplicationUser user)
    {

        await _signInManager.SignOutAsync();
        return Ok(user);
    }

    [Authorize]
    [HttpGet("getuser")]
    public async Task<IActionResult> GetUserById(string userid)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(userid);
            return Ok(user);
        }
        return BadRequest();
    }
    [Authorize]
    [HttpGet("getcurrent")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var user = await HttpContext.GetUserAsync(_context);
        return user != null ? Ok(user) : NotFound();
    }
}