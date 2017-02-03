using System.Threading.Tasks;
using System.Collections.Generic;
using addrbook.Models;

namespace addrbook.Service
{
  /// <summary>
  /// 员工服务接口
  /// </summary>
  public interface IStuffService
  {
    /// <summary>
    /// 添加一个员工
    /// <param name="stuff">员工信息</param>
    /// </summary>
    Task Add(Stuff stuff);

    /// <summary>
    /// 搜索一个员工
    /// <param name="id">员工id</param>
    /// </summary>
    Task<Stuff> Find(int id);

    /// <summary>
    /// 删除一个员工
    /// <param name="id">员工id</param>
    /// </summary>
    Task<Stuff> Remove(int id);

      /// <summary>
    /// 搜索员工，目前只支持按姓名搜索。
    /// <param name="searchText">搜索关键字，目前只支持姓名搜索</param>
    /// </summary>
    Task<IEnumerable<Stuff>> Search(string searchText);

    /// <summary>
    /// 更新一个员工
    /// </summary>
    Task Update(Stuff stuff);
  }
}
