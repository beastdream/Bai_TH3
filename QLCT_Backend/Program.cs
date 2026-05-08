using Microsoft.EntityFrameworkCore;
using QLCT_Backend.Data; 

var builder = WebApplication.CreateBuilder(args);

// 1. Lấy chuỗi kết nối từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Cấu hình DbContext sử dụng Pomelo MySQL (Yêu cầu package Pomelo đã cài bản 7.x)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 3. Cấu hình CORS
builder.Services.AddCors(options => {
    options.AddPolicy("AllowReact", policy => 
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Cấu hình Swagger trong môi trường Development
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "QLCT_Backend v1");
    });
}

// Quan trọng: Thứ tự Middlewares
app.UseCors("AllowReact"); 
app.UseAuthorization();
app.MapControllers();

app.Run();