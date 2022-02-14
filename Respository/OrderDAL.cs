using System;
using System.Data;
using Dapper;
using Npgsql;
using System.Linq;
using System.Collections.Generic;

namespace MineralInventory.Respository
{
    public class OrderDAL:BaseDAL
    {
        public string InsertOrder(OrderInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "select * from insert_order_v1(@code_order, @identity_driver, @name_driver , @ro_mooc, @vehicle_number, @weight_registration, @weight_allow ," +
                     "@code_product, @code_type_packet, @quantity, @shipping_unit, @class1, @class2, @customer, @typecustomer,@warehouse,@typeProduct)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@code_order",model.CodeOrder);
                    param.Add("@identity_driver",model.IdentityDriver);
                    param.Add("@name_driver",model.NameDriver);
                    param.Add("@ro_mooc",model.RoMooc);
                    param.Add("@vehicle_number",model.VehicleNumber);
                    param.Add("@weight_allow",model.WeightAllow);
                    param.Add("@weight_registration",model.WeightRegistration);
                    param.Add("@code_product",model.CodeProduct);
                    param.Add("@quantity",model.Quantity);
                    param.Add("@shipping_unit",model.IdTransportationUnit);
                    param.Add("@class1",model.Class1);
                    param.Add("@class2",model.Class2);
                    param.Add("@code_type_packet", model.CodeTypePacket);
                    param.Add("@customer", model.Customer);
                    param.Add("@typecustomer", model.TypeCustomer);
                    param.Add("@warehouse", model.WareHouse);
                    param.Add("@typeProduct", model.IdTypeProduct);
                    string res = conn.Query<string>(command,param).FirstOrDefault();
                    return res ;
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
        public bool UpdateOrder(OrderInfo model)
        {
            using(var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if(conn.State  != ConnectionState.Open)
                        conn.Open();
                    string command  = "call update_order(@code_order, @identity_driver, @name_driver , @ro_mooc, @vehicle_number, @weight_registration, @weight_allow ," +
                     "@code_product, @code_type_packet, @quantity, @shipping_unit, @class1, @class2)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@code_order",model.CodeOrder);
                    param.Add("@identity_driver",model.IdentityDriver);
                    param.Add("@name_driver",model.NameDriver);
                    param.Add("@ro_mooc",model.RoMooc);
                    param.Add("@vehicle_number",model.VehicleNumber);
                    param.Add("@weight_allow",model.WeightAllow);
                    param.Add("@weight_registration",model.WeightRegistration);
                    param.Add("@code_product",model.CodeProduct);
                    param.Add("@quantity",model.Quantity);
                    param.Add("@shipping_unit",model.IdTransportationUnit);
                    param.Add("@class1",model.Class1);
                    param.Add("@class2",model.Class2);
                    param.Add("@code_type_packet", model.CodeTypePacket);
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
        public List<OrderInfo> GetOrderByCode(string codeOrder)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_order_by_code(@code)";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@code",codeOrder);
                   
                    var res = conn.Query<OrderInfo>(command,param).ToList();
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