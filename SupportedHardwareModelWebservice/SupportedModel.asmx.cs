using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.IO;
using System.Web.Hosting;
using Newtonsoft.Json.Linq;
using static System.Text.RegularExpressions.Regex;
using static System.Text.RegularExpressions.RegexOptions;

namespace SupportedHardwareModelWebservice
{
    /// <summary>
    /// Summary description for SupportedModel
    /// </summary>
    [WebService(Namespace = "http://chaosinc.dk/webservices", Description = "This webservice defines a list of supported hardware.", Name = "SupportedHardwareModels")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SupportedModel : WebService
    {

        [WebMethod]
        public List<Make> GetSupportedModels() => DeserializeJsonObjects();

        [WebMethod]
        public List<string> GetManufacturers() => DeserializeJsonObjects().Select(x => x.Manufacturer).ToList();

        [WebMethod]
        public List<string> GetAlternativeManufacturerList(string manufacturer)
        {
            return DeserializeJsonObjects()
                .Where(x => string.Equals(x.Manufacturer, manufacturer, StringComparison.InvariantCultureIgnoreCase))
                .SelectMany(x => x.AlternativeNames)
                .ToList();
        }

        [WebMethod]
        public string GetManufacturerFromAltName(string alternativeName)
        {
            return alternativeName == ""
                ? null
                : DeserializeJsonObjects()
                    .Select(o => o.AlternativeNames
                        .Any(oAlternativeName => IsMatch(oAlternativeName, alternativeName, IgnoreCase))
                            ? o.Manufacturer
                            : null).SkipWhile(x => x == null).FirstOrDefault();
        }

        [WebMethod]
        public List<Model> GetModelsFromManufacturer(string manufacturer) => DeserializeJsonObjects().Find(x => x.Manufacturer == manufacturer)?.Models.ToList();

        [WebMethod]
        public string GetModelAlias(string manufacturer, string model) => GetModelsFromManufacturer(manufacturer).Find(x => x.Name == model)?.ModelAlias;

        private static List<Make> DeserializeJsonObjects()
        {
            var jsonObject =
                JObject.Parse(
                    File.ReadAllText(Path.Combine(HostingEnvironment.ApplicationPhysicalPath,
                        @"SupportedHardwareModels.json")));
            return jsonObject["Make"].ToObject<List<Make>>();
        }
    }
}
