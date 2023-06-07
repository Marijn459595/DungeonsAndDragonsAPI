using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access
{
    public static class Connection
    {
        public readonly static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\marij\Documents\School\2022 - 2023 Hbo S4-S3\S3\Individueel Project\Database\DNDdb.mdf';Integrated Security=True;Connect Timeout=30";
    }
}
