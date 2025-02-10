using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub
{
    internal class FixedSizeList<T>:List<T>
    {

        public FixedSizeList( int size):base(size) 
        { }


        public new void Add (T item)
        {
            if (Count < Capacity)
            {
                base.Add(item); return;
            }
            else throw new Exception("List is Full !");
        }

        public T Get(int index)
        {
            return base[index];
        }
    }
}
