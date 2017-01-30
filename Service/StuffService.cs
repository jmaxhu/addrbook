using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using addrbook.Models;
using addrbook.Data;

namespace addrbook.Service
{
    /// <summary>
    /// 员工服务
    /// </summary>
    public class StuffService: IStuffService
    {
        private AddrBookDbContext _context;

        /// <summary>
        /// 员工服务构造函数
        /// </summary>
        public StuffService(AddrBookDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 添加一个员工
        /// </summary>
        /// <param name="stuff">员工信息</param>
        public void Add(Stuff stuff)
        {
        }

        /// <summary>
        /// 删除一个员工
        /// </summary>
        public Stuff Remove(int id)
        {
            return null;
        }

        /// <summary>
        /// 搜索一个员工
        /// </summary>
        public Stuff Find(string key)
        {
            return null;
        }

        /// <summary>
        /// 更新一个员工
        /// </summary>
        public void Update(Stuff stuff)
        {
        }
    }
}
