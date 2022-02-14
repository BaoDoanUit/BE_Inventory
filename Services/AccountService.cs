
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using MineralInventory.Auth;
using MineralInventory.Respository;
using MineralInventory;
using MineralInventory.Helper;
using MineralInventory.Models;

namespace MineralInventory.Services
{
    public class AccountService : Account.AccountBase
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IJWTAuthenticationManager _jwtAuhthentic;
        public AccountService(ILogger<AccountService> logger, IJWTAuthenticationManager jwtAuthentic)
        {
            _logger = logger;
            _jwtAuhthentic = jwtAuthentic;
        }
        public Response response = new Response();
        public override Task<UserReply> SignIn(UserInfo request, ServerCallContext context)
        {
            var listUser = new UserDAL().GetListUser();
            if (listUser == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(new UserReply()
                {
                    Response = response
                });
            }

            var user = listUser.Where(x => x.User == request.User.Trim() 
                                && SecurityHelper.Encrypt(request.Password) == x.Password).FirstOrDefault();
            
            if(user == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Tên đăng nhập hoặc mật khẩu không đúng! Vui lòng kiểm tra lại";
                return Task.FromResult(new UserReply{
                    Response = response
                });
            }

            user.Password = "";
            response.Message = "Authenticate Success";
            response.State = ResponseState.Success;
            return Task.FromResult(new UserReply(){
                Response = response,
                User = user,
                Token =  _jwtAuhthentic.Authenticate(user.User, request.Password)
            });
        }
        public override Task<Response> InsertUser(UserInfo request, ServerCallContext context)
        {
            var listUser = new UserDAL().GetListAllUser();
            if (listUser == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            if (listUser.Exists(x => x.User.Trim() == request.User.Trim()))
            {
                response.State = ResponseState.Fail;
                response.Message = "Username đã tồn tại";
                return Task.FromResult(response);
            }
            request.Password = request.Password.Trim();
            request.Password = SecurityHelper.Encrypt(request.Password);
            
            if (new UserDAL().InsertUser(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }else
            {
                response.State = ResponseState.Fail;
            response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> UpdateUser(UserInfo request, ServerCallContext context)
        {
            var listUser = new UserDAL().GetListUser();
            if (listUser == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            if (!listUser.Exists(x => x.ID == request.ID))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }
          
            if(new UserDAL().UpdateUser(request))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        public override Task<Response> DeleteUser(UserInfo request, ServerCallContext context)
        {
            var users = new UserDAL().GetListUser();
            if (users == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            if (!users.Exists(x => x.ID == request.ID))
            {
                response.State = ResponseState.Fail;
                response.Message = "Không tồn tại";
                return Task.FromResult(response);
            }
            

            if(new UserDAL().DeleteUser(request.ID))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        
        public override Task<Response> ChangePassword(UserInfo request, ServerCallContext context)
        {
            var listUser = new UserDAL().GetListUser();
            if (listUser == null)
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
                return Task.FromResult(response);
            }
            var users = listUser.Where(x => x.User == request.User.Trim());
            if(users.Count() == 0)
            {
                response.Message = "Tên đăng nhập không tồn tại";
                response.State = ResponseState.Fail;
                return Task.FromResult(response);
            }

            var user = users.Where(x => x.Password ==  SecurityHelper.Encrypt(request.Password)).FirstOrDefault();
            if(user == null)
            {
                response.Message = "Mật khẩu không đúng";
                response.State = ResponseState.Fail;
                return Task.FromResult(response);
            }

            if(new UserDAL().UpdateUserPassword(user.ID,SecurityHelper.Encrypt(request.NewPassword)))
            {
                response.State = ResponseState.Success;
                response.Message = "Thành công";
            }else
            {
                response.State = ResponseState.Fail;
                response.Message = "Lỗi hệ thống";
            }
            return Task.FromResult(response);
        }
        
       
    }
}