﻿namespace BicycleApp.Services.Services.Factory
{
    using BicicleApp.Common.Providers.Contracts;
    using BicycleApp.Data;
    using BicycleApp.Data.Models.EntityModels;
    using BicycleApp.Services.Contracts.Factory;
    using BicycleApp.Services.Models.Order.OrderUser;
    using BicycleApp.Services.Models.Order.OrderUser.Contracts;

    public class OrderFactory : IOrderFactory
    {   
        //TODO Remove _db, move it to servce.
        private readonly IDateTimeProvider _dateTimeProvider;
        public OrderFactory(BicycleAppDbContext db, IDateTimeProvider dateTimeProvider)
        {
            
            _dateTimeProvider = dateTimeProvider;
        }
        public Order CreateUserOrderAsync(IOrder order, DateTime currentTime)
        {
              return new Order()
                {
                    FinalAmount = order.FinalAmount,
                    PaidAmount = order.PaidAmount,
                    SaleAmount = order.SaleAmount,
                    UnpaidAmount = order.UnpaidAmount,
                    VAT = order.VAT,
                    ClientId = order.ClientId,
                    DateCreated = _dateTimeProvider.Now,
                    Description = order.Description,
                    Discount = order.Discount,
                    IsDeleted = order.IsDeleted,
                    StatusId = order.StatusId
                };
        }
        public IOrderPartDto CreateOrderPartFromUserOrder(string partName, int partQuantity, int partId, decimal productPrice)
        {
            return new OrderPartDto()
            {
                PartName = partName,
                PartQuantity = partQuantity,
                PartId = partId,
                PartPrice = productPrice
            };
        }

        public async Task<OrderPartEmployee> CreateOrderPartEmployeeProduct(int orderId, string uniqueKeyForSerialNumber, string serialNumber, int partId, string partName, int partQuantity, decimal partPrice)
        {
            var ope = new OrderPartEmployee()
            {
                OrderId = orderId,
                PartId = partId,
                PartQuantity = partQuantity,
                PartName = partName,
                PartPrice = partPrice,
                SerialNumber = serialNumber,
                UniqueKeyForSerialNumber = uniqueKeyForSerialNumber
            };

            return  ope;
        }

        public ISuccessOrderInfo CreateSuccessOrderItems(IOrderPartsEmplyee successOrder)
        {
            return new SuccessOrderInfo()
            {
                OrderId = successOrder.OrderId,
                ClientId = successOrder.ClientId,
                FinalAmount = successOrder.FinalAmount,
                PaidAmount = successOrder.PaidAmount,
                SaleAmount = successOrder.SaleAmount,
                UnpaidAmount = successOrder.UnpaidAmount,
                VAT = successOrder.VAT,
                Discount = successOrder.Discount,
                Description = successOrder.Description,
                OrderParts = successOrder.OrderParts.Select(op => new OrderPartDto()
        {
                    PartId = op.PartId,
                    PartName = op.PartName,
                    PartPrice = op.PartPrice * successOrder.OrderQuantity,
                    PartQuantity = successOrder.OrderQuantity
                }).ToList()
            };
        }

    }
}
