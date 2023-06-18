using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Result> Add(Order entity)
        {
            await _orderRepository.Add(entity);
            return new SuccessResult("Siparis olusturuldu.");
        }

        public async Task<Result> Delete(Order entity)
        {
            await _orderRepository.Delete(entity);
            return new SuccessResult("Siparis silindi");
        }

        public async Task<IDataResult<List<Order>>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(await _orderRepository.GetAll(), "Siparisler donduruldu");
        }

        public async Task<IDataResult<List<OrderDetailsDto>>> GetAllDetailsDto()
        {
            return new SuccessDataResult<List<OrderDetailsDto>>(await _orderRepository.GetAllOrderDetailsDto(),"Siparis detaylari donduruldu");
        }

        public async Task<IDataResult<Order>> GetById(int id)
        {
            return new SuccessDataResult<Order>(await _orderRepository.Get(o => o.Id == id), "Istenilen siparis getirildi.");
        }

        public async Task<Result> Update(Order entity)
        {
            await _orderRepository.Update(entity);
            return new SuccessResult("Siparis guncellendi.");
        }

        public Result UpdateNotAsync(Order order)
        {
            _orderRepository.UpdateNotAsync(order);
            return new SuccessResult("Siparis guncellendi.");

        }
    }
}
