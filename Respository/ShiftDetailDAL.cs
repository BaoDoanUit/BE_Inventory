using MineralInventory.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace  MineralInventory.Respository
{
    public class ShiftDetailDAL : BaseDAL
    {
        
        public List<ShiftDetailInfo> GetListShiftDetail(string fromDate, string toDate)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from get_list_shift_detail(@fromDate, @toDate)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@fromDate", fromDate);
                    param.Add("@toDate", toDate);
                    var res = conn.Query<ShiftDetailInfo>(command,param).ToList();
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
        public List<ShiftDetailInfo> GetShiftDetail(int id)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from get_shift_detail_by_id(@id)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id",id);
                    var res = conn.Query<ShiftDetailInfo>(command,param).ToList();
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