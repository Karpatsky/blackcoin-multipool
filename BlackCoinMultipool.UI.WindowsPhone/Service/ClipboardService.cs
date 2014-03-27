using BlackCoinMultipool.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlackCoinMultipool.UI.WindowsPhone.Service
{
    public class ClipboardService : IClipboardService
    {
        public void CopyToClipboard(object item)
        {
            // copy the object to the clipboard as a string, if it is not a string the clipboard will be cleared.
            var text = item as string;
            Clipboard.SetText(text);
        }
    }
}
