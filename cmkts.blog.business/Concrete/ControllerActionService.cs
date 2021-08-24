using cmkts.blog.business.Interface;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.business.Concrete
{
    public class ControllerActionService:GenericService<ControllerAction>,IControllerActionService
    {
        private IGenericRepository<ControllerAction> _genericRepository;
        private IControllerActionRepository _controllerActionRepository;
        public ControllerActionService(IGenericRepository<ControllerAction> genericRepository, IControllerActionRepository contollerActionRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
            _controllerActionRepository = contollerActionRepository;
        }
        public async override Task<GenericResponse<ControllerAction>> AddAsync(ControllerAction entity)
        {
            GenericResponse<ControllerAction> response = new GenericResponse<ControllerAction>();
            if (await _genericRepository.FindByFilter(i => i.ActionName == entity.ActionName) != null)
            {
                response.ErrorMessage = "Bu isimli action zaten mevcut";
                return response;
            }
            else
            {
                 return await base.AddAsync(entity);
            }
        }
    }
}
