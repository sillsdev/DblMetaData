using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DblMetaData
{
    public partial class PromoPreview : Form
    {
        #region XmlData
        private string _xmlData;
        public string XmlData
        {
            get { return _xmlData; }
            set { _xmlData = value; }
        }
        #endregion XmlData

        public PromoPreview()
        {
            InitializeComponent();
        }

        private void PromoPreview_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = _xmlData;
        }
    }
}
