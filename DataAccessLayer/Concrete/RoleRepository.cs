using DataAccessLayer.Abstract;
using DataAccessLayer.BaseRepository;
using Entities.Context;
using Entities.Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(SqlDbContext db) : base(db)
        {
        }
    }
}
