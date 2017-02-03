using System;

namespace addrbook.Models
{
  /// <summary>
  /// 用户友好的异常类型
  /// </summary>
  public class UserFriendlyException : Exception
  {
    /// <summary>
    /// 构造函数
    /// </summary>
    public UserFriendlyException(string message) : base(message) { }
  }
}