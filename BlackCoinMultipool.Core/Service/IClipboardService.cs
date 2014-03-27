using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCoinMultipool.Core.Service
{
    public interface IClipboardService
    {
        void CopyToClipboard(object item);
    }
}
