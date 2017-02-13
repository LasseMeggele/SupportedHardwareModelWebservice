﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.IO;
using System.Web.Hosting;
using Newtonsoft.Json.Linq;

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
        public List<MakeModel> GetSupportedModels()
        {
            return DeserializeJsonObjects();
        }

        [WebMethod]
        public List<string> GetManufacturers()
        {
            return DeserializeJsonObjects().Select(x => x.Manufacturer).ToList();
        }

        [WebMethod]
        public List<string> GetAlternativeManufacturerList(string manufacturer)
        {
            return DeserializeJsonObjects()
                .Where(x => string.Equals(x.Manufacturer, manufacturer, StringComparison.InvariantCultureIgnoreCase))
                .SelectMany(x => x.AlternativeNames)
                .ToList();
        }

        private static List<MakeModel> DeserializeJsonObjects()
        {
            var jsonObject = JObject.Parse(File.ReadAllText(Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"SupportedHardwareModels.json")));
            return jsonObject["MakeModel"].ToObject<List<MakeModel>>();
        }
    }
}