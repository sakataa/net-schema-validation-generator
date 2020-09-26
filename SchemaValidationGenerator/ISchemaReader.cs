using System;
using System.Collections.Generic;
using System.Text;

namespace SchemaValidationGenerator
{
    public interface ISchemaReader
    {
        IEnumerable<SchemaResult> ReadFrom<TModel>() where TModel : class;
    }
}
