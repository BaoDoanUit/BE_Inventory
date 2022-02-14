using System.Threading.Tasks;
using Grpc.Core;
using System.Linq;
using MineralInventory.Helper;
using MineralInventory.Respository;
using MineralInventory.Models;
using System;

namespace MineralInventory.Services
{
    public class RecordConfirmService : RecordConfirm.RecordConfirmBase
    {
        private Response response = new Response();
        public override Task<ProductResponse> GetListProduct(MasterRequest request, ServerCallContext context)
        {
            var products = new ProductDAL().GetListProduct();
            if (products == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new ProductResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new ProductResponse()
            {
                Data = { products },
                Response = response
            });
        }
        public override Task<TypeProductResponse> GetListTypeProduct(MasterRequest request, ServerCallContext context)
        {
            var typeProducts = new TypeProductDAL().GetListTypeProduct();
            if (typeProducts == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new TypeProductResponse()
                {
                    Response = response
                });
            }
            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new TypeProductResponse()
            {
                Data = { typeProducts },
                Response = response
            });
        }
        public override Task<TypePacketResponse> GetListTypePacket(MasterRequest request, ServerCallContext context)
        {
            var typePackets = new TypePacketDAL().GetListTypePacket();
            if (typePackets == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new TypePacketResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new TypePacketResponse()
            {
                Data = { typePackets },
                Response = response
            });
        }
         public override Task<RecordObjectResponse> GetListRecordObject(MasterRequest request, ServerCallContext context)
        {
            var listPeople = new RecordObjectDAL().GetListObejct();
            if (listPeople == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult<RecordObjectResponse>(new RecordObjectResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult<RecordObjectResponse>(new RecordObjectResponse()
            {
                Data = { listPeople },
                Response = response
            });
        }
        public override Task<CardDetailResponse> GetListCard(MasterRequest request, ServerCallContext context)
        {
            var cardDetais = new ReportDAL().GetListCardByShift(request.Date.Trim(),request.NameShift.Trim().ToUpper());
            if (cardDetais == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new CardDetailResponse()
                {
                    Response = response
                });
            }


            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new CardDetailResponse()
            {
                Data = { cardDetais },
                Response = response
            });
        }
        public override Task<CardDetailResponse> GetListError(MasterRequest request, ServerCallContext context)
        {
           var cardDetais = new ReportDAL().GetListErrorByShift(request.Date.Trim(),request.NameShift.Trim().ToUpper());
            if (cardDetais == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new CardDetailResponse()
                {
                    Response = response
                });
            }


            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new CardDetailResponse()
            {
                Data = { cardDetais },
                Response = response
            });
        }
        public override Task<TransportResponse> GetListTransport(MasterRequest request, ServerCallContext context)
        {
            var transports = new ReportDAL().GetListTransportByShift(request.Date.Trim(),request.NameShift.Trim().ToUpper());
            if (transports == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new TransportResponse()
                {
                    Response = response
                });
            }


            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new TransportResponse()
            {
                Data = { transports },
                Response = response
            });
        }
        public override Task<MasterDataResponse> GetListMaster(MasterDataInfo request, ServerCallContext context)
        {
            var masters = new MasterDAL().GetListMaster().Where(x => x.IsDeleted == false);
            if (masters == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult<MasterDataResponse>(new MasterDataResponse()
                {
                    Response = response
                });
            }

            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult<MasterDataResponse>(new MasterDataResponse()
            {
                Data = { masters },
                Response = response
            });
        }

    }
}