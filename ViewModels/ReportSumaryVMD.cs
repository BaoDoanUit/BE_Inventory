namespace MineralInventory.ViewModels
{
    public class ReportSummaryVMD
    {
        public int id_warehouse {get; set;}
        public string date_check {get; set;}
        public long cnt_all_ord {get; set;}
        public long cnt_new_ord {get; set;}
        public long cnt_completed_ord {get; set;} 
        public long cnt_canceled_ord {get;set;}
        public string   ware_house_code{get; set;}
        public string ware_house_name{get; set;}
    }
}