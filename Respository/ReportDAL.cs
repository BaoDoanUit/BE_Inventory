using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MineralInventory.Respository
{
    public class ReportDAL :BaseDAL
    {
    


        public List<CardDetailInfo> GetReportImportExport(string fromDate, string toDate, string user)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_report_import_export_v2(@from_date, @to_date, @user)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@from_date", fromDate);
                    parameters.Add("@to_date", toDate);
                    parameters.Add("@user", user);
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
        public List<TransportInfo> GetReportTransport(string fromDate, string toDate, string user)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_report_transport(@from_date, @to_date, @user)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@from_date", fromDate);
                    parameters.Add("@to_date", toDate);
                    parameters.Add("@user", user);
                    var res = conn.Query<TransportInfo>(command, parameters).ToList();
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
        public List<ReportInventoryInfo> GetReportInventory(string fromDate , string toDate)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_report_list_inventoty(@from_date, @to_date)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@from_date", fromDate);
                    parameters.Add("@to_date", toDate);
                    var res = conn.Query<ReportInventoryInfo>(command,parameters).ToList();
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
        public List<OrderInfo> GetReportOrder(string fromDate , string toDate)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_report_order(@from_date, @to_date)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@from_date", fromDate);
                    parameters.Add("@to_date", toDate);
                    var res = conn.Query<OrderInfo>(command,parameters).ToList();
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
        public List<CardDetailInfo> GetReportError(string fromDate, string toDate, string user)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_report_error(@from_date, @to_date,@user)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@from_date", fromDate);
                    parameters.Add("@to_date", toDate);
                    parameters.Add("@user", user);
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
         public List<QRCodeInfo> GetReportQrCode(string fromDate, string toDate)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_report_qrcode(@from_date, @to_date)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@from_date", fromDate);
                    parameters.Add("@to_date", toDate);
                    var res = conn.Query<QRCodeInfo>(command, parameters).ToList();
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

        public List<TransportInfo> GetListTransportByShift(string date, string shift)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_transport_by_shift(@date, @shift)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@date", date);
                    parameters.Add("@shift", shift);
                    var res = conn.Query<TransportInfo>(command, parameters).ToList();
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
        public List<CardDetailInfo> GetListErrorByShift(string date, string shift)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_error_by_shift(@date, @shift)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@date", date);
                    parameters.Add("@shift", shift);
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
        public List<CardDetailInfo> GetListCardByShift(string date, string shift)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_list_card_by_shift(@date,@shift)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@date", date);
                    parameters.Add("@shift", shift);
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
        public List<QRCodeInfo> GetQRcodeByTransportIn(string code)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_qrcode_by_vanchuyen_in(@code)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@code", code);
                    var res = conn.Query<QRCodeInfo>(command, parameters).ToList();
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
        public List<QRCodeInfo> GetQRcodeByTransportOut(string code)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_qrcode_by_vanchuyen_out(@code)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@code", code);
                    var res = conn.Query<QRCodeInfo>(command, parameters).ToList();
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
        public List<QRCodeInfo> GetQRcodeByOrder(string code)
        {
            using (var conn = new NpgsqlConnection(GetConnection()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string command = "select * from get_qrcode_by_order(@code)";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@code", code);
                    var res = conn.Query<QRCodeInfo>(command, parameters).ToList();
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
