using Abp.Application.Services;
using AutoMapper;
using Project.QLBenhVien.BenhNhans.DTO;
using Project.QLBenhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Project.QLBenhVien.BenhNhans
{
    public class BenhNhanAppService : ApplicationService, IBenhNhanAppService
    {
        private readonly IBenhNhanManager _benhNhanManager;
        public BenhNhanAppService(IBenhNhanManager benhNhanManager)
        {
            _benhNhanManager = benhNhanManager;
        }
        [Obsolete]
        [HttpGet]
        public async Task Create(CreateBenhNhanInput input)
        {
            BenhNhan output = Mapper.Map<CreateBenhNhanInput, BenhNhan>(input);
            await _benhNhanManager.Create(output);
        }
        [Obsolete]
        [HttpDelete]
        public void Delete(DeleteBenhNhanInput input)
        {
            _benhNhanManager.Delete(input.Id);
        }

        [Obsolete]
        [HttpGet]
        public GetBenhNhanOutput GetBenhNhanById(GetBenhNhanInput input)
        {
            var getBenhNhan = _benhNhanManager.GetBenhNhanByID(input.Id);
            GetBenhNhanOutput output = Mapper.Map<BenhNhan, GetBenhNhanOutput>(getBenhNhan);
            return output;
        }
        [Obsolete]
        [HttpGet]
        public IEnumerable<GetBenhNhanOutput> ListAll()
        {
            var getAll = _benhNhanManager.GetAllList().ToList();
            List<GetBenhNhanOutput> output = Mapper.Map<List<BenhNhan>, List<GetBenhNhanOutput>>(getAll);
            return output;
        }
        [Obsolete]
        [HttpGet]
        public void Update(UpdateBenhNhanInput input)
        {
            BenhNhan ouput = Mapper.Map<UpdateBenhNhanInput, BenhNhan>(input);
            _benhNhanManager.Update(ouput);
        }
    }
}
