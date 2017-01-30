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
        /// </summary>
        void Add(Stuff stuff);

        /// <summary>
        /// 搜索一个员工
        /// </summary>
        Stuff Find(string key);

        /// <summary>
        /// 删除一个员工
        /// </summary>
        Stuff Remove(int id);

        /// <summary>
        /// 更新一个员工
        /// </summary>
        void Update(Stuff stuff);
    }
}
