using MineralInventory.Models;
using System.Collections.Generic;
using Dapper;
using Npgsql;
using System.Data;
using System;
using System.Linq;

namespace MineralInventory.Respository
{
    public class ConfirmProductDAL :BaseDAL
    {
        public bool UpDateConfirmProduct(List<TypeConfirmProduct> list,int idUser,string date, string nameShift)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    DynamicParameters param = new DynamicParameters();
                    conn.TypeMapper.MapComposite<TypeConfirmProduct>("type_confirm_product");
                    string command = "call update_confirm_product(@arr,@user,@date,@nameshift)";
                    param.Add("@arr", list);
                    param.Add("@user", idUser);
                    param.Add("@date", date);
                    param.Add("@nameshift", nameShift);
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
        public List<ConfirmProductionDetail> GetListConfirmProduct(string fromDate,string toDate)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_confirm_product(@fromDate, @toDate)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@fromDate", fromDate);
                    param.Add("@toDate", toDate);
                    var res = conn.Query<ConfirmProductionDetail>(command, param).ToList();
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
        public List<ConfirmProductionDetail> GetListConfirmProductByShift(string date,string nameShift)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_confirm_product_by_shift(@date, @name)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@date", date);
                    param.Add("@name", nameShift);
                    var res = conn.Query<ConfirmProductionDetail>(command, param).ToList();
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
        public List<ConfirmProductionDetail> GetListConfirmProductDisplayByShift(string date,string nameShift)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_confirm_product_display_by_shift(@date, @name)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@date", date);
                    param.Add("@name", nameShift);
                    var res = conn.Query<ConfirmProductionDetail>(command, param).ToList();
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
