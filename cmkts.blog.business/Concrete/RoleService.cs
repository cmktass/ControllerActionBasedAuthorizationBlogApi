using cmkts.blog.business.Interface;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.business.Concrete
{
    public class RoleService:GenericService<Role>,IRoleService
    {
        private IGenericRepository<Role> _genericRepository;
        private IRoleRepository _roleRepository;
        public RoleService(IGenericRepository<Role> genericRepository, IRoleRepository roleRepository):base(genericRepository)
        {
            _genericRepository = genericRepository;
            _roleRepository = roleRepository;
        }
    }
}
