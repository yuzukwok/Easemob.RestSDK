using Easemob.RestSDK.Dto.Input;
using Easemob.RestSDK.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easemob.RestSDK.Interface
{
    public interface IEaseMobApi
    {
        Task<RegisterIMUsersOutput> RegisterIMUsers(IList<UserReg> input);

        Task<RegisterIMUsersOutput> RegisterIMUser(UserReg input);

        Task<CreateChatRoomOutput> CreateChatRoom(CreateChatRoomInput input);
    }
}
