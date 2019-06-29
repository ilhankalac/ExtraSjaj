using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Common.Models;
using ExtraSjaj.DAL.Context;
using System.Linq;

namespace ExtraSjaj.DAL.RepoPattern
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        protected readonly ExtraSjajContext _context;

        public UserRepository(ExtraSjajContext context) : base(context)
        {
            _context = context;
        }

        public ExtraSjajContext context
        {
            get { return context as ExtraSjajContext; }
        }

        public bool proveraJedinstvenosti(User user)
        {
            return  _context.Users.Any(x => x.Username == user.Username || x.JMBG == user.JMBG || x.BrojTelefona == user.BrojTelefona);
        }
        public bool proveraLogovanja(User user)
        {
            return _context.Users.Any(x => x.Username == user.Username && x.Password == user.Password);
        }
    }
}
