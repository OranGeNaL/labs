﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Prog
{
    class ListContainer<T>
    {
        int Count = 0;

        ListNode<T> head;
        ListNode<T> tail;

        public ListContainer()
        {

        }

        public void Insert(T Value)
        {
            ListNode<T> newNode = new ListNode<T>(Value, this);
            if (Count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                head.prev = newNode;
                newNode.next = head;
                head = newNode;
            }
            Count++;
        }

        public void Append(T Value)
        {
            ListNode<T> newNode = new ListNode<T>(Value, this);
            if (Count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = head;
                tail = newNode;
            }
            Count++;
        }

        public ListNode<T> PopBack()
        {
            ListNode<T> popNode;
            if(Count != 0)
            {
                if (Count == 1)
                {
                    Count--;
                    popNode = head;
                    head = null;
                    tail = null;
                    return popNode;
                }
                else
                {
                    Count--;
                    popNode = tail;
                    tail = tail.prev;
                    return popNode;
                }
            }
            return null; 
        }

        public ListNode<T> PopForward()
        {
            ListNode<T> popNode;
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Count--;
                    popNode = head;
                    head = null;
                    tail = null;
                    return popNode;
                }
                else
                {
                    Count--;
                    popNode = head;
                    head = head.next;
                    return popNode;
                }
            }
            return null;
        }

        public override string ToString()
        {
            string res = "";
            ListNode<T> iter = head;
            for(int i = 0; i < Count; i++)
            {
                res += iter.ToString() + "\n";
                iter = iter.next;
            }
            return res;
        }

        public static ListNode<T> operator >= ( ListContainer<T> container, int node) // Выталкивание с конца
        {
            return container.PopBack();
        }


        public static ListNode<T> operator <=(ListContainer<T> container, int node)
        {
            return null;
        }

        public static ListNode<T> operator >(ListContainer<T> container, int node) // Выталкивание с начала
        {
            return container.PopForward();
        }

        public static ListNode<T> operator <(ListContainer<T> container, int node)
        {
            return null;
        }

        public static ListNode<T> operator <=(ListContainer<T> container, T node) // Вставка в конец
        {
            //return container.PopBack();
            container.Append(node);
            return null;
        }

        public static ListNode<T> operator>=(ListContainer<T> container, T node)
        {
            //return container.PopBack();
            container.Append(node);
            return null;
        }

        public static ListNode<T> operator >(ListContainer<T> container, T node)  // Вставка в начало
        {
            container.Insert(node);
            return null;
        }

        public static ListNode<T> operator <(ListContainer<T> container, T node)
        {
            container.Insert(node);
            return null;
        }
    }
}
