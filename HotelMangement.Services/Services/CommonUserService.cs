using HotelManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMangement.Services.Services
{
    public interface ICommonUserService
    {
        dynamic ValidateUser(string email, string password);
    }
    public class CommonUserService : ICommonUserService
    {
        private readonly ICommonUserRepository _commonUserRepo;
        public CommonUserService(ICommonUserRepository commonUserRepository)
        {
            _commonUserRepo = commonUserRepository;
        }
        public dynamic ValidateUser(string email, string password)
        {
            return _commonUserRepo.ValidateUser(email,password);
        }
    }
}
