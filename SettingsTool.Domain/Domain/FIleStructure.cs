using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SettingsTool.Domain
{


    public static class XmlConstants
    {
        public const string _item = "item";
        public const string _varName = "VarName";
        public const string _IsActive = "IsActive";
        public const string _Type = "Type";
        public const string _Value = "value";
        public const string _Revision = "Revision";
    }

  
 
    public class ConfigOrSettingsContent
    {
        
        //  debug 
        protected int itCounter = 0;
        protected XDocument xDocument { get; set; }

        public List<SubfolderDto> Subfolders = new List<SubfolderDto>();

        public ConfigOrSettingsContent(XDocument xDocument)
        {
            this.xDocument = xDocument;
            SubfolderDto sf = null;
            LoadIterative(xDocument.Root, sf);
        }


        public int NoOfItems()
        {
            return Subfolders.Sum(x => x.NoOfItems);
        }

        public int NoOfItemSubfolders()
        {
            return Subfolders.Where(x => x.NoOfItems > 0).Count();
        }

   
        protected void RetrieveCommentsAndAttributes(XElement xe, SubfolderDto sub)
        {
            var attributes = xe.Attributes();
            foreach (var at in attributes)
            {
                var attr = new AttributeDto { Parent = sub, Name = at.Name.ToString(), Value = at.Value };
                sub.Attributes.Add(attr);
            }

            var comments = xe.Elements().OfType<XComment>();

            foreach (var comment in comments)
            {
                sub.Comments.Add(comment.Value);
            }
        }

        
        public XDocument EmptyXDocument()
        {
            foreach(var sf in Subfolders)
            {
                sf.Attributes.Clear();
            }
            return SaveChangesToXDocument();
        }
       
        protected void LoadIterative(XElement xelement, SubfolderDto subfolder)
        {
            itCounter++;
            var name = xelement.Name.ToString();

            if (xelement.Elements().Count() == 0)
            {
                return;
            }

            if (subfolder == null)
            {
                subfolder = new SubfolderDto { Name = xelement.Name.ToString(), Parent = null };
                RetrieveCommentsAndAttributes(xelement, subfolder);
                Subfolders.Add(subfolder);
            }

            var list = xelement.Elements().ToList();
            for (int idx = 0; idx < list.Count(); idx++)
            {
                var elm = list[idx];
                var s1 = new SubfolderDto { Name = elm.Name.ToString(), Parent = subfolder };
                RetrieveCommentsAndAttributes(elm, s1);
                subfolder.ChildFolder.Add(s1);
                Subfolders.Add(s1);
                LoadIterative(elm, s1);
            }
        }

        public XDocument SaveChangesToXDocument()
        {
            //var xes = xDocument.Root.Descendants().Where( x => String.Compare(x.Name.LocalName ;
            //var no =  xes.Count();



            // 1. Alle nicht existierende löschen

            // 2. Update der Attribute => hinzufügen, löschen bzw. WErt ändern
            // 3. Hinzufügen von (Unterknoten)Knoten 
            return xDocument;
        }
    }
}
