﻿using AWS_BusinessObjects.Common.Interfaces;
using AWS_BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_DAO
{
    public class PaymentMethodDAO
    {
        private readonly IApplicationDbContext _context;
        public PaymentMethodDAO(IApplicationDbContext context)
        {
            _context = context;
        }

        public PaymentMethodDAO()
        {
        }

        // get all PaymentMethod
        public List<PaymentMethod> GetAll()
        {
            try
            {
                List<PaymentMethod> paymentMethods
                    = (List<PaymentMethod>)_context.Get<PaymentMethod>().ToList();
                return paymentMethods;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // get PaymentMethod by id
        public PaymentMethod GetById(Guid id)
        {
            try
            {
                return _context.Get<PaymentMethod>().Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // add PaymentMethod
        public void Add(PaymentMethod paymentMethod)
        {
            try
            {
                _context.Get<PaymentMethod>().Add(paymentMethod);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // update PaymentMethod
        public void Update(PaymentMethod paymentMethod)
        {
            try
            {
                _context.Get<PaymentMethod>().Update(paymentMethod);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //delete PaymentMethod, isDeleted = true
        public void Delete(Guid id)
        {
            try
            {
                var paymentMethod = _context.Get<PaymentMethod>().Where(o => o.Id == id).FirstOrDefault();
                paymentMethod.IsDeleted = true;
                _context.Get<PaymentMethod>().Update(paymentMethod);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}