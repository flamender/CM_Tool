using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CmTool.Configurator
{
    [XmlRoot("Configuration")]
    public class SettingsToolConfiguration
    {
        public string XmlSettingsDirectory { get; set; }
    }
}
