using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            //FirstProg();
            //SecondProg();
            ThirdProg();
        }


        static void FirstProg()
        {
            List<long> firstList = new List<long>();          /*1*/
            for(int i = 0; i < 8; i++)
            {
                Console.Write("Введите значение: ");
                firstList.Add(long.Parse(Console.ReadLine()));
            }
            PrintSimpleList<long>(firstList);                /*2*/

            Console.WriteLine("Будут удалены 5 и 2 элементы.");/*3*/
            firstList.Remove(firstList[4]);
            firstList.Remove(firstList[1]);

            Console.Write("Введите замену для 3 элемента: ");
            firstList[2] = long.Parse(Console.ReadLine());

            for (int i = 0; i < firstList.Count; i++)        /*4*/
                Console.WriteLine("    {0}", firstList[i].ToString());

            List<long> secondList = new List<long>();        /*5*/
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Введите значение: ");
                secondList.Add(long.Parse(Console.ReadLine()));
            }

            Console.WriteLine("Из первого контейнера будут удалено два элемента после первого, и добавлены все элементы из второго!");/*6*/
            firstList.RemoveRange(2, 3);
            firstList.AddRange(secondList);

            PrintSimpleList<long>(firstList);
            Console.WriteLine("----------------------------------------------");
            PrintSimpleList<long>(secondList);
        }

        static void SecondProg()
        {
            List<Human> firstList = new List<Human>();          /*1*/
            firstList.Add(new Human("Данил", 20));
            firstList.Add(new Human("Никита", 19));
            firstList.Add(new Human("Денис", 22));
            firstList.Add(new Human("Валентин", 23));
            firstList.Add(new Human("Артём", 23));
            PrintSimpleList<Human>(firstList);                /*2*/

            Console.WriteLine("Будут удалены 5 и 2 элементы.");/*3*/
            firstList.Remove(firstList[4]);
            firstList.Remove(firstList[1]);

            Console.Write("Введите замену для 3 элемента");
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());
            firstList[2] = new Human(name, age);

            for (int i = 0; i < firstList.Count; i++)        /*4*/
                Console.WriteLine("    {0}", firstList[i].ToString());

            List<Human> secondList = new List<Human>();        /*5*/
            secondList.Add(new Human("Екатерина", 20));
            secondList.Add(new Human("Анна", 19));
            secondList.Add(new Human("Марина", 22));
            secondList.Add(new Human("Ольга", 23));
            secondList.Add(new Human("Анастасия", 23));

            Console.WriteLine("Из первого контейнера будут удалено два элемента после первого, и добавлены все элементы из второго!");/*6*/
            firstList.RemoveRange(1, 2);
            firstList.AddRange(secondList);

            PrintSimpleList<Human>(firstList);
            Console.WriteLine("----------------------------------------------");
            PrintSimpleList<Human>(secondList);
        }

        static void ThirdProg()
        {
            Deque<Human> deque = new Deque<Human>(); 
            List<Human> list = new List<Human>();/*1*/

            list.Add(new Human("Данил", 20));
            list.Add(new Human("Никита", 19));
            list.Add(new Human("Денис", 22));


            foreach (var i in list)
                Console.WriteLine(i.ToString());

            list.Sort(delegate (Human x, Human y)/*2*/
            {
                if (x.Age > y.Age)
                    return -1;
                else if (x.Age == y.Age)
                    return 0;
                else
                    return 1;
            });

            Console.WriteLine("--------------------------------------------");
            foreach (var i in list)    /*3*/
                Console.WriteLine(i.ToString());

            Console.WriteLine("Элемент удовлетворяющий условию: {0}", list.Find(x => x.Name == "Данил").ToString()); /*4*/
            Console.WriteLine("--------------------------------------------");

            deque.ImportFromList(list.FindAll(x => x.Age >= 20));/*5*/
            Console.WriteLine("Условие: Возраст >= 20");
            foreach (var i in deque)    /*6*/
                Console.WriteLine(i.ToString());

            list.Sort(delegate (Human x, Human y)/*7*/
            {
                if (x.Age > y.Age)
                    return 1;
                else if (x.Age == y.Age)
                    return 0;
                else
                    return -1;
            });

            List<Human> tempList = deque.ConvertToList();
            tempList.Sort(delegate (Human x, Human y)
            {
                if (x.Age > y.Age)
                    return 1;
                else if (x.Age == y.Age)
                    return 0;
                else
                    return -1;
            });
            deque.ImportFromList(tempList);
            Console.WriteLine("--------------------------------------------\nКонтейнеры после сортировки:");
            foreach (var i in list)    /*8*/
                Console.WriteLine(i.ToString());
            Console.WriteLine("Дек:");
            foreach (var i in deque)
                Console.WriteLine(i.ToString());

            List<Human> thirdContainer = new List<Human>();   /*9*/
            thirdContainer.AddRange(list);
            thirdContainer.AddRange(deque.ConvertToList());
            Console.WriteLine("--------------------------------------------\nТретий контейнер:");
            foreach (var i in thirdContainer)   /*10*/
                Console.WriteLine(i.ToString());
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Третий контейнер содержит {0} элементов, удовлетворяющий условию: возраст == 20", thirdContainer.FindAll(x => x.Age == 20).Count.ToString());  /*11*/

            Console.WriteLine("Третий контейнер содержит({0}) элемент, удовлетворяющий условию: возраст < 16", thirdContainer.FindAll(x => x.Age < 16).Count != 0);  /*12*/
        }

        static void PrintSimpleList<T> (List<T> list)
        {
            foreach (var i in list)
                Console.WriteLine("    {0}", i.ToString());
        }

    }

    

    class Human
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public void WhoAmI()
        {
            Console.WriteLine("Меня зовут: {0}, Мне {1} лет.", Name, Age);
        }

        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return string.Format("Имя: {0} | Возраст: {1}", Name, Age);
        }
    }

    public class Deque<T> : IEnumerable<T>  // двусвязный список
    {
        DoublyNode<T> head; // головной/первый элемент
        DoublyNode<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void AddLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        public T RemoveFirst()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;
            return output;
        }
        public T RemoveLast()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = tail.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            count--;
            return output;
        }
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;
            }
        }
        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;
            }
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public List<T> ConvertToList()
        {
            List<T> result = new List<T>();

            foreach (var i in this)
                result.Add(i);

            return result;
        }

        public void ImportFromList(List<T> list)
        {
            Deque<T> newDeque = new Deque<T>();
            foreach (var i in list)
                newDeque.AddFirst(i);

            this.count = newDeque.count;
            this.head = newDeque.head;
            this.tail = newDeque.tail;
        }
    }

    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }
}
