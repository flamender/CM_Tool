using System.Collections.Generic;

namespace Models
{
    public class JenkinsBuildModel
    {
        public string Name { get; set; }

        public List<string> Plattform = new List<string>();

        public List<string> Revisions = new List<string>();

        public List<string> InstalledVersions = new List<string>();
        public JenkinsBuildModel()
        {

        }
    }
}