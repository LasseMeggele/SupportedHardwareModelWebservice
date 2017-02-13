using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupportedHardwareModelWebservice
{
    public class MakeModel : IEquatable<MakeModel>
    {
        public string Manufacturer { get; set; }
        public string[] AlternativeNames { get; set; }
        public Model[] Models { get; set; }
        private IEquatable<MakeModel> _equatableImplementation;

        public MakeModel()
        {
            
        }

        public MakeModel(string manufacturer, string[] alternativeNames)
        {
            Manufacturer = manufacturer;
            AlternativeNames = alternativeNames;
        }

        public MakeModel(string manufacturer, string[] alternativeNames, Model[] models)
        {
            Manufacturer = manufacturer;
            AlternativeNames = alternativeNames;
            Models = models;
        }


        public bool Equals(MakeModel other)
        {
            return other != null && _equatableImplementation.Equals(other);
        }
    }
}