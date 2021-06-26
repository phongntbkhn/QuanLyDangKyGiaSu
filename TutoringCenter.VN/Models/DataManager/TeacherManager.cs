using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.EF;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Models.DataManager
{
    public class TeacherManager : IDataRepository<Teacher>
    {
        private readonly TutoringCenterDbContext _context;
        public TeacherManager(TutoringCenterDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }

        public IEnumerable<Teacher> GetAlbyIntPara(int status)
        {
            return _context.Teachers.Where(s => s.Status == status).ToList();
        }

        public IEnumerable<Teacher> GetAlbyUId(int uid)
        {
            return _context.Teachers.Where(s => s.UId == uid).ToList();
        }

        public async Task<Teacher> Get(long id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(e => e.TId == id);
        }

        public Task<Teacher> Get(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Add(Teacher entity)
        {
            _context.Teachers.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Teacher dbEntity, Teacher entity)
        {
            dbEntity.TId = entity.TId;
            dbEntity.DisplayName = entity.DisplayName;
            dbEntity.Avatar = entity.Avatar;
            dbEntity.Description = entity.Description;
            dbEntity.Cv = entity.Cv;
            dbEntity.SoDienThoai = entity.SoDienThoai;
            dbEntity.Email = entity.Email;
            dbEntity.NgaySinh = entity.NgaySinh;
            dbEntity.CMND = entity.CMND;
            dbEntity.QueQuan = entity.QueQuan;
            dbEntity.NoiOHienTai = entity.NoiOHienTai;
            dbEntity.KhuVucGiangDay = entity.KhuVucGiangDay;
            dbEntity.CreateAt = entity.CreateAt;
            dbEntity.UpdateAt = entity.UpdateAt;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Teacher entity)
        {
            _context.Teachers.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        
    }
}
