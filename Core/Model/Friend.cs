using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Friend
    {
        public string NickName { get; set; }
        public long QqId { get; set; }
        public string GroupName { get; set; }
        public int GroupIndex { get; set; }
        public bool IsVip { get; set; }
        public int VipLevel { get; set; }
        public string Remark { get; set; }
    }
}
