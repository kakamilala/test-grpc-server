using Grpc.Core;
using GrpcServer;
using Microsoft.EntityFrameworkCore;

namespace GrpcServer.Services
{
    public class UserAPIService : UserService.UserServiceBase
    {
        bankContext db;
        public UserAPIService(bankContext db)
        {
            this.db = db;
        }

        public override async Task<UserReply> GetUser(GetUserRequest request, ServerCallContext context)
        {
            var users = await db.Users.ToListAsync();
            
            var accounts = new AccountListReply();
            foreach (var user in users)
            {
                if (user.Phone == request.Phone && user.Pass == request.Pass) {
                    UserReply userReply = new UserReply() { Id = user.Id, Fio = user.Fio, Pass = user.Pass, Phone = user.Phone};
                    var dbAccounts = await db.Accounts.Where(a => a.UserId == user.Id).ToListAsync();
                    foreach (var account in dbAccounts)
                    {
                          accounts.Accounts.Add(new AccountReply() {  Id = account.Id, Number = account.Number, Type = account.Type });
                    }
                    userReply.Accounts = accounts;
                    return userReply;
                }
                
            }
            return new UserReply();

        }
    }
}