using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmTool.Domain
{

    public class ItemDto
    {
        public string VarName { get; set; }
        public string Type { get; set; }
        public string IsActive { get; set; }
        public string  value { get; set; }        
    }




    public class BasicConfigDto
    {
        
    }



    public class SubfolderDto
    {
        public string Name { get; set; }
        public SubfolderDto Parent;
        //public List<Item> Items = new List<Item>();
        public List<SubfolderDto> ChildFolder = new List<SubfolderDto>();
        public List<AttributeDto> Attributes = new List<AttributeDto>();

        public List<string> Comments = new List<string>();
        public bool IsItem
        {
            get
            {
                return String.Compare(Name, XmlConstants._item, true) == 0;
            }
        }

        public int NoOfChilds
        {
            get
            {
                return ChildFolder.Count;
            }
        }
        public int NoOfItems
        {
            get
            {
                return ChildFolder.Where(x => x.IsItem).Count();
            }
        }
        public override string ToString()
        {
            return string.Format("Name:{0} , NoOfChilds:{1}, Parent.Name:{2} , NoOfItems{3}", Name, NoOfChilds, Parent == null ? "Parent == null" : Parent.Name, NoOfItems);
        }
    }


    public class AttributeDto
    {
        public SubfolderDto Parent;
        public string Name { get; set; }
        public string Value { get; set; }

        public List<string> Comments = new List<string>();
        public override string ToString()
        {
            return String.Format("Parent.Name:{0}, Name:{1}, Value:{2}", Parent.Name, Name, Value);
        }
    }
}
