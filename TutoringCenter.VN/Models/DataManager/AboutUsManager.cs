using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.EF;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Models.DataManager
{
    public class AboutUsManager : IDataRepository<AboutUs>
    {
       private readonly TutoringCenterDbContext _context;
        public AboutUsManager(TutoringCenterDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(AboutUs entity)
        {
            _context.Abouts.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(AboutUs entity)
        {
            _context.Abouts.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<AboutUs> Get(long id)
        {
            return await _context.Abouts.FirstOrDefaultAsync(e => e.AUId == id);
        }

        public Task<AboutUs> Get(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AboutUs> GetAlbyIntPara(int param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AboutUs> GetAlbyUId(int param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AboutUs> GetAll()
        {
            return _context.Abouts.ToList();
        }

        public async Task<int> Update(AboutUs dbEntity, AboutUs entity)
        {
            dbEntity.AUId = entity.AUId;
            dbEntity.Title = entity.Title;
            dbEntity.Content = entity.Content;
            dbEntity.UId = entity.UId;
            dbEntity.CreateAt = entity.CreateAt;
            dbEntity.UpdateAt = entity.UpdateAt;
            return await _context.SaveChangesAsync();
        }
    }
}
