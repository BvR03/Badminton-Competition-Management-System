using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNDTOLayer
{
    public interface IPasswordGrabber
    {
        Task<string?> getPasswordHashByUsername(string username);
    }
}
