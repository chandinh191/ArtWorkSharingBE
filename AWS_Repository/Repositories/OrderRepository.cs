﻿using AWS_BusinessObjects.Common.Interfaces;
using AWS_BusinessObjects.Entities;
using AWS_DAO;
using AWS_Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDAO _orderDAO;
        public OrderRepository(OrderDAO orderDAO)
        {
            _orderDAO = orderDAO;
        }

        public void Add(Order order)
        => _orderDAO.Add(order);

        public void Delete(Guid id)
        => _orderDAO.Delete(id);

        public List<Order> GetAll()
        => _orderDAO.GetAll();

        public Order GetById(Guid id)
        => _orderDAO.GetById(id);

        public void Update(Order order)
        => _orderDAO.Update(order);
    }
}
