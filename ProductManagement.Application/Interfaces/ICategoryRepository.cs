﻿using ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> CategoryExists(int id);
    }
}
