using DNTCommon.Web.Core;
using Microsoft.Extensions.Logging;
using MineralInventory.Helper;
using MineralInventory.Respository;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace MineralInventory.Schedule
{
    public class UpdateCardTask : IScheduledTask
    {
        private readonly ILogger<UpdateCardTask> _logger;
        public UpdateCardTask(ILogger<UpdateCardTask> logger)
        {
            _logger = logger;
        }
        public bool IsShuttingDown { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Task RunAsync()
        {
            try
            {
                _logger.LogInformation("Update card NDM");
                var dateShift = DateTime.UtcNow.AddHours(7);
                var dateShiftNew = DateTime.UtcNow.AddHours(7);
                var start = dateShift;
                var end = dateShift;
                string nameShift = "";
                string nameShiftNew = "";
                switch (dateShift.Hour)
                {
                    case 6:
                        {
                            dateShift = dateShift.AddDays(-1);
                            start = new DateTime(dateShift.Year, dateShift.Month, dateShift.Day, 22, 0, 0).AddDays(-1);
                            end = new DateTime(dateShift.Year, dateShift.Month, dateShift.Day, 6, 0, 0).AddTicks(-1);
                            nameShift = "CA 3";
                            nameShiftNew = "CA 1";
                            break;
                        }
                    case 14:
                        {
                            start = new DateTime(dateShift.Year, dateShift.Month, dateShift.Day, 6, 0, 0);
                            end = new DateTime(dateShift.Year, dateShift.Month, dateShift.Day, 14, 0, 0).AddTicks(-1);
                            nameShift = "CA 1";
                            nameShiftNew = "CA 2";
                            break;
                        }
                    case 22:
                        {
                            start = new DateTime(dateShift.Year, dateShift.Month, dateShift.Day, 14, 0, 0);
                            end = new DateTime(dateShift.Year, dateShift.Month, dateShift.Day, 22, 0, 0).AddTicks(-1);
                            nameShift = "CA 2";
                            nameShiftNew = "CA 3";
                            break;
                        }
                }
                //vn time

                // add shift if shift not exits  user create is null 
                new ShiftDAL().InsertShift(dateShiftNew.ToString("yyyy-MM-dd"),nameShiftNew);


                // log data
                var data = new QrCodeDAL().GetListQrCodeByShift(dateShift.ToString("yyyy-MM-dd"),nameShift);
                var json = JsonConvert.SerializeObject(data);
                string title = String.Format("qrcode in shift date: {0} shift : {1} ", dateShift.ToString("yyyy-MM-dd"), nameShift);
                SentryClient.CaptureMessage(title,json, "info");



                var res = new CardDAL().InsertCard(data, dateShift.ToString("yyyy-MM-dd"), nameShift);
                    
                _logger.LogInformation(res.ToString());
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                SentryClient.CaptureMessage("UpdateCardTask", ex, "error");
                throw ex;

            }
        }
    }
}
