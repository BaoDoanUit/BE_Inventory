using MineralInventory.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace  MineralInventory.Respository
{
    public class MasterDAL : BaseDAL
    {
        public bool InsertMaster(MasterDataInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call insert_master(@name,@type,@code,@cate)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@code",model.ObjectCode.Trim().ToUpper());
                    param.Add("@name",model.ObjectName.Trim());
                    param.Add("@type",model.ObjectType.Trim().ToUpper());
                    param.Add("@cate",model.ObjectCate.Trim().ToUpper());
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
        public bool UpdateMaster(MasterDataInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call update_master(@id,@name,@cate)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id",model.ObjectId);
                    param.Add("@name",model.ObjectName.Trim());
                    param.Add("@cate",model.ObjectCate.Trim().ToUpper());
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
        public bool SetDeleteMaster(int id,bool value)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call set_deleted_master(@id,@value)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id",id);
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

        public List<MasterDataInfo> GetListMaster()
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from get_list_master()";
                    DynamicParameters param = new DynamicParameters();
                  
                    var res = conn.Query<MasterDataInfo>(command,param).ToList();
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
        public List<MasterDataInfo> GetListTypeMaster()
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from get_list_type_master()";
                    DynamicParameters param = new DynamicParameters();
                  
                    var res = conn.Query<MasterDataInfo>(command,param).ToList();
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