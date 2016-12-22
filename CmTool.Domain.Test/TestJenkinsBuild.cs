using Domain.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConfiguration
{
    [TestClass]
    public class TestJenkinsBuild
    {
        [TestMethod]
        public void TestRepository()
        {
            var rep = new JenkinsBuildRepository();
            var models =  rep.GetAll();

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            using (StreamWriter sw = new StreamWriter(@"..\..\TestData\JSON\JenkinsBuildRepository.json"))
              using(JsonWriter writer = new JsonTextWriter(sw))
              {
                serializer.Serialize(writer, models);               
              }

        }

        [TestMethod]
        public void TestSaveJenkinsFile()
        {

        }


        [TestMethod]
        public void TestLoadXml()
        {
            var rep = new JenkinsBuildRepository();
            var vinfo =  rep.ReadInstallationVersionFromFile(@"\\sr-fs03.rigilog.local\ZS-Support\01_Jenkins\01_Revisions\WF_Migros\WF_Migros_TEST_ModuleRevisions_04.01.000.xml");
        }

    }
}
