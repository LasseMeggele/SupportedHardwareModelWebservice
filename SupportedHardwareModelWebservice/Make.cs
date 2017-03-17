using System;

namespace SupportedHardwareModelWebservice
{
    public class Make : IEquatable<Make>
    {
        public string Manufacturer { get; set; }
        public string[]AlternativeNames { get; set; }
        public Model[] Models { get; set; }

        public Make(){}

        public Make(string manufacturer, string[] alternativeNames)
        {
            Manufacturer = manufacturer;
            AlternativeNames = alternativeNames;
        }

        public Make(string manufacturer, string[] alternativeNames, Model[] models)
        {
            Manufacturer = manufacturer;
            AlternativeNames = alternativeNames;
            Models = models;
        }

        public bool Equals(Make other)
        {
            return other != null && 
                   Manufacturer.Equals(other.Manufacturer) &&
                   AlternativeNames.Equals(other.AlternativeNames) &&
                   Models.Equals(other.Models);
        }

        public override bool Equals(object obj)
        {
            var makeModel = obj as Make;
            if (makeModel == null)
            {
                return false;
            }

            return Manufacturer.Equals(makeModel.Manufacturer) &&
                   AlternativeNames.Equals(makeModel.AlternativeNames) &&
                   Models.Equals(makeModel.Models);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                result = (result * 397) ^ Manufacturer.GetHashCode();
                result = (result * 397) ^ AlternativeNames.GetHashCode();
                result = (result * 397) ^ Models.GetHashCode();
                return result;
            }
        }
    }
}