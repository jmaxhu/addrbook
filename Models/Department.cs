using System.ComponentModel.DataAnnotations;

namespace addrbook.Models
{
  /// <summary>
  /// 部门
  /// </summary>
  public class Department
  {
    /// <summary>
    /// 序号
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 部门名称
    /// </summary>
    [StringLength(15)]
    public string Name { get; set; }
  }
}