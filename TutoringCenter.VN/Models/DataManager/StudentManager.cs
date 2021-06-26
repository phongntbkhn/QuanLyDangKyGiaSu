using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.EF;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Models.DataManager
{
    public class StudentManager : IDataRepository<Student>
    {
        private readonly TutoringCenterDbContext _context;
        public StudentManager(TutoringCenterDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public IEnumerable<Student> GetAlbyIntPara(int status)
        {
            return _context.Students.Where(s => s.Status == status).ToList();
        }

        public IEnumerable<Student> GetAlbyUId(int uid)
        {
            return _context.Students.Where(s => s.UId == uid).ToList();
        }

        public async Task<Student> Get(long id)
        {
            return await _context.Students.FirstOrDefaultAsync(e => e.SId == id);
        }

        public Task<Student> Get(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Add(Student entity)
        {
            _context.Students.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Student dbEntity, Student entity)
        {
            dbEntity.SId = entity.SId;
            dbEntity.TenHocSinh = entity.TenHocSinh;
            dbEntity.SoDienThoai = entity.SoDienThoai;
            dbEntity.Lop = entity.Lop;
            dbEntity.TenPhuHuynh = entity.TenPhuHuynh;
            dbEntity.SdtPhuHuynh = entity.SdtPhuHuynh;
            dbEntity.NgaySinh = entity.NgaySinh;
            dbEntity.NoiOHienTai = entity.NoiOHienTai;
            dbEntity.Status = entity.Status;
            dbEntity.CreateAt = entity.CreateAt;
            dbEntity.UpdateAt = entity.UpdateAt;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Student entity)
        {
            _context.Students.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        
    }
}
