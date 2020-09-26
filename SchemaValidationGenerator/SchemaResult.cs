using System;
using System.Collections.Generic;
using System.Text;

namespace SchemaValidationGenerator
{
    public class SchemaResult
    {
        public string Name { get; set; }

        public string Label { get; set; }

        public bool Editable { get; set; }

        public int MinLength { get; set; }

        public int MaxLength { get; set; }

        public string Type { get; set; }

        public bool Required { get; set; }

        public string RegularExpression { get; set; }
    }
}
