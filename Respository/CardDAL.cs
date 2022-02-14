using MineralInventory.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Globalization;

namespace  MineralInventory.Respository
{
    public class CardDAL : BaseDAL
    {

        public bool InsertCard50kg(List<TypeCard> list, string date, string nameShift, string user,string typeBill, string packingUnit)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {

                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    DynamicParameters param = new DynamicParameters();
                    conn.TypeMapper.MapComposite<TypeCard>("type_card");
                    string command = "call insert_card_50kg(@arr,@date,@nameshift,@user, @typeBill, @packingUnit)";
                    param.Add("@arr", list);
                    param.Add("@date", date);
                    param.Add("@nameShift", nameShift);
                    param.Add("@user", user);
                    param.Add("@typeBill", typeBill);
                    param.Add("@packingUnit", packingUnit);
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



        public bool UpdateCard50kg(List<TypeCard> list, string date, string nameShift,string user, string typeBill, string packingUnit)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                  
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    DynamicParameters param = new DynamicParameters();
                    conn.TypeMapper.MapComposite<TypeCard>("type_card");
                    string command = "call update_card_50kg(@arr,@date,@nameshift,@user,@typeBill,@packingUnit)";
                    param.Add("@arr", list);
                    param.Add("@date",date);
                    param.Add("@nameShift",nameShift);
                    param.Add("@user",user);
                    param.Add("@typeBill", typeBill);
                    param.Add("@packingUnit", packingUnit);
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
        public bool UpdateOneCard50kg(CardDetailInfo card)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {                 
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    DynamicParameters param = new DynamicParameters();
                    string command = "call update_one_card_50kg(@id,@product,@parcel,@type_product,@type_packet,"+
                    "@quantity,@warehouse,@packing_unit,@user )";
                    param.Add("@id", card.IdCard);
                    param.Add("@product", card.CodeProduct);
                    param.Add("@parcel", card.CodeParcel);
                    param.Add("@type_product", card.IdTypeProduct);
                    param.Add("@type_packet", card.CodeTypePacket);
                    param.Add("@quantity", card.Quantity);
                    param.Add("@warehouse", card.CodeWareHouse);
                    param.Add("@packing_unit", card.CodePackingUnit);
                    param.Add("@user", card.CreatedDate);
                  
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
        public bool DeleteCard(long id,string  user)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "call delete_card(@id, @user)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id", id);
                    param.Add("@user",user);
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
       
        
        public bool RunScheduleCard(DateTime date, string nameShift , DateTime start, DateTime end)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "CALL schedule_card_v2 (@date,@name,@start, @end)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@date", date.ToString("yyyy-MM-dd"));
                    parameters.Add("@name", nameShift);
                    parameters.Add("@start", start);
                    parameters.Add("@end", end);

                    conn.Execute(command, parameters);
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
        public List<CardDetailInfo> GetListCard(string fromDate, string toDate)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_card(@from_date, @to_date)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@from_date", fromDate);
                    parameters.Add("@to_date", toDate);
                    var res = conn.Query<CardDetailInfo>(command, parameters).ToList();
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
        public List<CardDetailInfo> GetListCardByWeight(string fromDate, string toDate,int weight)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_card_by_weight(@from_date, @to_date, @weight)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@from_date", fromDate);
                    parameters.Add("@to_date", toDate);
                    parameters.Add("@weight", weight);
                    var res = conn.Query<CardDetailInfo>(command, parameters).ToList();
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
        public bool InsertCard(List<TypeQrCodeModel> arr, string date, string nameShift)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {

                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    DynamicParameters param = new DynamicParameters();
                    conn.TypeMapper.MapComposite<TypeQrCodeModel>("type_qrcode");
                    string command = "call insert_card(@date,@name,@arr)";
                    param.Add("@arr", arr);
                    param.Add("@date", date);
                    param.Add("@name", nameShift);
                    //param.Add("@packing_unit", model.code_packing_unit);

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
        public List<CardDetailInfo> GetCardById(long id)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_card_by_id(@id)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@id", id);
                   
                    var res = conn.Query<CardDetailInfo>(command, parameters).ToList();
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
        public List<CardDetailInfo> GetListCard50kgByShift(string date, string nameShift)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_card_50kg_by_shift(@date, @nameshift)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@date", date);
                    parameters.Add("@nameshift", nameShift);
                    var res = conn.Query<CardDetailInfo>(command, parameters).ToList();
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