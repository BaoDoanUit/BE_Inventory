using MineralInventory.Models;
using MineralInventory.Respository;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace MineralInventory.Respository
{
    public class ParcelDAL:BaseDAL
    {
        
        public bool InsertParcel(string code,int person,List<TypeParcelDetail> list)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call insert_parcel(@arr_ ,@code_, @person_)";
                    DynamicParameters param = new DynamicParameters();
                    conn.TypeMapper.MapComposite<TypeParcelDetail>("type_parcel_detail");
                    param.Add("@arr_",list);
                    param.Add("@code_",code);
                    param.Add("@person_",person);
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
        public bool UpdateParcel(string codeParcel,List<TypeParcelDetail> list)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call update_parcel(@arr_ ,@code_)";
                    DynamicParameters param = new DynamicParameters();
                    conn.TypeMapper.MapComposite<TypeParcelDetail>("type_parcel_detail");
                    param.Add("@arr_",list);
                    param.Add("@code_",codeParcel);

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
        public bool DeleteParcel(string codeParcel)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "call delete_parcel(@code)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@code", codeParcel);

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
        public List<ParcelInfo> GetListAllParcel()
        {
          
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    string command = "select * from get_list_parcel()";
                    DynamicParameters param = new DynamicParameters();
                    var res = conn.Query<ParcelInfo>(command).ToList();
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
        public List<ParcelInfo> GetListParcel(string fromDate, string toDate)
        {
          
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    string command = "select * from get_list_parcel(@fromdate, @todate)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@fromdate",fromDate);
                    param.Add("@todate",toDate);
                    var res = conn.Query<ParcelInfo>(command,param).ToList();
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
        public List<ParcelInfo> GetParcelByCode(string code)
        {  
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_parcel_by_code(@code)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@code", code);
                    var res = conn.Query<ParcelInfo>(command,parameters).ToList();
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
