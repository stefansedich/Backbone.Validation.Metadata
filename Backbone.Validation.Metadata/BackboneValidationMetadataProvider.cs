using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Backbone.Validation.Metadata
{
    public class BackboneValidationMetadataProvider
    {
        protected static readonly IDictionary<string, Type> ModelTypes = new Dictionary<string, Type>();

        public static void AddModelType<TModel>(string key)
        {
            ModelTypes.Add(key, typeof(TModel));
        }

        public static Dictionary<string, IEnumerable<PropertyValidationMetadata>> GetValidationMetadata()
        {
            return ModelTypes.ToDictionary(type => type.Key, type => GetModelClientValidators(type.Value));
        }

        private static IEnumerable<PropertyValidationMetadata> GetModelClientValidators(Type type)
        {
            return ModelMetadataProviders.Current
                .GetMetadataForType(() => Activator.CreateInstance(type), type)
                .Properties
                .OrderBy(p => p.Order)
                .Select(GetModelPropertyClientValidators);
        }

        private static PropertyValidationMetadata GetModelPropertyClientValidators(ModelMetadata p)
        {
            var validators = ModelValidatorProviders.Providers
                .GetValidators(p, new ControllerContext())
                .SelectMany(m => m.GetClientValidationRules())
                .ToList();

            return new PropertyValidationMetadata(p.PropertyName, validators);
        }
    }
}