using System.Collections.Generic;
using Dapper;
using MineralInventory.Models;
using Npgsql;
using System;
using System.Linq;
using System.Data;

namespace MineralInventory.Respository
{
    public class UserDAL: BaseDAL
    {
       public bool InsertUser(UserInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                   string command  = "call insert_user(@username ,@pass , @role , @name)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@username",model.User.Trim());
                    param.Add("@role",model.Role);
                    param.Add("@name",model.Name.Trim());
                    param.Add("@pass",model.Password);
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
        }public bool UpdateUser(UserInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call update_user(@id_,@role_, @name_)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_",model.ID);
                    param.Add("@role_",model.Role);
                    param.Add("@name_",model.Name);
                   
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
        public bool DeleteUser(int id)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call delete_user(@id_)";
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
        public List<UserInfo> GetListUser()
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from get_list_user()";
                  
                var res = conn.Query<UserInfo>(command).ToList();
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
        public List<UserInfo> GetListAllUser()
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from get_list_all_user()";
                  
                    var res = conn.Query<UserInfo>(command).ToList();
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

        public bool UpdateUserPassword(int userId, string password)
        {
             using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call update_user_password(@id_ , @password_)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_",userId);
                    param.Add("@password_",password);
                    var res = conn.Query<UserInfo>(command,param).ToList();
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
    }
}