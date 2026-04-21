using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCT_BACKEND.Data;
using QLCT_BACKEND.Models;

namespace QLCT_BACKEND.Controllers
{
    [Route("api/public")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/public/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Tìm user theo số điện thoại
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);

            if (user != null && user.Password == request.Password)
            {
                // Đảm bảo có Role mặc định nếu database đang để trống
                if (string.IsNullOrEmpty(user.Role)) user.Role = "USER";
                
                return Ok(user);
            }

            return Unauthorized(new { message = "Sai số điện thoại hoặc mật khẩu!" });
        }

        // POST: api/public/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            // Kiểm tra SĐT tồn tại
            var existingUser = await _context.Users
                .AnyAsync(u => u.PhoneNumber == user.PhoneNumber);

            if (existingUser)
            {
                return BadRequest(new { message = "Số điện thoại này đã tồn tại!" });
            }

            if (string.IsNullOrEmpty(user.Role)) user.Role = "USER";

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đăng ký thành công!" });
        }
    }

    // Lớp hỗ trợ nhận dữ liệu login
    public class LoginRequest
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}