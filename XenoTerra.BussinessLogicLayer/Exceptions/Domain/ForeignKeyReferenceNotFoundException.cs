using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.BussinessLogicLayer.Exceptions.Domain
{
    public class ForeignKeyReferenceNotFoundException(string propertyName, string relatedEntityName, Exception? inner = null) 
        : Exception($"{propertyName} refers to a non-existing {relatedEntityName}.", inner)
    {
        public string PropertyName { get; } = propertyName;
        public string RelatedEntityName { get; } = relatedEntityName;
    }
}
