using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.viewmodel.ViewModels
{
    public class GenericResponse<T>
    {
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
