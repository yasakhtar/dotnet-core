using Sage.ServiceFabric.Slcs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sage.ServiceFabric.Slcs.Services
{
    public interface IValuesRepository
    {
        Task<IEnumerable<Value>> GetAll();
        Task<Value> Get(int id);

    }
}
