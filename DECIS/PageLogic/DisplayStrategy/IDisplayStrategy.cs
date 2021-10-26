using DECIS.PageLogic.ControlContainerBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECIS.PageLogic.DisplayStrategy
{
    public interface IDisplayStrategy
    {
        bool Display(ControlContainer controlContainer, object dataModel);
    }
}
