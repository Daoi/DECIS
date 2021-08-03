﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using DECIS.DataModels;

namespace DECIS.DataAccess.DataAccessors.Assets
{
    public class ImportAsset : DataSupport, IData
    {
        public ImportAsset()
        {
            CommandText = "ImportAsset";
            CommandType = CommandType.StoredProcedure;
        }

        public object ExecuteCommand(Asset ast, int id)
        {
            string sn = ast.SerialNumber;
            string desc = ast.Description;

            Parameters = new MySqlParameter[3] {
                new MySqlParameter("SerialNumber", sn),
                new MySqlParameter("Description", desc),
                new MySqlParameter("IntakeID", id)
            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteScalar(this); //Run the command
        }
    }
}