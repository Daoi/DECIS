using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DECIS.PageLogic.ControlContainerBase;

namespace DECIS.PageLogic.DisplayStrategy
{
    public class DisplayContext
    {
        private IDisplayStrategy _displayStrategy;
        private object _dataModel;
        private ControlContainer _controlContainer;
        
        public DisplayContext(IDisplayStrategy strategy, ControlContainer controlContainer, object dataModel)
        {
            _displayStrategy = strategy;
            _dataModel = dataModel;
            _controlContainer = controlContainer;

        }

        public bool Display()
        {
            try
            {
                if(_displayStrategy.Display(_controlContainer, _dataModel))
                    return true;
            }
            catch(Exception ex)
            {
                return false;
            }

            return false;
        }
    }
}