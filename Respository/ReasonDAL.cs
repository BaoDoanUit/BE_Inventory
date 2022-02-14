using MineralInventory.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace  MineralInventory.Respository
{
    public class ReasonDAL : BaseDAL
    {
        public bool InsertReason(ReasonInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call insert_reason(@code_, @name_)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@code_",model.CodeReason.Trim());
                    param.Add("@name_",model.NameReason.Trim());
                   
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
        }public bool UpdateReason(ReasonInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call update_reason(@id_, @name_)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_",model.IdReason);
                    param.Add("@name_",model.NameReason);
                   
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
        public bool SetDeleteReason(int id, bool value)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call set_delete_reason(@id_,@value)";
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
        public List<ReasonInfo> GetListReason()
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from get_list_reason()";
                    DynamicParameters param = new DynamicParameters();
                   
                    var res = conn.Query<ReasonInfo>(command,param).ToList();
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
        public List<ReasonInfo> GetListAllReason()
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from get_list_all_reason()";
                    DynamicParameters param = new DynamicParameters();
                  
                    var res = conn.Query<ReasonInfo>(command,param).ToList();
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