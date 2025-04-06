using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Exceptions.Base;

namespace XenoTerra.BussinessLogicLayer.Exceptions.Technical
{
    public class UnexpectedRepositoryException(Exception? inner = null)
        : TechnicalException("An unexpected error occurred while accessing the repository.", inner)
    {
    }
}
