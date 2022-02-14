
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Dapper;
using Npgsql;

namespace MineralInventory.Respository
{
    public class BaseDAL
    {
        public string GetConnection()
        {
            return String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};"
                , "61.28.238.94"
                , "50001"
                , "postgres"
                , "stvg"
                , "db_mineral_inventory");
        }
        private NpgsqlConnection _conn;
        public NpgsqlConnection Conn
        {
            get
            {
                return _conn = new NpgsqlConnection(GetConnection());
            }
        }
    }
}
