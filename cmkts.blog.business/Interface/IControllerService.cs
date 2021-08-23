using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.business.Interface
{
    public interface IControllerService:IGenericService<Controller>
    {
        Task<GenericResponse<Controller>> GetControllerWithActions(int id);
    }
}
