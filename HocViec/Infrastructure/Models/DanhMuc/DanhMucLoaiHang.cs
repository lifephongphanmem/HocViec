﻿using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.DanhMuc
{
    public class DanhMucLoaiHang: BaseModel
    {
        [Required(ErrorMessage = "Họ tên không được để trống.")]
        public string TenLoaiHang { get; set; }

        public string? GhiChu { get; set; }

        public Boolean TrangThai {  get; set; }

        public DateTime? NgayDung { get; set; }
    }
}
