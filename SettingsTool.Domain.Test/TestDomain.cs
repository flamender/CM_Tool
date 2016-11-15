using Configurator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using SettingsTool.Domain;

namespace TestConfiguration
{
    [TestClass]
    public class TestDomain
    {

        protected string dir = Path.GetFullPath(@"..\..\..\Configurator\XML\");

        protected string rootDir = @"C:\Sourcecode\CustomerSettings\";

        [TestMethod]
        public void TestFileReader()
        {
            var tr = new FeatureSettingsFileReader(new SettingsToolConfiguration { XmlSettingsDirectory = @"c:\Sourcecode\Prototypes\Configurator\Configurator\XML" });
            var dict = tr.ReadXmlFiles();
        }

        [TestMethod]
        public void TestRepository()
        {
            var xmlTestFile = "Module_Settings.xml";
            var config = new SettingsToolConfiguration { XmlSettingsDirectory = dir };
            var tr = new FeatureSettingsFileReader(config);
            var dict = tr.ReadXmlFiles();
            var rep = new FeatureSettingsFileRepository(dict.Where(x => x.Key.Contains(xmlTestFile)).Select(y => y).ToDictionary(a => a.Key, b => b.Value));
            rep.Initialize();
            var xes = dict[xmlTestFile].Descendants(XmlConstants._item);
            var noItems = xes.Count();
            var noSubfolder = xes.Select(x => x.Parent).Distinct().Count();
            var coc = rep.GetConfigOrSettingsContentFromString(xmlTestFile);
            var noItems1 = coc.NoOfItems();
            var noSubfolder1 = coc.NoOfItemSubfolders();
            Assert.AreEqual(noItems, noItems1);
            Assert.AreEqual(noSubfolder, noSubfolder1);
        }





        [TestMethod]
        public void TestReadBaseConfig_Xml()
        {
            var xmlTestFile = "BaseConfig.xml";
            var config = new SettingsToolConfiguration { XmlSettingsDirectory = dir };
            var tr = new FeatureSettingsFileReader(config);
            var dict = tr.ReadXmlFiles();
            var rep = new FeatureSettingsFileRepository(dict.Where(x => x.Key.Contains(xmlTestFile)).Select(y => y).ToDictionary(a => a.Key, b => b.Value));
            rep.Initialize();

            var sfs = rep.SearchForSubfolders(xmlTestFile, "MMServer");
            Assert.IsTrue(sfs.Count == 1 && sfs[0].Attributes.Count == 2);
            sfs = rep.SearchForSubfolders(xmlTestFile, "MiniModule");
            Assert.IsTrue(sfs.Count == 28);

        }

        [TestMethod]
        public void TestDEZA_INT_ModuleRevisions_Xml()
        {
            var xmlTestFile = "DEZA_INT_ModuleRevisions_04.03.002.xml";
            var config = new SettingsToolConfiguration { XmlSettingsDirectory = dir };
            var tr = new FeatureSettingsFileReader(config);
            var dict = tr.ReadXmlFiles();
            var rep = new FeatureSettingsFileRepository(dict.Where(x => x.Key.Contains(xmlTestFile)).Select(y => y).ToDictionary(a => a.Key, b => b.Value));
            rep.Initialize();

            var sfs = rep.SearchForSubfolders(xmlTestFile, "MainModule");
            Assert.IsTrue(sfs.Count == 1 && sfs[0].NoOfItems == 4);
        }

        [TestMethod]
        public void TestModule_Server_Access_XML()
        {
            var xmlTestFile = "Module_Server_Access.xml";
            var config = new SettingsToolConfiguration { XmlSettingsDirectory = dir };
            var tr = new FeatureSettingsFileReader(config);
            var dict = tr.ReadXmlFiles();
            var rep = new FeatureSettingsFileRepository(dict.Where(x => x.Key.Contains(xmlTestFile)).Select(y => y).ToDictionary(a => a.Key, b => b.Value));
            rep.Initialize();

            var sfs = rep.SearchForSubfolders(xmlTestFile, "Connections");
            Assert.IsTrue(sfs.Count == 1 && sfs[0].NoOfChilds == 1 && sfs[0].NoOfItems == 0);
            var sf = sfs[0];
            Assert.IsTrue(sf.ChildFolder[0].ChildFolder[0].Name == "ServerInfo");
            Assert.IsTrue(sf.ChildFolder[0].ChildFolder[0].Attributes.Count == 7);
            var attr = sf.ChildFolder[0].ChildFolder[0].Attributes[0];
            Assert.IsTrue(attr.Name == "IP_or_DNSName", attr.Value = "test-db.rigilog.com");
        }

        [TestMethod]
        public void TestSaveChangesToXmlFile()
        {
            var xmlTestFile = "Module_Settings.xml";
            var config = new SettingsToolConfiguration { XmlSettingsDirectory = dir };
            var tr = new FeatureSettingsFileReader(config);
            var dict = tr.ReadXmlFiles();
            var rep = new FeatureSettingsFileRepository(dict.Where(x => x.Key.Contains(xmlTestFile)).Select(y => y).ToDictionary(a => a.Key, b => b.Value));
            rep.Initialize();
            var coc = rep.GetConfigOrSettingsContentFromString(xmlTestFile);
            var xe = coc.SaveChangesToXDocument();
            //xe.Save(Path.Combine(dir, String.Concat(Path.GetFileNameWithoutExtension(xmlTestFile), " (Copy).xml"));
        }


        [TestMethod]
        public void TestGenerateEmptyFile()
        {

        }

        private void SaveGeneratedFile<T>(T anObj, string fileName) 
        {
            var fn = Path.Combine(dir, string.Concat(Path.GetFileNameWithoutExtension(fileName), "_modified.xml"));
            var ser = new XmlSerializer(typeof(T));

            using (TextWriter writer = new StreamWriter(fn))
            {
                ser.Serialize(writer, anObj);
            }

        }

        private T LoadFileForGeneratedClasses <T> ( string fileName) where T : class
        {
            using (var stream = File.OpenRead(Path.Combine(dir, fileName)))
            {
                var serializer = new XmlSerializer(typeof(T));
                T anObj = serializer.Deserialize(stream) as T;
                return anObj;
            }
        }


        [TestMethod]
        public void TestLoadAndSaveGeneratedFiles()
        {
            var xmlTestFile = "BaseConfig.xml";
            var bacon =  LoadFileForGeneratedClasses< BaseConfiguration>(xmlTestFile);

            bacon.GIS = new BaseConfigurationGIS { Impersonate_Domain = "Rosch", Impersonate_UserName = "ZugSalbe", Impersonate_Password = "Gruezi" };

            SaveGeneratedFile(bacon, xmlTestFile);        
            /**************************************************************************************************/

            xmlTestFile = "Module_Server_Access.xml";
            var maci =  LoadFileForGeneratedClasses<ModuleServerAccessInfo>(xmlTestFile);

            var  msaList = maci.Connections.ToList();
            msaList.Add(new ModuleServerAccessInfoConnection { Active = "True",  UsedProvider = "ZugSalbe" });
            maci.Connections = msaList.ToArray();

            SaveGeneratedFile(bacon, xmlTestFile);
            /**************************************************************************************************/

            xmlTestFile = "Module_Settings.xml";
            ConfigFile cofi =  LoadFileForGeneratedClasses<ConfigFile>(xmlTestFile);            
            var itemList = cofi.item.ToList();
            itemList.Add(new item { IsActive = "true", Type = "String", value = "ZugSalbe", VarName = "Medikament" });
            cofi.item = itemList.ToArray();
            SaveGeneratedFile(cofi, xmlTestFile);

        }

        [TestMethod]
        public void TestLoadAllBasConfigFilesFromRooDir()
        {
            var selector = "Katag";
            var platform = "TEST";

            var dirRep   = new DirectoryInfoRepository(rootDir);           
            var allCust  =  dirRep.GetAllCustomers();
            foreach (var c in allCust)
            {
                selector = c.Key;
                var allInst = dirRep.GetPlatforms(selector);
                foreach (var inst in allInst)
                {
                    platform = inst.Key;
                    var allMainModules = dirRep.GetModules(selector, platform, SwitchConst._MainModule);
                    if (allMainModules.Count == 0)
                    {
                        continue;
                        Debug.WriteLine(string.Format("Keine TEST,PROD Verzeichnisse in  {0}", selector));
                    }

                    var allMiniModules = dirRep.GetModules(selector, platform, SwitchConst._MiniModule);
                    var allFiles = dirRep.GetAllFiles(selector, platform, SwitchConst._MainModule, SwitchConst._All);
                    allFiles.AddRange(dirRep.GetAllFiles(selector, platform, SwitchConst._MiniModule, SwitchConst._All));


                    foreach (var f in allFiles)
                    {
                        var bacon = LoadFileForGeneratedClasses<BaseConfiguration>(f);
                        Debug.WriteLine(String.Format("File: {0} Loaded", f));
                    }
                }
            }

        }





    }
}
