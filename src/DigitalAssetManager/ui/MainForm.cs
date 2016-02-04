using org.starorigin.dam.core.db;
using org.starorigin.dam.core.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace org.tempusx.dam.ui
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
            DbUtils.InitDb();
            BindData();
        }

        private void BindData()
        {
            var catalogs = DbUtils.Db.GetCollection<Catalog>("Catalog");
            foreach (Catalog catalog in catalogs.Find(x => x.Parent == null))
            {
                var node = treeView.Nodes.Add(catalog.Name);
                if (catalogs.Exists(x => x.Parent == catalog))
                    foreach (Catalog catalog2 in catalogs.Find(x => x.Parent == catalog))
                    { var node2 = node.Nodes.Add(catalog2.Name); }
            }
            
        }
    }
}
