using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.Bases
{
    public abstract class BaseEntity
    {
        public int Id;
        public DateTime CreateTime;
        public DateTime UpdateTime;
        public DateTime DeleteTime;
        public bool Active;
        public bool Deleted;
    }
}
