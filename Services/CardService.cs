using System.Threading.Tasks;
using Grpc.Core;
using System.Linq;
using MineralInventory.Helper;
using MineralInventory.Respository;
using MineralInventory.Models;
using System;

namespace MineralInventory.Services
{
    public class CardService : Card.CardBase
    {
        private Response response = new Response();
        //public override Task<CardResponse> GetListCard(MasterRequest request, ServerCallContext context)
        //{
        //    var listCard = new CardDAL().GetListCard(request.FromDate.Trim(), request.ToDate.Trim())
        //    .Select(x => ConvertModel.ConvertCard(x));
        //    response.State = ResponseState.Success;
        //    response.Message  = "";
        //    return Task.FromResult( new CardResponse(){
        //        Data = {listCard},
        //        Response = response
        //    });

        //}
        //public override Task<Response> InsertCard(InsertCardRequest request, ServerCallContext context)
        //{
        //    var cardDetails = request.CardDetails.
        //        Select(x => ConvertModel.ConvertTypeCard(x, request.Card.CodeTypeBill.Trim())).ToList();

        //    var res = new CardDAL().InsertCard(cardDetails, card);

        //    if (res)
        //    {
        //        response.State = ResponseState.Success;
        //        response.Message = "Thành công";
        //    }
        //    else
        //    {
        //        response.State = ResponseState.Fail;
        //        response.Message = "Lỗi hệ thống";
        //    }
        //    return Task.FromResult(response);



        //}
        //public override Task<Response> UpdateCard50kg(InsertCardRequest request, ServerCallContext context)
        //{
        //    var card = new CardDAL().GetCardByCode(request.Card.CodeCard.Trim());
        //    if (card == null)
        //    {
        //        response.State = ResponseState.Fail;
        //        response.Message = "Không tồn tại";
        //        return Task.FromResult(response);
        //    }

        //    if (!card.is_changable)
        //    {
        //        response.State = ResponseState.Fail;
        //        response.Message = "Không thể thay đổi";
        //        return Task.FromResult(response);
        //    }

        //    var cardDetails = request.CardDetails.
        //    Select(x => ConvertModel.ConvertTypeCardDetail(x, card.code_type_bill)).ToList();

        //    var res = new CardDAL().UpdateCard(cardDetails, request.Card.CodeCard.Trim());

        //    if (res)
        //    {
        //        response.State = ResponseState.Success;
        //        response.Message = "Thành công";
        //    }
        //    else
        //    {
        //        response.State = ResponseState.Fail;
        //        response.Message = "Lỗi hệ thống";
        //    }
        //    return Task.FromResult(response);
        //}
        //public override Task<CardDetailResponse> getListCardDetailByCode(MasterRequest request, ServerCallContext context)
        //{
        //    var cardDetais = new CardDetailDAL().GetListCardDetailByCode(request.CodeCard.Trim())
        //        .Select(x => ConvertModel.ConvertCardDetail(x));
        //    response.State = ResponseState.Success;
        //    response.Message = "";
        //    return Task.FromResult(new CardDetailResponse()
        //    {
        //        Data = { cardDetais },
        //        Response = response
        //    });
        //}

        //public override Task<Response> SetChangeableCard(CardDetailInfo request, ServerCallContext context)
        //{
        //    var card = new CardDAL().GetCardByCode(request.CodeCard.Trim());
        //    if (card == null)
        //    {
        //        response.State = ResponseState.Fail;
        //        response.Message = "Không tồn tại";
        //        return Task.FromResult(response);
        //    }

        //    var res = new CardDAL().SetChangableCard(request.CodeCard.Trim(), request.IsChangable);

        //    if (res)
        //    {
        //        response.State = ResponseState.Success;
        //        response.Message = "Thành công";
        //    }
        //    else
        //    {
        //        response.State = ResponseState.Fail;
        //        response.Message = "Lỗi hệ thống";
        //    }
        //    return Task.FromResult(response);
        //}
        public override Task<CardDetailResponse> GetListCar50kg(MasterRequest request, ServerCallContext context)
        {
            var cardDetais = new CardDAL().GetListCardByWeight(request.FromDate.Trim(), request.ToDate.Trim(),50);
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
        public override Task<CardDetailResponse> GetListCard50kgByShift(MasterRequest request, ServerCallContext context)
        {
            var cardDetais = new CardDAL().GetListCard50kgByShift(request.Date.Trim(), request.NameShift.Trim().ToUpper());
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
        public override Task<CardDetailResponse> GetListCard1000kg(MasterRequest request, ServerCallContext context)
        {
            var cardDetais = new CardDAL().GetListCardByWeight(request.FromDate.Trim(), request.ToDate.Trim(),1000);
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
        public override Task<CardDetailResponse> GetListCard(MasterRequest request, ServerCallContext context)
        {
            var cardDetais = new CardDAL().GetListCard(request.FromDate.Trim(), request.ToDate.Trim());
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
        public override Task<Response> UpdateCard50kg(InsertCardRequest request, ServerCallContext context)
        {
            request.NameShift = request.NameShift.Trim().ToUpper();
            if (!Utils.CheckShift(request.NameShift))
            {
                response.State = ResponseState.Fail;
                response.Message = "Tên ca không hợp lệ";
                return Task.FromResult(response);
            }
            var cardDetails = request.CardDetails.
            Select(x => ConvertModel.ConvertTypeCard(x, request.CardDetails.FirstOrDefault().CodeTypeBill.Trim())).ToList();

            var res = new CardDAL().UpdateCard50kg(cardDetails,request.Date,request.NameShift,request.User.Trim(),
                request.CodeTypeBill.Trim(),request.CodePackingUnit.Trim());

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
       
        public override Task<Response> DeleteCard(CardDetailInfo request, ServerCallContext context)
        {
           var cards = new CardDAL().GetCardById(request.IdCard);
           if (cards == null)
           {
               response.State = ResponseState.Fail;
               response.Message = "lỗi hệ thống";
               return Task.FromResult(response);
           }

           if (cards.Where(x => x.IdCard == request.IdCard).FirstOrDefault() == null)
           {
               response.State = ResponseState.Fail;
               response.Message = "Không tồn tại";
               return Task.FromResult(response);
           }


           var res = new CardDAL().DeleteCard(request.IdCard,request.CreatedPerson);

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
        public override Task<Response> UpdateOneCard50kg(CardDetailInfo request, ServerCallContext context)
        {
           var cards = new CardDAL().GetCardById(request.IdCard);
           if (cards == null)
           {
               response.State = ResponseState.Fail;
               response.Message = "lỗi hệ thống";
               return Task.FromResult(response);
           }

           if (cards.Where(x => x.IdCard == request.IdCard).FirstOrDefault() == null)
           {
               response.State = ResponseState.Fail;
               response.Message = "Không tồn tại";
               return Task.FromResult(response);
           }

           var res = new CardDAL().UpdateOneCard50kg(request);

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
        public override Task<OrderResponse> InsertOrder(OrderInfo request, ServerCallContext context)
        {
            Console.WriteLine("Insert Order");
            Console.WriteLine(request);
            if (string.IsNullOrWhiteSpace(request.CodeProduct) ||
                string.IsNullOrWhiteSpace(request.CodeTypePacket) ||
                string.IsNullOrWhiteSpace(request.NameDriver) ||
                string.IsNullOrWhiteSpace(request.VehicleNumber) ||
                string.IsNullOrWhiteSpace(request.RoMooc) ||
                string.IsNullOrWhiteSpace(request.WareHouse) ||
                string.IsNullOrWhiteSpace(request.Customer) ||
                string.IsNullOrWhiteSpace(request.TypeCustomer) ||
                string.IsNullOrWhiteSpace(request.IdentityDriver)
                )
            {
                response.Message = "Thiếu thông tin";
                response.State = ResponseState.Fail;
                return Task.FromResult<OrderResponse>(new OrderResponse
                {
                    Response = response
                });
            }

            var res = new OrderDAL().InsertOrder(request);
            Console.WriteLine("Insert Order------");

            if (res != null)
            {
                request.CodeOrder = res;
                response.Message = "Thành công";
                response.State = ResponseState.Success;
                return Task.FromResult<OrderResponse>(new OrderResponse
                {
                    Order = request,
                    Response = response
                });


            }
            else
            {
                response.Message = "Lỗi hệ thống";
                response.State = ResponseState.Fail;
                return Task.FromResult<OrderResponse>(new OrderResponse
                {
                    Response = response
                });
            }

        }

        public override Task<Response> UpdateOrder(OrderInfo request, ServerCallContext context)
        {
            var res = new OrderDAL().UpdateOrder(request);
            if (res)
            {
                response.Message = "Thành công";
                response.State = ResponseState.Success;
            }
            else
            {
                response.Message = "Lỗi hệ thống";
                response.State = ResponseState.Fail;
            }
            return Task.FromResult<Response>(response);
        }
        public override Task<OrderResponse> GetOrderByCode(OrderInfo request, ServerCallContext context)
        {
            var orders = new OrderDAL().GetOrderByCode(request.CodeOrder.Trim());
            if (orders == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new OrderResponse()
                {
                    Response = response
                });
            }
            var order = orders.FirstOrDefault();
            if (orders == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(new OrderResponse()
                {
                    Response = response
                });
            }


            response.State = ResponseState.Success;
            response.Message = "";
            return Task.FromResult(new OrderResponse()
            {
                Order = order,
                Response = response
            });
        }
        public override Task<Response> InsertCard50kg(InsertCardRequest request, ServerCallContext context)
        {
            request.NameShift = request.NameShift.Trim().ToUpper();
            if (!Utils.CheckShift(request.NameShift))
            {
                response.State = ResponseState.Fail;
                response.Message = "Tên ca không hợp lệ";
                return Task.FromResult(response);
            }
            var cards = new CardDAL().GetListCard50kgByShift(request.Date, request.NameShift.Trim().ToUpper())
                .Where(x => x.CodePackingUnit == request.CodePackingUnit.Trim() && x.CodeTypeBill == request.CodeTypeBill.Trim()).ToList();
            if(cards.Count > 0)
            {
                response.State = ResponseState.Fail;
                response.Message = "Đã xác nhân trước đó";
                return Task.FromResult(response);
            }
            var cardDetails = request.CardDetails.
            Select(x => ConvertModel.ConvertTypeCard(x, request.CardDetails.FirstOrDefault().CodeTypeBill.Trim())).ToList();

            var res = new CardDAL().InsertCard50kg(cardDetails, request.Date, request.NameShift, request.User.Trim(),
                request.CodeTypeBill.Trim(),request.CodePackingUnit.Trim());

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
    }
}