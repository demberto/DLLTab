using SharpShell.SharpPropertySheet;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DLLTab
{
    public partial class ExportsPropertyPage : SharpPropertyPage
    {
        private readonly PeNet.Header.Pe.ExportFunction[] _exports;
        private readonly int _exportCount;

        public ExportsPropertyPage(PeNet.Header.Pe.ExportFunction[] exports)
        {
            _exports = exports;
            _exportCount = _exports.Count();
            Log($"Found {_exportCount} exports");

            InitializeComponent();
            PageTitle = "Exports";

            // https://stackoverflow.com/a/42389596
            lv
                .GetType()
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                .SetValue(lv, true, null);
        }

        protected override void OnPropertyPageInitialised(SharpPropertySheet parent)
        {
            foreach (var export in _exports)
            {
                _ = lv.Items.Add(ExportAsItem(export));
            }
            numLbl.Text = $"{_exportCount} exports found";
        }

        private static ListViewItem ExportAsItem(PeNet.Header.Pe.ExportFunction export)
        {
            return new ListViewItem(
                new string[]
                { 
                    export.Ordinal.ToString(),
                    export.Name,
                    export.Address.ToString()
                });
        }

        private void OnSearchBoxEdit(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                numLbl.Text = $"{_exportCount} exports found";
                return;
            }

            var query = searchBox.Text.ToLower();
            lv.Items.Clear();
            foreach (var export in _exports)
            {
                if (export.Name.ToLower().Contains(query) ||
                    export.Ordinal.ToString().Contains(query) ||
                    export.Address.ToString().Contains(query))
                {
                    lv.Items.Add(ExportAsItem(export));
                }
            }
            numLbl.Text = $"{lv.Items.Count} export(s) found matching '{query}'";
        }
    }
}
