using CmToolConfigurator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace CmTool.Configurator
{
    public class FeatureSettingsFileReader
    {
        protected SettingsToolConfiguration config;

        public FeatureSettingsFileReader(SettingsToolConfiguration config)
        {
            this.config = config;
        }
       
        public Dictionary<string, XDocument> ReadXmlFiles()
        {
           
            var xmlFiles = new Dictionary<string, XDocument>();
              var fileList = Directory.GetFiles(config.XmlSettingsDirectory , "*.xml").ToList();
            foreach (var file in fileList)
            {
                var xe = XDocument.Load(file);
                xmlFiles.Add(Path.GetFileName(file), xe);

           }
            return xmlFiles;
        }
    }
}