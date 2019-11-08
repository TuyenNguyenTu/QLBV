using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.QLBenhVien.Models
{
    public class BenhNhanManager : DomainService,IBenhNhanManager
    {
        private readonly IRepository<BenhNhan, long> _repositoryBenhNhan;
        public BenhNhanManager(IRepository<BenhNhan, long> repositoryBenhNhan)
        {
            _repositoryBenhNhan = repositoryBenhNhan;
        }

        public async Task<BenhNhan> Create(BenhNhan entity)
        {
            var benhNhan = _repositoryBenhNhan.FirstOrDefault(x => x.Id == entity.Id);
            if (benhNhan != null)
            {
                throw new UserFriendlyException("Da ton tai");
            }
            else
            {
                return await _repositoryBenhNhan.InsertAsync(entity);
            }
        }

        public void Delete(long id)
        {
            var benhNhan = _repositoryBenhNhan.FirstOrDefault(x => x.Id == id);
            if (benhNhan == null)
            {
                throw new UserFriendlyException("Ko tim thay");

            }
            else
            {
                _repositoryBenhNhan.Delete(benhNhan);
            }
        }

        public IEnumerable<BenhNhan> GetAllList()
        {
            return _repositoryBenhNhan.GetAll();
        }

        public BenhNhan GetBenhNhanByID(long id)
        {
            return _repositoryBenhNhan.Get(id);
        }

        public void Update(BenhNhan entity)
        {
            _repositoryBenhNhan.Update(entity);
        }
    }
}
