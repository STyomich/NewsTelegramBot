using Core.Entities;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{

    public class UserDataService
    {
        private readonly DataContext _context;

        public UserDataService(DataContext context)
        {
            _context = context;
        }

        public async Task<UserData> GetUserDataAsync(Guid userId)
        {
            return await _context.UserData.FindAsync(userId);
        }

        public async Task AddUserDataAsync(UserData userData)
        {
            await _context.UserData.AddAsync(userData);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserDataAsync(UserData userData)
        {
            _context.UserData.Update(userData);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserData>> GetAllUserDataAsync()
        {
            return await _context.UserData.ToListAsync();
        }

        public async Task DeleteUserDataAsync(Guid userId)
        {
            var userData = await _context.UserData.FindAsync(userId);
            if (userData != null)
            {
                _context.UserData.Remove(userData);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<UserData> GetUserDataByNicknameAsync(string userNickname)
        {
            return await _context.UserData
                                 .FirstOrDefaultAsync(u => u.UserNickname == userNickname);
        }

    }
}