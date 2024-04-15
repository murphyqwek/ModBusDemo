﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestMODBUS.Models.Data.Helpers
{
    public static class DataLog
    {
        public static string GetLog(DataStorage DataStorage)
        {
            return DataSaver.GetDataLog(DataStorage);
        }
        
        public static DataStorage ReadLog(string LogText)
        { 
            DataStorage dataStorage = DataReader.ReadLog(LogText);
            return dataStorage;
        }

    }
}
