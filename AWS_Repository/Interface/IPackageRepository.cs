﻿using AWS_BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Repository.Interface
{
    public interface IPackageRepository
    {
        public List<Package> GetAll();
        public Package GetById(Guid id);
        public void Add(Package package);
        public void Update(Package package);
        public void Delete(Guid id);
    }
}