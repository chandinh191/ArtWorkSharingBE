﻿using AWS_BusinessObjects.Common.Interfaces;
using AWS_BusinessObjects.Entities;
using AWS_DAO.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_DAO
{
    public class OrderDAO
    {
        private readonly IApplicationDbContext _context;
        public OrderDAO(IApplicationDbContext context)
        {
            _context = context;
        }

  
        // get all Order
        public List<Order> GetAll()
        {
            try
            {
                List<Order> orders
                    = (List<Order>)_context.Get<Order>()
                    .Include(i => i.Rating)
                    .ToList();
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // get Order by id
        public Order GetById(Guid id)
        {
            try
            {
                return _context.Get<Order>().Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // add Order
        public void Add(Order order)
        {
            try
            {
                _context.Get<Order>().Add(order);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // update Order
        public void Update(Order order)
        {
            try
            {
                var Order = _context.Get<Order>().FirstOrDefault(x => x.Id == order.Id);
                if (Order == null)
                {
                    throw new NotFoundException();
                }
                Order.Price = order.Price;
                Order.isPreOrder = order.isPreOrder;
                Order.LastModified = DateTime.Now;


                _context.Get<Order>().Update(Order);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // delete Order, isDeleted = true
        public void Delete(Guid id)
        {
            try
            {
                Order order = GetById(id);
                order.IsDeleted = true;
                _context.Get<Order>().Update(order);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
