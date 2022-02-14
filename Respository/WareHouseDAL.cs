using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MineralInventory.Models;
using Npgsql;
namespace MineralInventory.Respository
{
    public class WareHouseDAL : BaseDAL
    {
        public bool InsertWareHouse(WareHouseInfo model)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    string command = "call insert_ware_house(@code_,@name_)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@code_", model.CodeWareHouse.Trim());
                    param.Add("@name_", model.NameWareHouse.Trim());
                    // param.Add("@capacity_",model.Capacity);

                    conn.Execute(command, param);
                    conn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }

            }
        }
        public bool UpdateWareHouse(WareHouseInfo model)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    string command = "call update_ware_house(@id_,@name_)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_", model.IdWareHouse);
                    param.Add("@name_", model.NameWareHouse.Trim());
                    //param.Add("@capacity_",model.Capacity);
                    conn.Execute(command, param);
                    conn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }

            }
        }

        public bool UpdateInventory(string reportDate)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "call schedule_inventory(@date)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@date", reportDate);
                    conn.Execute(command);
                    conn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }

            }
        }
        public bool SetDeleteWareHouse(int id,bool value)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "call set_delete_ware_house(@id_,@value)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_", id);
                    param.Add("@value", value);

                    conn.Execute(command, param);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }

            }
        }
        public List<WareHouseInfo> GetListWareHouse()
        {

            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_ware_house()";
                    var res = conn.Query<WareHouseInfo>(command).ToList();
                    conn.Close();
                    return res;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }

            }
        }
        public List<WareHouseInfo> GetListAllWareHouse()
        {

            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_all_ware_house()";
                    var res = conn.Query<WareHouseInfo>(command).ToList();
                    conn.Close();
                    return res;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }

            }
        }
    }
}