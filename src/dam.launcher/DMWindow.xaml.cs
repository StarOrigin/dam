using DevExpress.Utils;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.TreeList;
using org.starorigin.dam.core.model.file;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace org.starorigin.dam.launcher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DMWindow : DXWindow
    {
        FileSystemDataProviderBase Helper { get; set; }
        public DMWindow()
        {
            InitializeComponent();
            Helper = new FileSystemHelper();
            InitDrives();
        }
        public void InitDrives()
        {
            fileTree.BeginDataUpdate();
            string[] root = Helper.GetLogicalDrives();

            foreach (string s in root)
            {
                TreeListNode node = new TreeListNode()
                {
                    Content = new Partition() { Name = s },
                    Image = FileSystemImages.DiskImage
                };
                fileView.Nodes.Add(node);
                node.IsExpandButtonVisible = DefaultBoolean.True;
                node.Tag = false;
            }
            fileTree.EndDataUpdate();
        }

        private void fileView_NodeExpanding(object sender, TreeListNodeAllowEventArgs e)
        {
            TreeListNode node = e.Node;
            if (NodeIsFolder(node))
                node.Image = FileSystemImages.OpenedFolderImage;
            if (node.Tag == null || (bool)node.Tag == false)
            {
                InitFolder(node);
                node.Tag = true;
            }
        }

        private void mgrView_NodeExpanding(object sender, TreeListNodeAllowEventArgs e)
        {
            TreeListNode node = e.Node;
            if (NodeIsFolder(node))
                node.Image = FileSystemImages.OpenedFolderImage;
            if (node.Tag == null || (bool)node.Tag == false)
            {
                InitFolder(node);
                node.Tag = true;
            }
        }

        private void InitFolder(TreeListNode treeListNode)
        {
            fileTree.BeginDataUpdate();
            InitFolders(treeListNode);
            InitFiles(treeListNode);
            fileTree.EndDataUpdate();
        }

        private void InitFolders(TreeListNode treeListNode)
        {
            Directory item = treeListNode.Content as Directory;
            if (item == null) return;

            try
            {
                string[] root = Helper.GetDirectories(item.Path);
                foreach (string s in root)
                {
                    TreeListNode node = new TreeListNode()
                    {
                        Content = new Directory() { Name = Helper.GetDirectoryName(s), Parent = item },
                        Image = FileSystemImages.ClosedFolderImage
                    };
                    treeListNode.Nodes.Add(node);
                    node.IsExpandButtonVisible = HasFiles(s) ?
                        DefaultBoolean.True : DefaultBoolean.False;
                }
            }
            catch
            {
                treeListNode.IsExpandButtonVisible = DefaultBoolean.False;
            }
        }

        private bool HasFiles(string path)
        {
            string[] root = Helper.GetFiles(path);
            if (root.Length > 0) return true;
            root = Helper.GetDirectories(path);
            if (root.Length > 0) return true;
            return false;
        }

        private void InitFiles(TreeListNode treeListNode)
        {
            Directory item = treeListNode.Content as Directory;
            if (item == null) return;
            TreeListNode node;

            string[] root = Helper.GetFiles(item.Path);
            foreach (string s in root)
            {
                node = new TreeListNode()
                {
                    Content = new File() { Name = Helper.GetFileName(s), Size = Helper.GetFileSize(s), Parent = item },
                    Image = FileSystemImages.FileImage
                };
                node.IsExpandButtonVisible = DefaultBoolean.False;
                treeListNode.Nodes.Add(node);
            }
        }

        private void fileView_NodeCollapsing(object sender, DevExpress.Xpf.Grid.TreeList.TreeListNodeAllowEventArgs e)
        {
            TreeListNode node = e.Node;
            if (NodeIsFolder(node))
                node.Image = FileSystemImages.ClosedFolderImage;
        }

        private void mgrView_NodeCollapsing(object sender, DevExpress.Xpf.Grid.TreeList.TreeListNodeAllowEventArgs e)
        {
            TreeListNode node = e.Node;
            if (NodeIsFolder(node))
                node.Image = FileSystemImages.ClosedFolderImage;
        }

        bool NodeIsFolder(TreeListNode node)
        {
            return node.Content is Directory || node.Content is Partition;
        }
    }
}
