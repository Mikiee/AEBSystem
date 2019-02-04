using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEBSystem.Core.Interface
{
    public interface ISaveUserDetails
    {
        void SaveUserDetails(string Name, string Role, string Position);
    }
}
