namespace BlazorEcom.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    
    
    private readonly DataContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserController(DataContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    //Register User
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]RegisterModel registerModel)
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
                 return Ok (result);
                 
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt!");
        }
        return BadRequest(registerModel);
    }
    
/*    //Login User
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginModel user)
    {
        if (ModelState.IsValid) // Checks if LoginModel Is Valid 
        {
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, user.RememberMe, false);
            if (result.Succeeded)
            {
                _context.Update(result);
                await _context.SaveChangesAsync();
                return Ok(result);
            }
            
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        }

        return BadRequest();
    }*/
    
}