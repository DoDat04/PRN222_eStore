using BusinessObjects;
using DataAccessObjects.Define;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Implement
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(EStoreContext context) : base(context)
        {
        }
    }
}
