using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.EF;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Models.DataManager
{
    public class NewsCategoryManager : IDataRepository<NewsCategory>
    {
        TutoringCenterDbContext _context;
        public NewsCategoryManager(TutoringCenterDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(NewsCategory entity)
        {
            _context.NewsCategories.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(NewsCategory entity)
        {
            _context.NewsCategories.Remove(entity);
             return await _context.SaveChangesAsync();
        }

        public async Task<NewsCategory> Get(long id)
        {
            return await _context.NewsCategories.FirstOrDefaultAsync(e => e.NCId == id);
        }

        public Task<NewsCategory> Get(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NewsCategory> GetAlbyIntPara(int param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NewsCategory> GetAlbyUId(int param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NewsCategory> GetAll()
        {
            return  _context.NewsCategories.ToList();
        }

        public async Task<int> Update(NewsCategory dbEntity, NewsCategory entity)
        {
            dbEntity.NCId = entity.NCId;
            dbEntity.Name = entity.Name;
            dbEntity.Description = entity.Description;
            dbEntity.CreateAt = entity.CreateAt;
            dbEntity.UpdateAt = entity.UpdateAt;
            return await _context.SaveChangesAsync();
        }
    }
}
