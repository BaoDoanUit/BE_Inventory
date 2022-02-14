using MineralInventory.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace  MineralInventory.Respository
{
    public class PackingUnitDAL : BaseDAL
    {
        public bool InsertPackingUnit(PackingUnitInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call insert_packing_unit(@name, @code)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@name",model.NamePackingUnit.Trim());
                    param.Add("@code",model.CodePackingUnit.Trim());
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
        public bool UpdatePackingUnit(PackingUnitInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call update_packing_unit(@id_, @name_)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_",model.CodePackingUnit.Trim());
                    param.Add("@name_",model.NamePackingUnit.Trim());
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
        public bool SetDeletePackingUnit(int id,bool value)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call set_delete_packing_unit(@id_,@value)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_",id);
                    param.Add("@value",value);
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

        public List<PackingUnitInfo> GetListPackingUnit()
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from get_list_packing_unit()";
                    DynamicParameters param = new DynamicParameters();
                  
                    var res = conn.Query<PackingUnitInfo>(command,param).ToList();
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
        public List<PackingUnitInfo> GetListAllPackingUnit()
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_all_packing_unit()";
                    DynamicParameters param = new DynamicParameters();

                    var res = conn.Query<PackingUnitInfo>(command, param).ToList();
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