using Demo_Web_API.Data;
using Demo_Web_API.Models;
using Demo_Web_API.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Demo_Web_API.Services
{
    public class UserService
    {
        private readonly AppDBContext _appDBContext;

        public UserService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<User> RegisterUserAsync(RegisterUserDto dto)
        {

            // Validar si el email ya existe
            if (await _appDBContext.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("El email ya está registrado.");

            // Crear usuario con contraseña hasheada
            var user = new User
            {
                Email = dto.Email,
                UserName = dto.UserName,
                PasswordHash = HashPassword(dto.Password) 
            };

            _appDBContext.Users.Add(user);
            await _appDBContext.SaveChangesAsync();
            return user;
        }
        public async Task<List<User>> Obtener()
        {
            return await _appDBContext.Users
                .Select(u => new User
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    PasswordHash = u.PasswordHash 
                })
                .ToListAsync();
        }

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}