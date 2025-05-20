using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Services
{
    public class ServiceResult
    {
        public bool Success { get; set; }   
        public List<string> Errors { get; set; }

        public ServiceResult()
        {
            this.Errors = new List<string>();   
        }
    }

    public class ServiceResult<T>
    {
        public bool Sucess { get; set; }
        public List<string> Erros { get; set; }
        public T? Value { get; set; }   

        public ServiceResult() 
        {
            Erros = new List<string>();    
        }
    }
}
