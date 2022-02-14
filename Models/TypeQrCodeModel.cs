using System;

namespace MineralInventory.Models
{
    public class TypeQrCodeModel
    {
        public long id { get; set; }
        public string code { get; set; }
        public int loai_sp { get; set; }
        public string sp   { get; set; }
        public string loai_bao { get; set; }
        public string kho { get; set; }
        public string lo { get; set; }
        public string dv_dong { get; set;}
        public string khoiluong { get; set; }
        public string timein { get; set; }
        public int trangthai { get; set; }
        public string donhang { get; set; }
        public string timeout { get; set; }
        public string codein { get; set; }
        public string codeout { get; set; }
        public int index { get; set; }
        public int line { get; set; }
        public string error { get; set; }
        public string user { get; set; }
        public string userreport { get; set; }
        public string timereport { get; set; }
        public string userout { get; set; }
        public string userin { get; set; }
        public string vanchuyenin { get; set; }
        public string vanchuyenout { get; set; }


    }
}
