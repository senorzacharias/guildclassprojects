﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Settings
   {
       private static string _connectionString;

       public static string ConnectionString
       {
           get
           {
               if (string.IsNullOrEmpty(_connectionString))
               {
                   _connectionString = ConfigurationManager.ConnectionStrings["Practice"].ConnectionString;
               }
               return _connectionString;
           }
       }
   }
}
