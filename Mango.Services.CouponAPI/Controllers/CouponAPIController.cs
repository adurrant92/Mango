using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ResponseDto _responce;
        private readonly IMapper _mapper;
        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _responce = new ResponseDto();
            _mapper = mapper;
        }


        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.coupons.ToList();
                _responce.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
            }
            catch (Exception ex)
            {
              _responce.IsSuccess = false;
             _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.coupons.First(u => u.CouponId == id);
               
                _responce.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }


        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetbyCode(string code)
        {
            try
            {
                Coupon obj = _db.coupons.First(u => u.CouponCode.ToLower()== code.ToLower());         

                _responce.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.coupons.Add(obj);
                _db.SaveChanges();
                _responce.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.coupons.Update(obj);
                _db.SaveChanges();
                _responce.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpDelete]
        [Route("{id}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj = _db.coupons.First(u => u.CouponId == id);
                _db.coupons.Remove(obj);
                _db.SaveChanges();
                
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }
    }
}
