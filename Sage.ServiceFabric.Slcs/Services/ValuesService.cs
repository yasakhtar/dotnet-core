using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sage.ServiceFabric.Slcs.Models;

namespace Sage.ServiceFabric.Slcs.Services
{
    public class ValuesService : IValuesService
    {
        private readonly IValuesRepository _repo;

        public ValuesService(IValuesRepository repo)
        {
            this._repo = repo;
        }

        public async Task<IEnumerable<Value>> GetValues()
        {
            return await _repo.GetAll();
        }
    }
}
