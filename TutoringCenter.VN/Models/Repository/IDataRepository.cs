using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringCenter.VN.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAlbyIntPara(int param);
        IEnumerable<TEntity> GetAlbyUId(int param);
        Task<TEntity> Get(long id);
        Task<TEntity> Get(string key);
        Task<int> Add(TEntity entity);
        Task<int> Update(TEntity dbEntity, TEntity entity);
        Task<int> Delete(TEntity entity);
    }
}
