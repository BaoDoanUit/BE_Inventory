using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MineralInventory.Helper;
using MineralInventory.Models;
using MineralInventory.Respository;

namespace MineralInventory.Services
{
    public class WareHouseService : WareHouse.WareHouseBase
    {
        Response response = new Response();
        public override Task<ShiftResponse> GetListShiftByDate(MasterRequest request, ServerCallContext context)
        {
            var shifts = new ShiftDAL().GetListShiftByDate(request.Date);
            if (shifts == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new ShiftResponse()
                {
                    Response = response
                });
            }
            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new ShiftResponse()
            {
                Data = { shifts },
                Response = response
            });
        }


        public override Task<Response> DeleteShift(ShiftInfo request, ServerCallContext context)
        {
            var shifts = new ShiftDAL().GetShiftById(request.IdShift);
            if (shifts == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }

            if (new ShiftDAL().DeleteShift(request.IdShift))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        public override Task<ShiftDetailResponse> GetListShiftDetail(MasterRequest request, ServerCallContext context)
        {
            var shiftDetails = new ShiftDetailDAL().GetListShiftDetail(request.FromDate.Trim(), request.ToDate.Trim());
            if (shiftDetails == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new ShiftDetailResponse()
                {
                    Response = response
                });
            }
            response.Message = "";
            return Task.FromResult(new ShiftDetailResponse()
            {
                Data = { shiftDetails },
                Response = response
            });
        }

        public override Task<Response> NewInsertShift(InsertShiftRequest request, ServerCallContext context)
        {
            request.NameShift = request.NameShift.Trim().ToUpper();
            if (!Utils.CheckShift(request.NameShift))
            {
                response.State = ResponseState.Fail;
                response.Message = "Tên ca không hợp lệ";
                return Task.FromResult(response);
            }


            // check name  option
            foreach (var shiftDetail in request.Data)
            {
                shiftDetail.OptionName = shiftDetail.OptionName.Trim().ToUpper();
            }
            if (request.Data.ToList().Exists(x => request.Data.Where(y => y.OptionName == x.OptionName).Count() > 1))
            {
                response.State = ResponseState.Fail;
                response.Message = "Tên option bị trùng, vui lòng kiểm tra lại ";
                return Task.FromResult(response);
            }
            var shifts = new ShiftDAL().GetListShiftByDate(request.Date.Trim());
            if (shifts == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            bool exist = shifts.Exists(x => x.Date == request.Date.Trim() && request.NameShift == x.NameShift.Trim());
            if (exist)
            {
                response.State = ResponseState.Fail;
                response.Message = "Ca làm việc đã được khởi tạo";
                return Task.FromResult(response);
            }

            foreach (var shiftDetail in request.Data)
            {
                shiftDetail.OptionName = shiftDetail.OptionName.Trim();

            }

            var shiftDetails = request.Data.Select(x => ConvertModel.ConvertUpdateShiftDetail(x)).ToList();
            if (new ShiftDAL().NewInsertShift(shiftDetails, request.NameShift, request.Date.Trim(), request.CreatedPerson))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<ParcelResponse> GetListAllParcel(MasterRequest request, ServerCallContext context)
        {
            var parcels = new ParcelDAL().GetListAllParcel();
            if (parcels == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new ParcelResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new ParcelResponse()
            {
                Data = { parcels },
                Response = response
            });
        }
        public override Task<ParcelResponse> GetListParcel(MasterRequest request, ServerCallContext context)
        {
            var parcels = new ParcelDAL().GetListParcel(request.FromDate.Trim(), request.ToDate.Trim());
            if (parcels == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new ParcelResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new ParcelResponse()
            {
                Data = { parcels },
                Response = response
            });
        }


        public override Task<Response> NewUpdateShift(InsertShiftRequest request, ServerCallContext context)
        {

            var shifts = new ShiftDAL().GetShiftById(request.IdShift);
            if (shifts == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Ca làm việc không tồn tại";
                return Task.FromResult(response);
            }
            // check name  option
            if (request.Data.ToList().Exists(x => request.Data.Where(y => y.OptionName == x.OptionName).Count() > 1))
            {
                response.State = ResponseState.Fail;
                response.Message = "Tên option bị trùng, vui lòng kiểm tra lại";
                return Task.FromResult(response);
            }

            foreach (var shiftDetail in request.Data)
            {
                shiftDetail.OptionName = shiftDetail.OptionName.Trim();
            }

            var shiftDetails = request.Data.Select(x => ConvertModel.ConvertUpdateShiftDetail(x)).ToList();
            if (new ShiftDAL().NewUpdateInsertShift(shiftDetails, request.IdShift))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);


        }
        public override Task<Response> InsertParcel(InsertParcelRequest request, ServerCallContext context)
        {
            if (string.IsNullOrWhiteSpace(request.CodeParcel))
            {
                response.State = ResponseState.Fail;
                response.Message = "Số lô hàng không được để trống";
                return Task.FromResult(response);
            }
            var parcels = new ParcelDAL().GetParcelByCode(request.CodeParcel.Trim());
            if (parcels == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            var parcel = parcels.FirstOrDefault();
            if (parcel != null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Số lô đã tồn tại";
                return Task.FromResult(response);
            }


            var listParcelDetail = request.Data.Select(x => new TypeParcelDetail()
            {
                code_parcel = x.CodeParcel,
                id_parcel_detail = x.IdParcelDetail,
                code_product = x.CodeProduct,
                code_type_packet = x.CodeTypePacket,
                id_type_product = x.IdTypeProduct
            }).ToList();

            if (new ParcelDAL().InsertParcel(request.CodeParcel.Trim(), request.CreatedPerson, listParcelDetail))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> UpdateParcel(InsertParcelRequest request, ServerCallContext context)
        {
            var parcels = new ParcelDAL().GetParcelByCode(request.CodeParcel.Trim());
            if (parcels == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }

            var parcel = parcels.FirstOrDefault();
            if (parcel == null || parcel.IsDeleted == true)
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }


            var listParcelDetail = request.Data.Select(x => new TypeParcelDetail()
            {
                code_parcel = request.CodeParcel,
                id_parcel_detail = x.IdParcelDetail,
                code_product = x.CodeProduct,
                code_type_packet = x.CodeTypePacket,
                id_type_product = x.IdTypeProduct
            }).ToList();

            if (new ParcelDAL().UpdateParcel(request.CodeParcel, listParcelDetail))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<ParcelDetailResponse> GetListParcelDetail(MasterRequest request, ServerCallContext context)
        {
            var listParcelDetail = new ParceDetailDAL().GetListParcelDetail(request.FromDate.Trim(), request.ToDate.Trim());
            if (listParcelDetail == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new ParcelDetailResponse()
                {
                    Response = response
                });
            }


            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new ParcelDetailResponse()
            {
                Data = { listParcelDetail },
                Response = response
            });
        }
        public override Task<ParcelDetailResponse> GetListParcelDetailByCode(MasterRequest request, ServerCallContext context)
        {
            var listParcelDetail = new ParceDetailDAL().GetListParcelDetailByCode(request.CodeParcel.Trim());
            if (listParcelDetail == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new ParcelDetailResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new ParcelDetailResponse()
            {
                Data = { listParcelDetail },
                Response = response
            });
        }


        public override Task<Response> DeleteParcel(ParcelInfo request, ServerCallContext context)
        {
            var parcels = new ParcelDAL().GetParcelByCode(request.CodeParcel.Trim());
            if (parcels == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            var parcel = parcels.FirstOrDefault();
            if (parcel == null || parcel.IsDeleted == true)
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }


            var res = new ParcelDAL().DeleteParcel(request.CodeParcel.Trim());
            if (res)
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        public override Task<Response> UpdateConfirmProduct(ConfirmProduction1000Info request, ServerCallContext context)
        {
            request.NameShift = request.NameShift.Trim().ToUpper();
            if (!Utils.CheckShift(request.NameShift))
            {
                response.State = ResponseState.Fail;
                response.Message = "Tên ca không hợp lệ";
                return Task.FromResult(response);
            }

            var listTypeConfirmProduct = request.Data.Select(x => ConvertModel.ConvertConfirmProduct(x)).ToList();
            var res = new ConfirmProductDAL().UpDateConfirmProduct(listTypeConfirmProduct, request.User,request.Date.Trim(),request.NameShift.Trim().ToUpper());
            if (res)
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }

        public override Task<ConfirmProductionResponse> GetConfirmProduct(MasterRequest request, ServerCallContext context)
        {
            var confirms = new ConfirmProductDAL().GetListConfirmProduct(request.FromDate.Trim(), request.ToDate.Trim());
            if (confirms == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new ConfirmProductionResponse()
                {
                    Response = response
                });
            }
            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new ConfirmProductionResponse()
            {
                Data = { confirms },
                Response = response
            });
        }

        public override Task<Response> InsertConfirmProduct(ConfirmProduction1000Info request, ServerCallContext context)
        {
            request.NameShift = request.NameShift.Trim().ToUpper();
            if (!Utils.CheckShift(request.NameShift))
            {
                response.State = ResponseState.Fail;
                response.Message = "Tên ca không hợp lệ";
                return Task.FromResult(response);
            }

            var confirms = new ConfirmProductDAL().GetListConfirmProductByShift(request.Date, request.NameShift.Trim().ToUpper());
            if (confirms.Count > 0)
            {
                response.State = ResponseState.Fail;
                response.Message = "Thông tin đã được xác nhận trước đó";
                return Task.FromResult(response);

            }

            var listTypeConfirmProduct = request.Data.Select(x => ConvertModel.ConvertConfirmProduct(x)).ToList();
            var res = new ConfirmProductDAL().UpDateConfirmProduct(listTypeConfirmProduct, request.User, request.Date.Trim(), request.NameShift.Trim().ToUpper());
            if (res)
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }
            else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<ConfirmProductionResponse> GetConfirmProductByShift(MasterRequest request, ServerCallContext context)
        {
            var confirms = new ConfirmProductDAL().GetListConfirmProductByShift(request.Date, request.NameShift.Trim().ToUpper());
            if (confirms == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new ConfirmProductionResponse()
                {
                    Response = response
                });
            }
            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new ConfirmProductionResponse()
            {
                Data = { confirms },
                Response = response
            });
        }
        public override Task<ConfirmProductionResponse> GetConfirmProductDisplayByShift(MasterRequest request, ServerCallContext context)
        {
            var confirms = new ConfirmProductDAL().GetListConfirmProductDisplayByShift(request.Date.Trim(), request.NameShift.Trim());
            if (confirms == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new ConfirmProductionResponse()
                {
                    Response = response
                });
            }
            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new ConfirmProductionResponse()
            {
                Data = { confirms },
                Response = response
            });


        }
    }
}