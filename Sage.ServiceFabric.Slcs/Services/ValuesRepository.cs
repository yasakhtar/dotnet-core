using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sage.ServiceFabric.Slcs.Models;

namespace Sage.ServiceFabric.Slcs.Services
{
    public class ValuesRepository : IValuesRepository
    {
        private readonly List<Value> _values = new List<Value>
        {
            new Value() {Id = 1, Name = "Value 1", Description = "Description for value 1" },
            new Value() {Id = 2, Name = "Value 2", Description = "Description for value 2" },
            new Value() {Id = 3, Name = "Value 3", Description = "Description for value 3" },
            new Value() {Id = 4, Name = "Value 4", Description = "Description for value 4" },
            new Value() {Id = 5, Name = "Value 5", Description = "Description for value 5" }
        };

        public async Task<Value> Get(int id)
        {
            return _values.FirstOrDefault(v => v.Id == id);
        }

        public async Task<IEnumerable<Value>> GetAll()
        {
            return _values;
        }
    }
}
