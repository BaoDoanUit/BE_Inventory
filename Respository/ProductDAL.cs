using MineralInventory.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace  MineralInventory.Respository
{
    public class ProductDAL : BaseDAL
    {
        public bool InsertProduct(ProductInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call insert_product(@code_, @name_,@weight_)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@code_",model.CodeProduct.Trim());
                    param.Add("@name_",model.NameProduct.Trim());
                     param.Add("@weight_",model.Weight);

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
        public bool UpdateProduct(ProductInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call update_product(@id_, @name_)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_",model.IdProduct);
                    param.Add("@name_",model.NameProduct);

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
        public bool SetDeleteProduct(int id, bool value)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call set_delete_product(@id_,@value_)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_",id);
                    param.Add("@value_",value);
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

        public List<ProductInfo> GetListProduct()
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from get_list_product()";
                    DynamicParameters param = new DynamicParameters();
                  
                    var res = conn.Query<ProductInfo>(command,param).ToList();
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
        public List<ProductInfo> GetListAllProduct()
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from get_list_all_product()";
                    DynamicParameters param = new DynamicParameters();
                  
                    var res = conn.Query<ProductInfo>(command,param).ToList();
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