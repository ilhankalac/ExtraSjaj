using ExtraSjaj.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraSjaj.Common.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        bool proveraJedinstvenosti(User user);

        bool proveraLogovanja(User user);
    }
}
