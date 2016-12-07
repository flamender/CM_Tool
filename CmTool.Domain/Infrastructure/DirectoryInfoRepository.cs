using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Configurator
{

    public static class SwitchConst
    {
        public const string _MiniModule = "MiniModules";

        public const string _MainModule = "MainModules";

        public const string _All = "All";

        public const string _BaseConfig = "BaseConfig.xml";
    }


    public class DirectoryInfoRepository
    {


        private string rootDir;

        private Dictionary<string, string> allCustomers = new Dictionary<string, string>();

        public DirectoryInfoRepository(string rootDir)
        {
            this.rootDir = rootDir;
            Initialize();
        }

        /// <summary>
        /// TEST,PROD,INT
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetPlatforms(string customer)
        {
            var kvp = allCustomers.First(x => x.Key.Equals(customer));
            var di = new DirectoryInfo(kvp.Value);
            var result = di.GetDirectories()
                            .OrderBy(x => x.FullName)
                            .ToDictionary(x => x.FullName.Replace(kvp.Value, string.Empty).Replace(@"\", string.Empty), y => y.FullName);

            return result;
        }


        private void Initialize()
        {
            allCustomers = Directory.GetDirectories(rootDir)
                     .Where(x => !x.ToLower().Contains(".svn"))
                     .Select(x => x)
                     .ToDictionary(x => x.Replace(rootDir, string.Empty), y => y);
        }


        /// <summary>
        /// e.g. Katag
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAllCustomers()
        {
            return allCustomers;
        }

        /// <summary>
        /// module e.g. MainModule
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="platform"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetModules(string customer, string platform, string module)
        {
            try
            {
                var kvp = allCustomers.First(x => x.Key.Equals(customer));
                var dirName = Path.Combine(kvp.Value, platform, module);
                var di = new DirectoryInfo(dirName);
                var result = di.GetDirectories()
                                .OrderBy(x => x.FullName)
                                .ToDictionary(x => x.FullName.Replace(dirName, string.Empty).Replace(@"\", string.Empty), y => y.FullName);

                return result;
            }
            catch (Exception  ex)
            {
                Debug.WriteLine(ex.Message);
                return new Dictionary<string, string>();
                 //log 
            }
        }


        /// <summary>
        /// module e.g. MainModule
        /// moduleName e.g. Bill
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="platform"></param>
        /// <param name="module"></param>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        public List<String> GetAllFiles(string customer, string platform, string module, string moduleName)
        {
            var res = new List<string>();
            Func<KeyValuePair<string, string>, bool> predicate = (x) =>
             {
                 if (moduleName.Equals(SwitchConst._All))
                 {
                     return true;
                 }

                 return x.Key.Equals(moduleName);

             };

            var modules = GetModules(customer, platform, module)
                                                .Where(predicate)
                                                .Select(y => y.Value)
                                                .ToList();

            foreach (var mod in modules)
            {
                var di = new DirectoryInfo(mod);
                di.GetFiles(SwitchConst._BaseConfig).ToList().ForEach(z => res.Add(z.FullName));
            }
            return res;
        }


    }
}