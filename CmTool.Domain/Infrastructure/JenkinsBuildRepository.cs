using CmTool.Configurator;
using CmTool.Domain.Models;
using CmToolConfigurator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Infrastructure
{
    public class JenkinsBuildRepository
    {
        const string root = @"\\sr-fs03.rigilog.local\ZS-Support\01_Jenkins\01_Revisions\";

        private Dictionary<string,string> GetAllRevisions()
        {
            return null;

        }


        private Item ItemFromXmlNode( XElement element)
        {
            var res = new Item();
            var attr =  element.Attributes().FirstOrDefault(x => x.Name.LocalName.Equals("Name"));
            if (attr == null)
                return null;
            res.ItemName = attr.Value;

            attr = element.Attributes().FirstOrDefault(x => x.Name.LocalName.Equals("Revision"));
            if (attr == null)
                return null;

            res.Revision = attr.Value;
            return res;
        } 



        private void ReadElementType(XDocument xDoc, String elementType, InstallationVersion installationVersion)
        {
            var el = xDoc.Descendants(elementType).FirstOrDefault();
            if (el != null)
            {
                foreach (var element in el.Elements())
                {
                    var item = ItemFromXmlNode(element);
                    if (item != null)
                    {
                        item._Type = elementType;
                        installationVersion.Items.Add(item);
                    }
                }
            }
        }

        public InstallationVersion ReadInstallationVersionFromFile(string fileName)
        {
            var res = new InstallationVersion();
            var xDoc = XDocument.Load(fileName);
            ReadElementType(xDoc, "CustomerSettings", res);
            ReadElementType(xDoc, "MainModule", res);
            ReadElementType(xDoc, "MiniModule", res);
            ReadElementType(xDoc, "Plugins", res);
            ReadElementType(xDoc, "MSI", res);
            return res;
        }

        public List<JenkinsBuildModel> GetAll()
        {
            var res = new List<JenkinsBuildModel>();
            var dirs = Directory.GetDirectories(root);
            foreach (var dir in dirs)
            {
                var anObj = new JenkinsBuildModel { CustomerName = Path.GetFileName(dir) };
                res.Add(anObj);
                var files = Directory.GetFiles(dir).Where(x => !x.Contains("Z_Archiv")).ToList();
                foreach (var file in files)
                {
                    var items = file.Split('_').ToList();
                    var idx = items.IndexOf("ModuleRevisions");
                    if (idx > 0)
                    {
                        var pn = items[--idx];
                        var pl = anObj.Plattforms.FirstOrDefault(x => x.PlattformName.Equals(pn));
                        if (pl == null)
                        {
                            pl = new PlattformInfo { PlattformName = pn };
                            anObj.Plattforms.Add(pl);
                        }
                        var iv = ReadInstallationVersionFromFile(file);
                        iv.VersionName = items.Last().Replace(".xml", String.Empty);
                        pl.InstallationVersions.Add(iv);
                    }
                }
            }        
            return res;
        }
    }
}
