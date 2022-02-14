namespace MineralInventory.Models
{
    public class TypeCard
    {
        public long id_card {get; set;}
        public string code_product {get; set;}
        public string code_parcel {get; set;}
        public string code_type_packet {get; set;}
        public long quantity {get;set;}
        public string code_ware_house {get; set;}
        public int  id_type_product {get; set;}
        public string  code_packing_unit {get; set;}
        public string  code_type_bill { get; set;}
        public int id_shift { get; set;}
        public string created_date { get; set; }
        public string code_order { get; set;}
        public string created_person { get; set; }

    }
}