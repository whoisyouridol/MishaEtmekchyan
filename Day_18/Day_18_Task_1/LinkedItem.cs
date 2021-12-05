using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Day_18_Task_1
{
    public class LinkedItem<T> : ILinkedItem<T>
    {
        private T _getT;
        public class Node<T>
        {
            // შემდეგი წვეროს მისამართი
            public Node<T> next = null;
            // მონაცემი
            public T data;
        }

        private Node<T> root = null;

        public Node<T> Root
        {
            get
            {
                return root;
            }
            set { root = value; }
        }

        public bool Exists()
        {
            return root != null;
        }

        public void AddItem(T value)
        {
            Node<T> n = new Node<T> { data = value };
            if (root == null)
            {
                root = n;
            }
            else
            {
                Node<T> curr = root;
                while (curr.next != null)
                {
                    curr = curr.next;
                }
                curr.next = n;
            }
        }

        public void RemoveItem(T data)
        {
            if (root != null && Object.Equals(root.data, data))
            {
                var node = root;
                root = node.next;
                node.next = null;
            }
            else
            {
                Node<T> curr = root;
                while (curr.next != null)
                {
                    if (Object.Equals(curr.next.data, data))
                    {
                        var node = curr.next;
                        curr.next = node.next;
                        node.next = null;
                        break;
                    }

                    curr = curr.next;
                }
            }
        }

        public void PrintItems()
        {
            Node<T> curr = root;
            while (curr != null)
            {
                Console.WriteLine($"data : {curr.data.ToString()}");
                curr = curr.next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> curr = root;
            while (curr != null)
            {
                yield return curr.data;
                curr = curr.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public LinkedItem<T> this[int i]
        {
            get
            {
                if (root == null)
                {
                    throw new NotImplementedException();
                }
                var current = root;
                var _allElements = new List<Node<T>>
                {
                    current
                };

                while (current.next != null)
                {
                    current = current.next;
                    _allElements.Add(current);
                }

                foreach (var item in _allElements)
                {
                    if (item == _allElements[i])
                    {
                        return new LinkedItem<T>()
                        {
                            root = new Node<T>()
                            {
                                data = item.data
                            }
                        };
                    }
                }
                throw new NotImplementedException();
            }

            //--------------------------------------------------------------------------

            set
            {
                //this.root = new Node<T> { data = value.Root.data};
                var temp = new Node<T> { data = value.Root.data };
                    Node<T> curr = root;
                    while (curr.next != null)
                    {
                        curr = curr.next;
                    }
                    curr.next = temp;
            }
        }
    }
}
