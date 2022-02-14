using MineralInventory.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace MineralInventory.Respository
{
    public class ShiftDAL : BaseDAL
    {

        public bool NewInsertShift(List<TypeShiftDetail> list, string nameShift, string date, int personCreated)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    DynamicParameters param = new DynamicParameters();
                    conn.TypeMapper.MapComposite<TypeShiftDetail>("type_shift_detail");
                    string command = "call insert_shift(@arr,@name_, @person_, @date_)";
                    param.Add("@arr", list);
                    param.Add("@name_", nameShift.Trim());
                    param.Add("@person_", personCreated);
                    param.Add("@date_", date.Trim());
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
        public bool NewUpdateInsertShift(List<TypeShiftDetail> list, int idShift)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    DynamicParameters param = new DynamicParameters();
                    conn.TypeMapper.MapComposite<TypeShiftDetail>("type_shift_detail");
                    string command = "call update_shift_detail(@arr,@idshift)";
                    param.Add("@arr", list);
                    param.Add("@idShift", idShift);
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
        public bool DeleteShift(int id)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "call delete_shift(@id_)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_", id);

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
        public List<ShiftInfo> GetListShiftByDate(string date)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_shift_by_date(@date)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("date", date);

                    var res = conn.Query<ShiftInfo>(command, param).ToList();
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
        public List<ShiftInfo> GetShiftById(int id)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_shift_by_id(@id)";
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@id", id);
                    var res = conn.Query<ShiftInfo>(command, dynamicParameters).ToList();
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
        public bool InsertShift(string date, string nameShift)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    DynamicParameters param = new DynamicParameters();
                    conn.TypeMapper.MapComposite<TypeShiftDetail>("type_shift_detail");
                    string command = "call insert_shift( @date, @name)";
                    param.Add("@name", nameShift.Trim());
                    param.Add("@date", date.Trim());
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

    }
}