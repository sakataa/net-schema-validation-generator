using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SchemaValidationGenerator
{
    public class SchemaReader : ISchemaReader
    {
        public IEnumerable<SchemaResult> ReadFrom<TModel>() where TModel : class
        {
            var properties = typeof(TModel).GetProperties();

            foreach(var prop in properties)
            {
                var attributes = prop.GetCustomAttributes(true);

                if (attributes is null || !attributes.Any())
                    continue;

                var schema = new SchemaResult();
                foreach(var attr in attributes)
                {
                    switch (attr)
                    {
                        case EditableAttribute e: schema.Editable = e.AllowEdit; break;
                        case UrlAttribute _: schema.Type = "url"; break;
                        case EmailAddressAttribute _: schema.Type = "email"; break;
                        case MaxLengthAttribute max: schema.MaxLength = max.Length; break;
                        case MinLengthAttribute min: schema.MinLength = min.Length; break;
                        case RequiredAttribute _: schema.Required = true; break;
                        case RegularExpressionAttribute regex: schema.RegularExpression = regex.Pattern; break;
                        case DisplayAttribute display: schema.Label = display.Description; break;
                    }
                }

                if (string.IsNullOrWhiteSpace(schema.Label))
                    schema.Label = prop.Name;

                yield return schema;
            }
        }
    }
}
