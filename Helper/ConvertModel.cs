using MineralInventory.Models;
using MineralInventory.ViewModels;
using MineralInventory;

namespace MineralInventory.Helper
{
    public static class ConvertModel
    { 
       
        public static TypeShiftDetail ConvertUpdateShiftDetail(ShiftDetailInfo model)
        {
            if(model ==  null)
                return null;
            
            return new TypeShiftDetail()
            {
                code_parcel = model.CodeParcel,
                code_product = model.CodeProduct,
                id_shift = model.IdShift,
                id_shift_detail = model.IdShiftDetail,
                code_type_bill = model.CodeTypeBill,
                code_type_packet = model.CodeTypePacket,
                id_type_product = model.IdTypeProduct,
                code_ware_house = model.CodeWareHouse,                
                option_name = model.OptionName,
                code_packing_unit = model.CodePackingUnit

            };
        }


        public static TypeCard ConvertTypeCard(CardDetailInfo model, string type)
        {
            if (model == null)
                return null;

            var typeNewCard = new TypeCard
            {
                
                code_product = model.CodeProduct.Trim(),
                code_type_packet = model.CodeTypePacket.Trim(),
                code_ware_house = model.CodeWareHouse.Trim(),
                id_shift = model.IdShift,
                id_card = model.IdCard,
                id_type_product = model.IdTypeProduct,
                quantity = model.Quantity,
                code_parcel = model.CodeParcel.Trim(),
                code_packing_unit = model.CodePackingUnit,
                code_order = model.CodeOrder.Trim(),
                code_type_bill = model.CodeTypeBill.Trim(),
                created_date = model.CreatedDate.Trim(),
                created_person = model.CreatedPerson,
               
                
            };

            switch (type)
            {
                case TypeBill.NDM:
                    typeNewCard.code_order = null;
                   
                    break;

                case TypeBill.NDL:
                    typeNewCard.code_order = null;
                    
                   
                    break;

                case TypeBill.XDL:
                    typeNewCard.code_order = null;
                   
                   
                    break;

                case TypeBill.XDC:
                    typeNewCard.code_order = null;
                  
                    break;

                default:
                  
                 
                    break;

            }

            return typeNewCard;
        }


        
        public static TypeConfirmProduct ConvertConfirmProduct(ConfirmProduction1000 model)
        {
            if (model == null)
                return null;

            return new TypeConfirmProduct()
            {
                code_equipment = model.CodeEquipment,
                id_shift_detail = model.IdShiftDetail,
                quantity = model.Quantity 
               


            };
        }


    }
}