using JobVisionTest.Domain.DTOs;
using JobVisionTest.Domain.Entities;
using JobVisionTest.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobVisionTest.Infrastructure
{
    public class UserConfig : IUserConfig
    {
        private readonly JobVisionTestContext _context;
        public UserConfig()
        {
            _context = new JobVisionTestContext();
        }

        public async Task<bool> AddUser(UserDTO user)
        {
            try
            {
                var newUser = new User
                {
                    Name = user.Name,
                    Family = user.Family,
                    ProfileImageUrl = user.ProfileImageUrl,
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                _context.UserDeatalis.Add(new UserDeatali
                {
                    UserId = newUser.Id,
                    Age = user.Age,
                    Gender = user.Gender
                });
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }


        public async Task<bool> RemoveUser(UserDTO user)
        {
            var User = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            try
            {
                if(User != null)               
                    _context.Users.Remove(User);
                        await _context.SaveChangesAsync();

                var UserDeatal = _context.UserDeatalis.FirstOrDefault(x => x.Id == user.Id);
                if(UserDeatal != null)
                    _context.UserDeatalis.Remove(UserDeatal);
                        await _context.SaveChangesAsync();


                return true;
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateUser(UserDTO user)
        {
            var User = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            try
            {
                if(User != null)
                    _context.Users.Update(User);
                       await _context.SaveChangesAsync();

                var UserDeatal = _context.UserDeatalis.FirstOrDefault(x => x.Id == user.Id);
                if (UserDeatal != null)
                    UserDeatal.Gender = user.Gender;
                    UserDeatal.Age = user.Age;
                       await _context.SaveChangesAsync();

                    return true;
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }
    }
}
