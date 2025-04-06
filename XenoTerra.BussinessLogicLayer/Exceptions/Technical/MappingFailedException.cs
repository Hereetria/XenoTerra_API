using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Exceptions.Base;

namespace XenoTerra.BussinessLogicLayer.Exceptions.Technical
{
    public class MappingFailedException(string sourceType, string targetType, Exception? innerException = null) 
        : TechnicalException($"Mapping failed from '{sourceType}' to '{targetType}'.", innerException)
    {
    }
}
