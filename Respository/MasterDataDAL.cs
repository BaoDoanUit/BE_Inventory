using Dapper;
using MineralInventory.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace MineralInventory.Respository
{
    public class MasterDataDAL : BaseDAL
    {

        public List<MasterDataInfo> GetListTypeEquipment()
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_type_equipment()";
                    DynamicParameters param = new DynamicParameters();

                    var res = conn.Query<MasterDataInfo>(command, param).ToList();
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
        public List<MasterDataInfo> GetListTypePartner()
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_type_partner()";
                    DynamicParameters param = new DynamicParameters();

                    var res = conn.Query<MasterDataInfo>(command, param).ToList();
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
        public List<MasterDataInfo> GetListPosition()
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_position()";
                    DynamicParameters param = new DynamicParameters();

                    var res = conn.Query<MasterDataInfo>(command, param).ToList();
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

        public List<MasterDataInfo> GetMasterData()
        {   
            using (var conn = new NpgsqlConnection(GetConnection()))
            {   
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_master_data()";
                    DynamicParameters param = new DynamicParameters();
                    var res = conn.Query<MasterDataInfo>(command, param).ToList();
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