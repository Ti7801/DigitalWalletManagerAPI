using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Exceptions
{
    public class CarteiraDigitalNaoEncontradaException : Exception
    {
        public CarteiraDigitalNaoEncontradaException() { }
        public CarteiraDigitalNaoEncontradaException(string message) : base(message) { }
        public CarteiraDigitalNaoEncontradaException(string message, Exception ex) : base(message, ex) { }
    }
}
