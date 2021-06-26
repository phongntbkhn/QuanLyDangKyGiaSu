using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.EF;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Models.DataManager
{
    public class NewsManager : IDataRepository<News>
    {
        TutoringCenterDbContext _context;
        public NewsManager(TutoringCenterDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(News entity)
        {
            _context.TheNews.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(News entity)
        {
            _context.TheNews.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<News> Get(long id)
        {
            return await _context.TheNews.FirstOrDefaultAsync(e => e.NId == id);
        }

        public Task<News> Get(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> GetAll()
        {
            return _context.TheNews.ToList();
        }
        public IEnumerable<News> GetAll(long ncId)
        {
            return _context.TheNews.Where(x => x.NCId == ncId).ToList();
        }
        public async Task<int> Update(News dbEntity, News entity)
        {
            dbEntity.NId = entity.NId;
            dbEntity.NCId = entity.NCId;
            dbEntity.UId = entity.UId;
            dbEntity.Title = entity.Title;
            dbEntity.Description = entity.Description;
            dbEntity.Content = entity.Content;
            dbEntity.Tags = entity.Tags;
            dbEntity.Image = entity.Image;
            dbEntity.CreateAt = entity.CreateAt;
            dbEntity.UpdateAt = entity.UpdateAt;
            return await _context.SaveChangesAsync();
        }
        public News GetPreviousPost(long currentPostId, long categoryId)
        {
            try
            {
                return _context.TheNews
                .Where(x => x.NId < currentPostId && x.NCId == categoryId)
                .OrderByDescending(x => x.NId)
                .First();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public News GetNextPost(long currentPostId, long categoryId)
        {
            try
            {
                return _context.TheNews
                .Where(x => x.NId > currentPostId && x.NCId == categoryId)
                .OrderBy(x => x.NId)
                .First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<News> GetSize(int size)
        {
            return _context.TheNews.Take(size).ToList();
        }

        public IEnumerable<News> GetAlbyIntPara(int param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> GetAlbyUId(int param)
        {
            throw new NotImplementedException();
        }
    }
}
