using MineralInventory.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace  MineralInventory.Respository
{
    public class DeviceDAL : BaseDAL
    {
        public bool InsertDevice(DeviceInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call insert_device( @device, @pass , @type, @option)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@device",model.Device.Trim());
                    param.Add("@pass",model.Password);
                    param.Add("@type",model.Type, DbType.Int16);
                    param.Add("@option",model.Option.Trim());                  
                    conn.Execute(command,param);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }finally
                {
                    if(conn.State != ConnectionState.Closed)
                        conn.Close();
                }
               
            }
        }
        public bool UpdateDevice(DeviceInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call update_device(@id_,@mac_, @name_, @function_, @code_packing_unit_)";
                    DynamicParameters param = new DynamicParameters();
                    //param.Add("@id_",model.id_device);
                    //param.Add("@name_",model.name_device);
                    //param.Add("@mac_",model.mac_device);
                    //param.Add("@function_",model.function);
                    //param.Add("@code_packing_unit_",model.code_packing_unit);
                    
                    conn.Execute(command,param);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }finally
                {
                    if(conn.State != ConnectionState.Closed)
                        conn.Close();
                }
               

            }
        }
        public bool DeleteDevice(int id)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call delete_device(@id_)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_",id);
                  
                    conn.Execute(command,param);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }finally
                {
                    if(conn.State != ConnectionState.Closed)
                        conn.Close();
                }
               
            }
        }
        public List<DeviceInfo> GetListDevice()
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from get_list_device()";
                    DynamicParameters param = new DynamicParameters();
                  
                    var res = conn.Query<DeviceInfo>(command,param).ToList();
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