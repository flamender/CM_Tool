using System.Collections.Generic;
using System.Linq;

namespace CmTool.Domain.Models
{

    public class Item
    {
        public string ItemName { get; set; }
        public string Revision { get; set; }

        public string _Type { get; set; }
        public override string ToString()
        {
            return string.Format("ItemName: {0}, _Type: {1}, Revision: {2}", ItemName, _Type, Revision);
        }

    }

    public class InstallationVersion
    {
        public string VersionName { get; set; }
        public List<Item> Items = new List<Item>();
        
        public override string ToString()
        {
            return string.Format("VersionName: {0},  Items: {1}", string.Join(";",this.Items.Select( x=> x.ToString()).ToList()));
        }
    }
    public class PlattformInfo
    {
        public string PlattformName { get; set; }

        public List<InstallationVersion> InstallationVersions = new List<InstallationVersion>();

        public override string ToString()
        {
            return string.Format("Name: {0}, InstallationVersions: {1}", this.PlattformName, string.Join(";", InstallationVersions)); 
        }

    }
    public class JenkinsBuildModel
    {
        public string CustomerName { get; set; }

        public List<PlattformInfo> Plattforms = new List<PlattformInfo>();        
                        

        public override string ToString()
        {
            return CustomerName;
        }
    }
}