using System.ComponentModel.DataAnnotations;

namespace Addrbook.Models
{
  /// <summary>
  /// 员工信息
  /// </summary>
  public class Stuff
  {
    /// <summary>
    /// 序号
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    [StringLengthAttribute(10)]
    public string Name { get; set; }

    /// <summary>
    /// 部门id
    /// </summary>
    public int DepartmentId { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    [StringLengthAttribute(2)]
    public string Sex { get; set; }

    /// <summary>
    /// 固定电话
    /// </summary>
    [StringLengthAttribute(12)]
    public string Phone { get; set; }

    /// <summary>
    /// 内部分机号
    /// </summary>
    [StringLengthAttribute(10)]
    public string InnerPhone { get; set; }

    /// <summary>
    /// 虚拟网号码
    /// </summary>
    public string VirtualPhone { get; set; }

    /// <summary>
    /// 办公室
    /// </summary>
    [StringLengthAttribute(10)]
    public string Office { get; set; }

    /// <summary>
    /// 电话端口
    /// </summary>
    [StringLengthAttribute(10)]
    public string PhonePort { get; set; }

    /// <summary>
    /// 手机号码
    /// </summary>
    public string CellPhone { get; set; }

    /// <summary>
    /// 所在部门
    /// </summary>
    public Department Department { get; set; }
  }
}
