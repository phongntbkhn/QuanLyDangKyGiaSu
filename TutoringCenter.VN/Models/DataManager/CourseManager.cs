using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.EF;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Models.DataManager
{
    public class CourseManager : IDataRepository<Course>
    {
        private readonly TutoringCenterDbContext _context;
        public CourseManager(TutoringCenterDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Course entity)
        {
            _context.Courses.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Course entity)
        {
            _context.Courses.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<Course> Get(long id)
        {
           return await _context.Courses.FirstOrDefaultAsync(e => e.CId == id);
        }

        public Task<Course> Get(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAlbyIntPara(int param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAlbyUId(int param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public async Task<int> Update(Course dbEntity, Course entity)
        {
            dbEntity.CId = entity.CId;
            dbEntity.TId = entity.TId;
            dbEntity.Name = entity.Name;
            dbEntity.IdKhoi = entity.IdKhoi;
            dbEntity.IdLop = entity.IdLop;
            dbEntity.Price = entity.Price;
            dbEntity.LearningTime = entity.LearningTime;
            dbEntity.Description = entity.Description;
            dbEntity.Detail = entity.Detail;
            dbEntity.Schedule = entity.Schedule;
            dbEntity.CreateAt = entity.CreateAt;
            dbEntity.UpdateAt = entity.UpdateAt;
            dbEntity.Image = entity.Image;
            return await _context.SaveChangesAsync();

        }
    }
}
