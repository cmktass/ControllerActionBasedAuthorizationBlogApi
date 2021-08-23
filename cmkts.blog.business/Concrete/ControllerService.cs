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
    public class ControllerService:GenericService<Controller>,IControllerService
    {
        private IGenericRepository<Controller> _genericRepository;
        IControllerRepository _controllerRepository;
        public ControllerService(IGenericRepository<Controller> genericRepository,IControllerRepository controllerRepository):base(genericRepository)
        {
            _genericRepository = genericRepository;
            _controllerRepository = controllerRepository;
        }

        public async Task<GenericResponse<Controller>> GetControllerWithActions(int id)
        {
            GenericResponse<Controller> response = new GenericResponse<Controller>();
            response.Data = await _controllerRepository.GetControllerWithActions(id);
            return response;
        }
    }
}
