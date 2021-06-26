using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.EF;
using TutoringCenter.VN.Models.Repository;
using TutoringCenter.VN.Utils;

namespace TutoringCenter.VN.Models.DataManager
{
    public class UserManager : IDataRepository<User>
    {
       private readonly TutoringCenterDbContext _context;
        public UserManager(TutoringCenterDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(User entity)
        {
            entity.Username = entity.Username.ToLower();
            entity.EncryptPassword = Password.Encrypt(entity.EncryptPassword);
            entity.Role = entity.Role;
            _context.Users.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(User entity)
        {
            if (entity.Username == "admin")
            {
                throw new System.Exception("Không thể xóa quản trị viên mặc định");
            }
            else
            {
                _context.Users.Remove(entity);
             return  await _context.SaveChangesAsync();
            }
        }

        public async Task<User> Get(long id)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.UId == id);
        }

        public Task<User> Get(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public async Task<int> Update(User dbEntity, User entity)
        {
            dbEntity.UId = entity.UId;
            dbEntity.Username = entity.Username;
            dbEntity.DisplayName = entity.DisplayName;
            dbEntity.Avatar = entity.Avatar;
            dbEntity.Role = entity.Role;
            dbEntity.CreateAt = entity.CreateAt;
            dbEntity.UpdateAt = entity.UpdateAt;
            if (entity.EncryptPassword != null && entity.EncryptPassword.Length > 8)
            {
                dbEntity.EncryptPassword = Password.Encrypt(entity.EncryptPassword);
            }
            return await _context.SaveChangesAsync();
        }
        public async Task<User> Find(string username, string password)
        {
            var found = await _context.Users.FirstOrDefaultAsync(u => u.Username == username.ToLower());
            if (found != null)
            {
             if (found.Username == "admin" && found.EncryptPassword == "admin")
                {
                    return found;
                }
                else if (found.EncryptPassword == Password.Encrypt(password))
                    return found;
                else
                    return null;
            }
            else return null;
        }

        public IEnumerable<User> GetAlbyIntPara(int param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAlbyUId(int param)
        {
            throw new NotImplementedException();
        }
    }
}
