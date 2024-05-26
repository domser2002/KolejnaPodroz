﻿using Domain.Admin;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class AdminRepository(DomainDBContext context) : Repository<Admin>(context),IAdminRepository
    {
    }
}
