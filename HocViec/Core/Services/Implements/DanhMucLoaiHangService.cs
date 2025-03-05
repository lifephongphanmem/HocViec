using AutoMapper;
using Azure.Core;
using Core.Services.Interfaces;
using Infrastructure.Models.DanhMuc;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Implements
{
    public class DanhMucLoaiHangService (IRepository<DanhMucLoaiHang> danhMucRepo) : IDanhMucLoaiHangService
    {
        public async Task<List<DanhMucLoaiHang>> GetAllDanhMucLoaiHangAsync()
        {
            var data = await danhMucRepo.GetAllAsync();
            return data.ToList();
        }

        public async Task<DanhMucLoaiHang?> GetDanhMucLoaiHangByIdAsync(Guid id)
        {
            var data = await danhMucRepo.GetByIdAsync(id);
            //var response = new DanhMucLoaiHang();
            //if (data != null)
            //{
            //    Helper.CommonHelper.MapProperties(data, response);
            //}
            //return response;
            return data;
        }

        public async Task AddDanhMucLoaiHangAsync(DanhMucLoaiHang request)
        {
            var (danhMuc, errors) = Helper.CommonHelper.MapAndValidate<DanhMucLoaiHang>(request);
            if (errors != null)
            {
                throw new Exception(string.Join("; ", errors));
            }
            await danhMucRepo.AddAsync(danhMuc);
           
        }

        public async Task UpdateDanhMucLoaiHangAsync(DanhMucLoaiHang request)
        {
            var danhMuc = await GetDanhMucLoaiHangByIdAsync(request.Id) ?? throw new Exception("Không tìm thấy dữ liệu.");
            Helper.CommonHelper.MapProperties(request, danhMuc);
            await danhMucRepo.UpdateAsync(danhMuc);
        }

        public async Task DeleteDanhMucLoaiHangAsync(Guid id)
        {
           
            var danhMuc = await GetDanhMucLoaiHangByIdAsync(id) ?? throw new Exception("Không tìm thấy dữ liệu.");
          
            try
            {
                await danhMucRepo.BeginTransactionAsync();
                await danhMucRepo.DeleteAsync(danhMuc);
                await danhMucRepo.CommitAsync();
            }
            catch (Exception)
            {
                await danhMucRepo.RollbackAsync();
                throw;
            }

        }
    }
}
