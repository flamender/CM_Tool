using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CmTool.Domain
{
    public class FeatureSettingsFileRepository
    {
        protected Dictionary<string, XDocument> xmlDict;
        protected Dictionary<string, ConfigOrSettingsContent> configOrSettingsContent = new Dictionary<string, ConfigOrSettingsContent>();


        public FeatureSettingsFileRepository(Dictionary<string, XDocument> xmlDict)
        {
            this.xmlDict = xmlDict;
        }

        public void Initialize()
        {
            foreach (var xmlDoc in xmlDict)
            {
                var coc = new ConfigOrSettingsContent(xmlDoc.Value);
                configOrSettingsContent.Add(xmlDoc.Key, coc);
            }
        }


        public ConfigOrSettingsContent GetConfigOrSettingsContentFromString(string selector)
        {
            ConfigOrSettingsContent res = null;
            if (!configOrSettingsContent.TryGetValue(selector, out res))
            {
                //log
            }
            return res;
        }

        public SubfolderDto SearchForSubfolder(string fileName, string subfolderName, string attributeName, string attributeValue)
        {
            var sf = SearchForSubfolders(fileName, subfolderName).Where(x => x.Attributes.Any(y => y.Name.Equals(attributeName) && y.Value.Equals(attributeValue))).FirstOrDefault();
            return sf; 
        }

        public  List<SubfolderDto> SearchForSubfolders(string fileName, string subfolderName)
        {
            var res = new List<SubfolderDto>();
            ConfigOrSettingsContent content = null;
            if (!configOrSettingsContent.TryGetValue(fileName, out content))
            {
                //Log
                return res;                
            }

            return content.Subfolders.Where(x => string.Compare( x.Name, subfolderName, true)==0).ToList();
        }

    }
}
