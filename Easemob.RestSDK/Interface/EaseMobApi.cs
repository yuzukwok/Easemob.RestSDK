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
        Task<EaseApiResult> RegisterIMUsers(IList<UserReg> input);

        Task<EaseApiResult> RegisterIMUser(UserReg input);

        Task<EaseApiResult> ChangeIMUserNickname(string username, ChangeIMUserNicknameInput input);

        Task<CreateChatRoomOutput> CreateChatRoom(CreateChatRoomInput input);
    }
}
