using System.ComponentModel;
using System.Windows.Forms;
using XmlAnalyser.Business;

namespace XmlAnalyser.UserInterface
{
    public partial class StructureInfoView : UserControl
    {
        public StructureInfoView()
        {
            InitializeComponent();

            Domain.Instance.PropertyChanged += InstanceOnPropertyChanged;
        }

        private void InstanceOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == nameof(Domain.StructureInfo))
            {
                treeView1.Nodes.Clear();

                var rootInfo = Domain.Instance.StructureInfo;
                var rootNode = new TreeNode(rootInfo.Name);
                rootNode.Tag = rootInfo;
                treeView1.Nodes.Add(rootNode);

                AddChildNodesRecursive(rootInfo, rootNode);

                treeView1.ExpandAll();
            }
        }

        private void AddChildNodesRecursive(StructureInfo info, TreeNode node)
        {
            foreach (var childInfo in info.Childs)
            {
                var childNode = new TreeNode(childInfo.Name);
                childNode.Tag = childInfo;
                node.Nodes.Add(childNode);
                AddChildNodesRecursive(childInfo, childNode);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            
            var structureInfo = e.Node.Tag as StructureInfo;
            Domain.Instance.SelectedStructureInfo = structureInfo;
        }
    }
}