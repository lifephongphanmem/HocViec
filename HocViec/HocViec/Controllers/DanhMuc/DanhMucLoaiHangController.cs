using Core.Services.Interfaces;
using Infrastructure.Models.DanhMuc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HocViec.Controllers.DanhMuc
{
    public class DanhMucLoaiHangController(IDanhMucLoaiHangService danhMucService, ILogger<DanhMucLoaiHangController> logger) : Controller
    {
        private readonly ILogger<DanhMucLoaiHangController> _logger = logger;
        private readonly IDanhMucLoaiHangService _danhMucService = danhMucService;

        [HttpGet("DanhMucLoaiHang")]
        public async Task<IActionResult> Index([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var data = await _danhMucService.GetAllDanhMucLoaiHangAsync();
                return View("~/Views/DanhMuc/DanhMucLoaiHang/Index.cshtml", data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while processing the request.");
                return Ok(e.Message);
            }
        }

        public IActionResult Create()
        {
            return View("~/Views/DanhMuc/DanhMucLoaiHang/Create.cshtml");
        }

        [HttpGet("DanhMucLoaiHang/Edit")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var data = await _danhMucService.GetDanhMucLoaiHangByIdAsync(id);
            return View("~/Views/DanhMuc/DanhMucLoaiHang/Create.cshtml", data);
        }

        [HttpPost("DanhMucLoaiHang/CreateOrUpdate")]
        public async Task<IActionResult> Create_Update(DanhMucLoaiHang request)
        {
            try
            {
                var danhMuc = _danhMucService.GetDanhMucLoaiHangByIdAsync(request.Id);
                if (danhMuc == null)
                {
                    await _danhMucService.AddDanhMucLoaiHangAsync(request);
                }
                else
                {
                    await _danhMucService.UpdateDanhMucLoaiHangAsync(request);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while processing the request.");
                return Ok(e.Message);

            }
        }

        [HttpGet("DanhMucLoaiHang/Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _danhMucService.DeleteDanhMucLoaiHangAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while processing the request.");
                return Ok(e.Message);
            }
        }
    }
}
