using DECIS.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.PageLogic.AssetUpload
{
    public class SetAssetType
    {
        private const int COMPUTER = 21;
        private const int LAPTOP = 22;
        private const int MONITOR = 23;
        private const int PRINTER = 24;
        private const int PROJECTOR = 25;
        private const int OTHER = 26;

        public static Asset SetMake(Asset a)
        {
            string type = a.AssetType;
            if (type.ToLower() == "computer")
                a.ModelID = COMPUTER;
            else if (type.ToLower() == "laptop")
                a.ModelID = LAPTOP;
            else if (type.ToLower() == "monitor")
                a.ModelID = MONITOR;
            else if (type.ToLower() == "printer")
                a.ModelID = PRINTER;
            else if (type.ToLower() == "projector")
                a.ModelID = PROJECTOR;
            else if (type.ToLower() == "other")
                a.ModelID = OTHER;

            return a;
        }
    }
}