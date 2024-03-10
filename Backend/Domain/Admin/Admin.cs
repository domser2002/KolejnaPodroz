using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Admin
{
    public class Admin : Base
    {
        public bool AddProvider(Provider provider)
        {
            throw new NotImplementedException();
        }
        public bool EditProvider()
        { 
            throw new NotImplementedException();
        }
        public bool RemoveProvider(int providerID) 
        {
            throw new NotImplementedException();
        }
        public List<Provider> ListProviders() 
        {
            throw new NotImplementedException();
        }
        public List<Complaint> ListComplaints() 
        {
            throw new NotImplementedException();
        }
        public void AnswerComplaint(Complaint complaint, string answer) 
        {
            throw new NotImplementedException();
        }
    }
}
