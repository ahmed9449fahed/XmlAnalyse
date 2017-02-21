using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlAnalyzerWPF.Business
{
   public class XmlParser
    {
        public static StructurInfo Execute(XDocument document)
        {
            if (document == null)
                throw new ArgumentNullException(nameof(document));


            var rootElement = document.Root;
            var rootInfo = new StructurInfo(rootElement.Name.LocalName);

            ParseRecursive(rootInfo, rootElement);
            AnalyzerUserControl.SourceCount =  rootInfo.Childs.First().Childs.Max(x => x.Data.Count());

            return rootInfo;
        }
        private static void ParseRecursive(StructurInfo info, XElement element)
        {
            if (!element.Elements().Any())
                info.AddData(element.Value);

            foreach (var childElement in element.Elements())
            {
                var childInfo = info.Childs.SingleOrDefault(x => x.Name == childElement.Name.LocalName);
                if (childInfo == null)
                {
                    childInfo = new StructurInfo(childElement.Name.LocalName);
                    info.AddChild(childInfo);
                }
                ParseRecursive(childInfo, childElement);
            }
        }
    }
}
