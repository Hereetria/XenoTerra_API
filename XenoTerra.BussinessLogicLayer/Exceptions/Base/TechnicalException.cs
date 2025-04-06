using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.BussinessLogicLayer.Exceptions.Base
{
    public abstract class TechnicalException(string message, Exception? inner = null) : Exception(message, inner)
    {
    }
}
