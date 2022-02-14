using Grpc.Core;
using MineralInventory.Respository;
using System.Threading.Tasks;

namespace MineralInventory.Services
{
  public class ReportService : Report.ReportBase
  {
    private Response response = new Response();
    public override Task<CardDetailResponse> GetReportImportExport(MasterRequest request, ServerCallContext context)
    {
      var cardDetais = new ReportDAL().GetReportImportExport(request.FromDate.Trim(), request.ToDate.Trim(), request.UserName);
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
    public override Task<TransportResponse> GetReportTransport(MasterRequest request, ServerCallContext context)
    {
      var transport = new ReportDAL().GetReportTransport(request.FromDate.Trim(), request.ToDate.Trim(), request.UserName);
      if (transport == null)
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
        Data = { transport },
        Response = response
      });
    }
    public override Task<ReportInventoryResponse> GetReportInventory(MasterRequest request, ServerCallContext context)
    {
      var inventory = new ReportDAL().GetReportInventory(request.FromDate, request.ToDate);
      if (inventory == null)
      {
        response.State = ResponseState.Fail;
        response.Message = "Lỗi hệ thống";
        return Task.FromResult(new ReportInventoryResponse()
        {
          Response = response
        });
      }


      response.State = ResponseState.Success;
      response.Message = "";
      return Task.FromResult(new ReportInventoryResponse()
      {
        Data = { inventory },
        Response = response
      });
    }
    public override Task<OrderReply> GetReportOrder(MasterRequest request, ServerCallContext context)
    {
      var orders = new ReportDAL().GetReportOrder(request.FromDate, request.ToDate);
      if (orders == null)
      {
        response.State = ResponseState.Fail;
        response.Message = "Lỗi hệ thống";
        return Task.FromResult(new OrderReply()
        {
          Response = response
        });
      }


      response.State = ResponseState.Success;
      response.Message = "";
      return Task.FromResult(new OrderReply()
      {
        Orders = { orders },
        Response = response
      });
    }
    public override Task<CardDetailResponse> GetReportError(MasterRequest request, ServerCallContext context)
    {
      var cardDetais = new ReportDAL().GetReportError(request.FromDate.Trim(), request.ToDate.Trim(), request.UserName);
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
    public override Task<QRCodeResponse> GetReportQRCode(MasterRequest request, ServerCallContext context)
    {
      var qrCodes = new ReportDAL().GetReportQrCode(request.FromDate.Trim(), request.ToDate.Trim());
      if (qrCodes == null)
      {
        response.State = ResponseState.Fail;
        response.Message = "Lỗi hệ thống";
        return Task.FromResult(new QRCodeResponse()
        {
          Response = response
        });
      }


      response.State = ResponseState.Success;
      response.Message = "";
      return Task.FromResult(new QRCodeResponse()
      {
        Data = { qrCodes },
        Response = response
      });
    }
    public override Task<QRCodeResponse> GetQRCodeByTransportIn(MasterRequest request, ServerCallContext context)
    {
      var qrCodes = new ReportDAL().GetQRcodeByTransportIn(request.CodeTransportIn);
      if (qrCodes == null)
      {
        response.State = ResponseState.Fail;
        response.Message = "Lỗi hệ thống";
        return Task.FromResult(new QRCodeResponse()
        {
          Response = response
        });
      }


      response.State = ResponseState.Success;
      response.Message = "";
      return Task.FromResult(new QRCodeResponse()
      {
        Data = { qrCodes },
        Response = response
      });
    }
    public override Task<QRCodeResponse> GetQRCodeByTransportOut(MasterRequest request, ServerCallContext context)
    {
      var qrCodes = new ReportDAL().GetQRcodeByTransportOut(request.CodeTransportOut);
      if (qrCodes == null)
      {
        response.State = ResponseState.Fail;
        response.Message = "Lỗi hệ thống";
        return Task.FromResult(new QRCodeResponse()
        {
          Response = response
        });
      }


      response.State = ResponseState.Success;
      response.Message = "";
      return Task.FromResult(new QRCodeResponse()
      {
        Data = { qrCodes },
        Response = response
      });
    }
    public override Task<QRCodeResponse> GetQRCodeByOrder(MasterRequest request, ServerCallContext context)
    {
      var qrCodes = new ReportDAL().GetQRcodeByOrder(request.CodeOrder);
      if (qrCodes == null)
      {
        response.State = ResponseState.Fail;
        response.Message = "Lỗi hệ thống";
        return Task.FromResult(new QRCodeResponse()
        {
          Response = response
        });
      }


      response.State = ResponseState.Success;
      response.Message = "";
      return Task.FromResult(new QRCodeResponse()
      {
        Data = { qrCodes },
        Response = response
      });
    }

  }
}
