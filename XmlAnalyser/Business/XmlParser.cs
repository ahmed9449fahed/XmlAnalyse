using System;
using System.Linq;
using System.Xml.Linq;
using XmlAnalyser.Business.devexpresstools;
using XmlAnalyser.UserInterface;

namespace XmlAnalyser.Business
{
    internal class XmlParser
    {
        public static StructureInfo Execute(XDocument document)
        {
            if (document == null)
                throw new ArgumentNullException(nameof(document));


            var rootElement = document.Root;
            var rootInfo = new StructureInfo(rootElement.Name.LocalName);

            ParseRecursive(rootInfo, rootElement);
            DataInfoView.SourceCount= DevDataInfo.SourceCount = rootInfo.Childs.First().Childs.Max(x => x.Data.Count());
            
            return rootInfo;
        }


        private static void ParseRecursive(StructureInfo info, XElement element)
        {
            if (!element.Elements().Any())
                info.AddData(element.Value);

            foreach (var childElement in element.Elements())
            {
                var childInfo = info.Childs.SingleOrDefault(x => x.Name == childElement.Name.LocalName);
                if (childInfo == null)
                {
                    childInfo = new StructureInfo(childElement.Name.LocalName);
                    info.AddChild(childInfo);
                }
                ParseRecursive(childInfo, childElement);
            }
        }
    }
}