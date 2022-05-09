using SharpShell.SharpPropertySheet;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DLLTab
{
    public partial class ImportsPropertyPage : SharpPropertyPage
    {
        private readonly PeNet.Header.Pe.ImportFunction[] _imports;
        private readonly int _importCount = 0;

        public ImportsPropertyPage(PeNet.Header.Pe.ImportFunction[] imports)
        {
            _imports = imports;
            _importCount = _imports.Count();
            Log($"Found {_importCount} imports");

            InitializeComponent();
            PageTitle = "Imports";

            // https://stackoverflow.com/a/42389596
            lv.GetType()
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                .SetValue(lv, true, null);
        }

        protected override void OnPropertyPageInitialised(SharpPropertySheet parent)
        {
            foreach (var import in _imports)
            {
                _ = lv.Items.Add(ImportAsItem(import));
            }
            numLbl.Text = $"{_importCount} imports found";
        }

        private static ListViewItem ImportAsItem(PeNet.Header.Pe.ImportFunction import)
        {
            return new ListViewItem(
                new string[]
                {
                    import.Name,
                    import.DLL,
                    import.IATOffset.ToString()
                });
        }

        private void OnSearchBoxEdit(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                numLbl.Text = $"{_importCount} imports found";
                return;
            }

            var query = searchBox.Text.ToLower();
            lv.Items.Clear();
            foreach (var import in _imports)
            {
                if (import.Name.ToLower().Contains(query) ||
                    import.DLL.ToLower().Contains(query) ||
                    import.IATOffset.ToString().Contains(query))
                {
                    lv.Items.Add(ImportAsItem(import));
                }
            }
            numLbl.Text = $"{lv.Items.Count} import(s) found matching '{query}'";
        }
    }
}
