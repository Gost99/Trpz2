using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trpz2.Views.Interfaces
{
    public interface IClosable
    {
        event EventHandler RequestClose;
    }

    public interface IWarningShowable
    {
        event EventHandler RequestDialogBoxShow;
    }
}
