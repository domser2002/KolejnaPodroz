using Domain.Admin;
using Domain.Common;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class ComplaintRepository(DomainDBContext context) : Repository<Complaint>(context), IComplaintRepository
    {
    }
}
