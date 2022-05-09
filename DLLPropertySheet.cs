using SharpShell.Attributes;
using SharpShell.SharpPropertySheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DLLTab
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".dll")]
    public class DLLPropertySheet : SharpPropertySheet
    {
        protected override bool CanShowSheet()
        {
            return SelectedItemPaths.Count() == 1;
        }

        protected override IEnumerable<SharpPropertyPage> CreatePages()
        {
            var dllPath = SelectedItemPaths.First();
            try
            {
                var peFile = new PeNet.PeFile(dllPath);
                return new SharpPropertyPage[]
                {
                    new ExportsPropertyPage(peFile.ExportedFunctions),
                    new ImportsPropertyPage(peFile.ImportedFunctions)
                };
            }
            catch (Exception ex)
            {
                LogError($"{dllPath} is not a valid PE DLL", ex);
                throw;
            }
        }
    }
}
