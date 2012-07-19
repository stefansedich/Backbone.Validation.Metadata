using System.Collections.Generic;
using System.Web.Mvc;

namespace Backbone.Validation.Metadata
{
    public class PropertyValidationMetadata
    {
        public string Name { get; private set; }
        public IList<ModelClientValidationRule> Validators { get; private set; }

        public PropertyValidationMetadata(string name, IList<ModelClientValidationRule> validators)
        {
            Name = name.Substring(0, 1).ToLower() + name.Substring(1);
            Validators = validators;
        }
    }
}