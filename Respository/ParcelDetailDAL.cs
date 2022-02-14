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
    public class ParceDetailDAL:BaseDAL
    {
        public List<ParcelDetailInfo> GetListParcelDetail(string fromDate, string toDate)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    string command = "select * from get_list_parcel_detail(@fromDate, @toDate)";
                    if(conn.State != ConnectionState.Open)
                        conn.Open();

                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@fromDate", fromDate);
                    dynamicParameters.Add("toDate", toDate);
                    var res = conn.Query<ParcelDetailInfo>(command,dynamicParameters).ToList();
                    
                    return res;
                }catch(Exception e)
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
        public List<ParcelDetailInfo> GetListParcelDetailByCode(string codeParcel)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    string command = "select * from get_list_parcel_detail_by_code(@codeParcel)";
                    
                    if(conn.State != ConnectionState.Open)
                        conn.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@codeParcel",codeParcel);
                    var res = conn.Query<ParcelDetailInfo>(command,param).ToList();
                    
                    return res;
                }catch(Exception e)
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
