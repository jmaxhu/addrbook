using Microsoft.AspNetCore.Mvc;
using Addrbook.Models;
using Addrbook.Service;

namespace Addrbook.Controllers
{
  /// <summary>
  /// StuffController
  /// </summary>
  [Route("api/[controller]")]
  public class StuffController : Controller
  {
    /// <summary>
    /// StuffRepository
    /// </summary>
    public IStuffService StuffService { get; set; }

    /// <summary>
    /// StuffController constructor
    /// </summary>
    public StuffController(IStuffService stuffService)
    {
      StuffService = stuffService;
    }

    /// <summary>
    /// 根据id得到员工
    /// </summary>
    [HttpGet("{id}", Name = "GetStuff")]
    public IActionResult GetById(int id)
    {
      return NotFound();
    }

    /// <summary>
    /// 添加一个员工
    /// </summary>
    /// <param name="stuff">要添加的员工</param>
    /// <returns>新添加的员工</returns>
    /// <response code="201">返回一个新添加的员工</response>
    [HttpPost]
    [ProducesResponseTypeAttribute(typeof(Stuff), 201)]
    [ProducesResponseType(typeof(void), 500)]
    public IActionResult Create([FromBody] Stuff stuff)
    {
      return NotFound();
    }

    /// <summary>
    /// 根据 id 更新一个员工信息
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseTypeAttribute(typeof(void), 500)]
    public IActionResult Update(int id, [FromBody] Stuff stuff)
    {
      return new NoContentResult();
    }

    /// <summary>
    /// 根据id删除一个员工
    /// </summary>
    [HttpDeleteAttribute("{id}")]
    public IActionResult Delete(int id)
    {
      return new NoContentResult();
    }
  }
}
