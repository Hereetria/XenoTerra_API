using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Exceptions.Base;

namespace XenoTerra.BussinessLogicLayer.Exceptions.Technical
{
    public class SqlExceptionHandlingFailedException(string message, Exception? inner = null)
        : TechnicalException(message, inner)
    {
    }
}
