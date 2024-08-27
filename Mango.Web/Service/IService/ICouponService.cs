﻿using Mango.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync( int id);

        Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto );

        Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto);

        Task<ResponseDto?> DeleteCouponsAsync(int id);


    }
}
