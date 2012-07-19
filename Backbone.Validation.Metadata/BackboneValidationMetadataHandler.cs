using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Backbone.Validation.Metadata
{
    public class BackboneValidationMetadataHandler : IHttpHandler 
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var metadata = BackboneValidationMetadataProvider.GetValidationMetadata();
            var metaDataJson = JsonConvert.SerializeObject(metadata, settings);
            var script = Resources.backbone_validation_metadata.Replace("{{Metadata}}", metaDataJson);

            context.Response.ContentType = "text/javascript";
            context.Response.Write(script);
        }
    }
}