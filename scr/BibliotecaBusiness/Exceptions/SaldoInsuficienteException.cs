using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Exceptions
{
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException() { }
        public SaldoInsuficienteException(string message) : base(message) { }
        public SaldoInsuficienteException(string message, Exception ex) : base(message, ex) { }
    }
}
