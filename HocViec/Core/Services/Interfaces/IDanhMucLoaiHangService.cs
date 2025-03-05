using Infrastructure.Models.DanhMuc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IDanhMucLoaiHangService
    {
        Task<List<DanhMucLoaiHang>> GetAllDanhMucLoaiHangAsync();

        Task<DanhMucLoaiHang?> GetDanhMucLoaiHangByIdAsync(Guid id);

        Task AddDanhMucLoaiHangAsync(DanhMucLoaiHang request);

        Task UpdateDanhMucLoaiHangAsync(DanhMucLoaiHang request);

        Task DeleteDanhMucLoaiHangAsync(Guid id);
    }
}
