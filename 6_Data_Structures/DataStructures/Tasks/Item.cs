using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class Item<T>
    {
        public T Value { get; set; }
        public Item<T> Next { get; set; } = null;
        public Item<T> Previous { get; set; } = null;

        public Item(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Value = data;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
