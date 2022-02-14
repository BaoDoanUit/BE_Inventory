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
    public class UpdateInventory : IScheduledTask
    {
        private readonly ILogger<UpdateInventory> _logger;
        public UpdateInventory(ILogger<UpdateInventory> logger)
        {
            _logger = logger;
        }
        public bool IsShuttingDown { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Task RunAsync()
        {
            try
            {
                _logger.LogInformation("Update Inventory");
                DateTime now = DateTime.UtcNow.AddHours(7).AddDays(-1);
                string reportDate = now.ToString("yyyy-MM-dd");
                SentryClient.CaptureMessage("Insert Inventory", reportDate, "info");
                new WareHouseDAL().UpdateInventory(reportDate);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                SentryClient.CaptureMessage("Update Inventory", ex, "error");
                throw ex;

            }
        }
    }
}
