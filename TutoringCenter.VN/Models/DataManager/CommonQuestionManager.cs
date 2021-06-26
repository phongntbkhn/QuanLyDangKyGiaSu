using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.EF;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Models.DataManager
{
    public class CommonQuestionManager : IDataRepository<CommonQuestion>
    {
        private readonly TutoringCenterDbContext _context;
        public CommonQuestionManager(TutoringCenterDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(CommonQuestion entity)
        {
            _context.CommonQuestions.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(CommonQuestion entity)
        {
            _context.CommonQuestions.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<CommonQuestion> Get(long id)
        {
            return await _context.CommonQuestions.FirstOrDefaultAsync(e => e.CQId == id);
        }

        public Task<CommonQuestion> Get(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommonQuestion> GetAlbyIntPara(int param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommonQuestion> GetAlbyUId(int param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommonQuestion> GetAll()
        {
            return _context.CommonQuestions.ToList();
        }

        public async Task<int> Update(CommonQuestion dbEntity, CommonQuestion entity)
        {
            dbEntity.CQId = entity.CQId;
            dbEntity.Title = entity.Title;
            dbEntity.Content = entity.Content;
            dbEntity.UId = entity.UId;
            dbEntity.CreateAt = entity.CreateAt;
            dbEntity.UpdateAt = entity.UpdateAt;
            return await _context.SaveChangesAsync();
        }
    }
}
