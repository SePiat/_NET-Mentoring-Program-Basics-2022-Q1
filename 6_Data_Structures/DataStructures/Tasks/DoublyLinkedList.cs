using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public int Length { get; set; }

        public Item<T> Head { get; set; }
        public Item<T> Tail { get; set; }

        public void Add(T e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            var newItem = new Item<T>(e);
            if (Head == null)
            {
                Head = newItem;
            }
            else
            {
                newItem.Previous = Tail;
                Tail.Next = newItem;
            }
            Tail = newItem;
            Length++;
        }

        public void AddAt(int index, T e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            var foundItem = Find(index);
            if (foundItem != null)
            {
                var newItem = new Item<T>(e);
                if (foundItem == Head)
                {
                    foundItem.Previous = newItem;
                    newItem.Next = foundItem;
                    Head = newItem;
                }
                else
                {
                    newItem.Next = foundItem;
                    newItem.Previous = foundItem.Previous;
                    foundItem.Previous.Next = newItem;
                    foundItem.Previous = newItem;
                }
                Length++;
            }
            else
            {
                Add(e);
            }
        }

        public T ElementAt(int index)
        {
            var foundItem = Find(index);
            return foundItem != null ? foundItem.Value : throw new IndexOutOfRangeException();
        }

        public void Remove(T e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            var index = GetIndex(e);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public T RemoveAt(int index)
        {
            var foundItem = Find(index);
            if (foundItem != null)
            {
                if (foundItem == Tail)
                {
                    Tail = foundItem.Previous;
                }
                else
                {
                    foundItem.Next.Previous = foundItem.Previous;
                }

                if (foundItem == Head)
                {
                    Head = foundItem.Next;
                }
                else
                {
                    foundItem.Previous.Next = foundItem.Next;
                }
                var value = foundItem.Value;
                Length--;
                return value;
            }
            throw new IndexOutOfRangeException();
        }


        public DoublyLinkedListEnumerator GetEnumerator()
        {
            return new DoublyLinkedListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Item<T> Find(int index)
        {
            var counter = 0;
            using var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (counter == index)
                {
                    return enumerator.CurrentElement;
                }
                counter++;
            }
            return null;
        }

        private int GetIndex(T value)
        {
            var counter = 0;
            using var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                var currentValue = enumerator.Current;

                if (currentValue != null && currentValue.Equals(value))
                {
                    return counter;
                }
                counter++;
            }
            return -1;
        }

        public struct DoublyLinkedListEnumerator : IEnumerator<T>
        {
            private readonly DoublyLinkedList<T> _doubleLinkedList;

            public DoublyLinkedListEnumerator(DoublyLinkedList<T> doubleLinedList)
            {
                _doubleLinkedList = doubleLinedList;
                CurrentElement = null;
            }

            public bool MoveNext()
            {
                if (CurrentElement == null)
                {
                    CurrentElement = _doubleLinkedList.Head;
                }
                else
                {
                    CurrentElement = CurrentElement.Next;
                }
                return CurrentElement != null;
            }

            public void Reset()
            {
                CurrentElement = _doubleLinkedList.Head;
            }

            public T Current => CurrentElement.Value;

            public Item<T> CurrentElement { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {

            }
        }
    }
}
