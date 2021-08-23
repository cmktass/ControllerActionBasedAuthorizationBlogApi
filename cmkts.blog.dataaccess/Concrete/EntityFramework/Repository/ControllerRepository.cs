using cmkts.blog.dataaccess.Concrete.EntityFramework.BlogSiteContext;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.dataaccess.Concrete.EntityFramework.Repository
{
    public class ControllerRepository : GenericRepository<Controller>, IControllerRepository
    {
        public async Task<Controller> GetControllerWithActions(int id)
        {
            using(var db=new CmktsBlogSiteContext())
            {
                return await db.Controllers.Include(a => a.ControllerActions).Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }
    }
}
