using MineralInventory.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace  MineralInventory.Respository
{
    public class QrCodeDAL : BaseDAL
    {      
        public List<TypeQrCodeModel> GetListQrCodeByShift(string date, string nameShift)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from get_list_qrcode_by_shift(@date, @name)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@name",nameShift);
                    param.Add("@date",date);
                    var res = conn.Query<TypeQrCodeModel>(command,param).ToList();
                    return res;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }finally
                {
                    if(conn.State != ConnectionState.Closed)
                        conn.Close();
                }
               
            }
        }
    }
}