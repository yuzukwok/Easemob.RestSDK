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
        /// <summary>
        /// 批量创建用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EaseApiResult> CreateUserBatch(IList<UserReg> input);
        /// <summary>
        /// 创建单个用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        Task<EaseApiResult> CreateUser(UserReg input);
        

        /// <summary>
        /// 获取IM用户
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<EaseApiResult> GetUser(string username);
        /// <summary>
        /// 批量获取用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="limit"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        Task<EaseApiResult> GetUserList(string username,string cursor,int limit=10);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<EaseApiResult> DelUser(string username);
        /// <summary>
        /// 批量删除用户（具体删除哪些用户无法指定）
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<EaseApiResult> DelUserBatch(int limit);

        /// <summary>
        /// 修改用户昵称
        /// </summary>
        /// <param name="username"></param>
        /// <param name="input"></param>
        /// <returns></returns>

        Task<EaseApiResult> ChangeUserNickname(string username, ChangeIMUserNicknameInput input);
        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EaseApiResult> ChangeUserPassword(string username, ChangeUserPasswordInput input);

        /// <summary>
        /// 给用户添加一个好友
        /// </summary>
        /// <param name="ownerusername"></param>
        /// <param name="friendusername"></param>
        /// <returns></returns>
        Task<EaseApiResult> AddBuddy(string ownerusername, string friendusername);
        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="ownerusername"></param>
        /// <param name="friendusername"></param>
        /// <returns></returns>
        Task<EaseApiResult> DelBuddy(string ownerusername, string friendusername);
        /// <summary>
        /// 获取用户的好友信息
        /// </summary>
        /// <param name="ownerusename"></param>
        /// <returns></returns>
        Task<EaseApiResultData> GetBuddys(string ownerusename);
        /// <summary>
        /// 获取用户的黑名单
        /// </summary>
        /// <param name="ownerusename"></param>
        /// <returns></returns>
        Task<EaseApiResultData> GetBuddyInBlackList(string ownerusename);
        /// <summary>
        /// 加入用户的黑名单
        /// </summary>
        /// <param name="ownerusername"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EaseApiResultData> AddBuddyInBlackList(string ownerusername,AddBuddyInBlackListInput input);
        /// <summary>
        /// 移除用户的黑名单
        /// </summary>
        /// <param name="ownerusername"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EaseApiResult> DelBuddyInBlackList(string ownerusername, string username);
        /// <summary>
        /// 查看用户在线情况
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<EaseApiResultKvData> CheckUserStatus(string username);

        /// <summary>
        /// 查看用户离线消息数
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<EaseApiResultKvData> CheckUserOfflineMsgCount(string username);

        /// <summary>
        /// 查看用户离线消息状态
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<EaseApiResultKvData> CheckUserOfflineMsgStatus(string username,string msgid);

        /// <summary>
        /// 用户禁用
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<EaseApiResult> DeactivateUser(string username);
        /// <summary>
        /// 用户启用
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<EaseApiResult> ActivateUser(string username);
        /// <summary>
        /// 用户强制下线
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<EaseApiResultKvData> DisconnectUser(string username);
        /// <summary>
        ///  创建群聊
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EaseApiResultKvData> CreateChatGroup(CreateChatGroupInput input);
        /// <summary>
        ///  新增群聊成员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EaseApiResultKvData> CreateChatGroupUser(string groupid, string username);
        /// <summary>
        ///  新增群聊成员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EaseApiResultKvData> CreateChatGroupUserBatch(string groupid,CreateChatGroupUserInput input);

        /// <summary>
        ///  删除群聊成员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EaseApiResultKvData> DelChatGroupUser(string groupid, string username);
        /// <summary>
        ///  删除群聊成员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EaseApiResultKvData> DelChatGroupUserBatch(string groupid, string[] usernames);

        /// <summary>
        /// 修改群组信息
        /// </summary>
        /// <param name="groupid"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EaseApiResultKvData> EditChatGroupInfo(string groupid, EditChatGroupInfoInput input);
        Task<CreateChatRoomOutput> CreateChatRoom(CreateChatRoomInput input);
        /// <summary>
        /// 获取聊天记录
        /// </summary>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<EaseApiResultChatData> GetChatMessages(string ql,string cursor, int limit = 10);
    }
}
