using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Configurator
{


    public static class XExtensions
    {
        public static XElement Element(this XElement element, XName name, bool ignoreCase)
        {
            var el = element.Element(name);
            if (el != null)
                return el;

            if (!ignoreCase)
                return null;

            var elements = element.Elements().Where(s => string.Compare(s.Name.ToString(), name.LocalName, true) == 0); ;
            return elements.Count() == 0 ? null : elements.FirstOrDefault();
        }

        public static IEnumerable<XElement> Elements(this XElement element, XName name, bool ignoreCase)
        {
            var el = element.Elements(name);
            if (el.Count() >0)
                return el;

            if (!ignoreCase)
                return el;

            var elements = element.Elements().Where(s => string.Compare(s.Name.ToString(), name.LocalName, true) == 0);
            return elements;
        }


        public static IEnumerable<XAttribute> Attributes(this XElement element, XName name, bool ignoreCase)
        {
            var at = element.Attributes(name);
            if (at.Count() > 0 )
                return at;

            if (!ignoreCase)
                return at;

            var attributes = element.Attributes().Where(s => string.Compare(s.Name.ToString(), name.LocalName, true) == 0);
            return attributes;
        }

    }
}
