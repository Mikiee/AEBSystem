using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEBSystem.Core.Models
{
    public class LinqGrouping
    {
        public class Group<K, T>
        {
            public K Key;
            public IEnumerable<T> Values;
        }
    }
}
