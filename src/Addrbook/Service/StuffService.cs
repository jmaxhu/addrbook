using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Addrbook.Models;
using Addrbook.Data;

namespace Addrbook.Service
{
  /// <summary>
  /// 员工服务
  /// </summary>
  public class StuffService : IStuffService
  {
    private AddrBookDbContext context;

    /// <summary>
    /// 员工服务构造函数
    /// </summary>
    public StuffService(AddrBookDbContext context)
    {
      this.context = context;
    }

    /// <summary>
    /// 添加一个员工
    /// </summary>
    /// <param name="stuff">员工信息</param>
    public async Task<Stuff> Add(Stuff stuff)
    {
      if (stuff == null ||
          stuff.DepartmentId == 0 ||
          string.IsNullOrEmpty(stuff.Name) ||
          string.IsNullOrEmpty(stuff.Phone) ||
          string.IsNullOrEmpty(stuff.CellPhone) ||
          string.IsNullOrEmpty(stuff.Office))
      {
        throw new UserFriendlyException($"参数错误，{nameof(stuff)}, 请确保部门，姓名，电话等不为空。");
      }

      // 手机号码不能重复
      var hasSamePhone = context.Stuffs.Any(x => x.CellPhone == stuff.CellPhone);
      if (hasSamePhone)
      {
        throw new UserFriendlyException($"手机号为:{stuff.CellPhone} 的联系人已存在!");
      }

      // 部门是否存在
      var hasDepartment = context.Departments.Any(x => x.Id == stuff.DepartmentId);
      if (!hasDepartment)
      {
        throw new UserFriendlyException($"所在部门不存在，请检查部门。");
      }

      stuff.Id = 0;
      context.Stuffs.Add(stuff);
      await context.SaveChangesAsync();

      return stuff;
    }

    /// <summary>
    /// 根据id删除一个员工
    /// <param name="id">员工id</param>
    /// </summary>
    public async Task<Stuff> Remove(int id)
    {
      var stuff = context.Stuffs.FirstOrDefault(x => x.Id == id);
      if (stuff == null)
      {
        throw new UserFriendlyException($"用户不存在");
      }

      context.Stuffs.Remove(stuff);
      await context.SaveChangesAsync();

      return stuff;
    }

    /// <summary>
    /// 搜索一个员工
    /// <param name="id">员工编号</param>
    /// </summary>
    public async Task<Stuff> Find(int id)
    {
      return await Task.FromResult(context.Stuffs.FirstOrDefault());
    }

    /// <summary>
    /// 搜索员工，目前只支持按姓名搜索。
    /// <param name="searchText">搜索关键字，目前只支持姓名搜索</param>
    /// </summary>
    public async Task<IEnumerable<Stuff>> Search(string searchText)
    {
      // TODO: 增加全文检索的功能
      var stuffs = context.Stuffs.Where(x => x.Name.Contains(searchText));
      return await Task.FromResult(stuffs);
    }

    /// <summary>
    /// 更新一个员工
    /// <param name="stuff">待更新的员工信息</param>
    /// </summary>
    public async Task Update(Stuff stuff)
    {
      var dbStuff = context.Stuffs.FirstOrDefault(x => x.Id == stuff.Id);
      if (dbStuff == null)
      {
        throw new UserFriendlyException("待更新的员工不存在");
      }

      var department = context.Departments.FirstOrDefault(x => x.Id == stuff.DepartmentId);
      if (department == null)
      {
        throw new UserFriendlyException("待更新的员工部门不存在");
      }

      dbStuff.Name = stuff.Name;
      dbStuff.Phone = stuff.Phone;
      dbStuff.InnerPhone = stuff.InnerPhone;
      dbStuff.Office = stuff.Office;
      dbStuff.VirtualPhone = stuff.VirtualPhone;
      dbStuff.PhonePort = stuff.PhonePort;
      dbStuff.Sex = stuff.Sex;
      dbStuff.DepartmentId = stuff.DepartmentId;

      await context.SaveChangesAsync();
    }
  }
}
