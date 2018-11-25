using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Models
{
    public class Country
    {
        private string _name;
        private string _countryCode;
        private string _localizedName;
        private string _localGovernmentIdLabel;
        private string _localGovernmentAddressCodeLabel;
        private string _localGovernmentAreaLabelName;

        //Getters
        public string GetName()
        {
            return _name;
        }

        public string GetCountryCode()
        {
            return _countryCode;
        }

        public string GetLocalName()
        {
            return _localizedName;
        }

        public string GetLocalGovernmentIdName()
        {
            return _localGovernmentIdLabel;
        }

        //Setters
        public void SetName(string name)
        {
            _name = name;
        }

        public void SetCountryCode(string code)
        {
            _countryCode = code;
        }

        public void SetLocalName(string localName)
        {
            _localizedName = localName;
        }

        public void SetLocalGovernmentIdName(string governmentIdName)
        {
            _localGovernmentIdLabel = governmentIdName;
        }
    }
}
