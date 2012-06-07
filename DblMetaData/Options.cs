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
    public partial class Options : Form
    {
        #region AlwaysNT
        private bool _alwaysUseNT;
        public bool AlwaysUseNT
        {
            get { return _alwaysUseNT; }
            set { _alwaysUseNT = value; }
        }
        #endregion AlwaysNT

        #region TransAgency
        private string _translationAgency;
        public string TransAgency 
        {
            get { return _translationAgency; }
            set { _translationAgency = value; }
        }
        #endregion TransAgency

        public Options()
        {
            InitializeComponent();
            _alwaysUseNT = AlwaysNT.Checked;
            _translationAgency = TranslationAgency.Text;
        }

        private void AlwaysNT_CheckedChanged(object sender, EventArgs e)
        {
            _alwaysUseNT = AlwaysNT.Checked;
        }

        private void TranslationAgency_TextChanged(object sender, EventArgs e)
        {
            _translationAgency = TranslationAgency.Text;
        }
    }
}
