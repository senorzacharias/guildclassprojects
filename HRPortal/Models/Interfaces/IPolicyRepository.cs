using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IPolicyRepository
    {
         List<Policy> GetAll();
         Policy Get(int policyNumber);
        void Add(Policy policy);
        void Delete(int policyNumber);
    }
}
