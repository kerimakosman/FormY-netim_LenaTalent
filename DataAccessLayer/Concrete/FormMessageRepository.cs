using DataAccessLayer.Abstract;
using DataAccessLayer.BaseRepository;
using Entities.Context;
using Entities.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class FormMessageRepository : RepositoryBase<FormMessage>, IFormMessageRepository
    {
        public FormMessageRepository(SqlDbContext db) : base(db)
        {
        }
    }
}
