using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.EF;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Models.DataManager
{
    public class FeedbackManager : IDataRepository<Feedback>
    {
        private readonly TutoringCenterDbContext _context;
        public FeedbackManager(TutoringCenterDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Feedback entity)
        {
            _context.Feedbacks.Add(entity);
           return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Feedback entity)
        {
            _context.Feedbacks.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<Feedback> Get(long id)
        {
            return await _context.Feedbacks.FirstOrDefaultAsync(e => e.FId == id);
        }

        public Task<Feedback> Get(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetAlbyIntPara(int param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetAlbyUId(int param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _context.Feedbacks.ToList();
        }

        public async Task<int> Update(Feedback dbEntity, Feedback entity)
        {
            dbEntity.FId = entity.FId;
            dbEntity.Fullname = entity.Fullname;
            dbEntity.Address = entity.Address;
            dbEntity.Phone = entity.Phone;
            dbEntity.Email = entity.Email;
            dbEntity.Content = entity.Content;
            dbEntity.ReplyByUserId = entity.ReplyByUserId;
            dbEntity.CreateAt = entity.CreateAt;
            dbEntity.UpdateAt = entity.UpdateAt;
            return await _context.SaveChangesAsync();
        }
    }
}
