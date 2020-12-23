using System;
using System.Collections.Generic;
using System.Text;

namespace 그래프2
{
    public class MyExam
    {
        private LinkedList<Album> albums = new LinkedList<Album>();

        public void Ex()
        {

            albums.AddLast(new LinkedListNode<Album>(new Album { Name = "Lost And Found", Artist = new Artist("아이유"), ReleaseDate = "" }));
            albums.AddLast(new LinkedListNode<Album>(new Album { Name = "Growing Up", Artist = new Artist("아이유"), ReleaseDate = "" }));
            albums.AddLast(new LinkedListNode<Album>(new Album { Name = "IU IM", Artist = new Artist("아이유"), ReleaseDate = "" }));

            albums.AddLast(new LinkedListNode<Album>(new Album { Name = "Season of Glass", Artist = new Artist("여자친구"), ReleaseDate = "" }));
            albums.AddLast(new LinkedListNode<Album>(new Album { Name = "Flower Bud", Artist = new Artist("여자친구"), ReleaseDate = "" }));

            Console.WriteLine("LinkedList.Find");
            var findAlbums = albums.Find(new Album { Name = "Lost And Found", Artist = new Artist("아이유"), ReleaseDate = "" });
            if (findAlbums != null)
            {
                foreach (var item in findAlbums.List)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine(" null ");
            }

            Console.WriteLine("foreach name find");
            Album album = FindFirst("Growing Up");
            if (album == null)
            {
                Console.WriteLine(" null ");

            }
            else
            {
                Console.WriteLine("{0}", album.Name);
            }


            Console.WriteLine("foreach artist find");
            Album album2 = FindFirstByAlbum("Season of Glass", new Artist("여자친구"), "");
            if (album2 == null)
            {
                Console.WriteLine(" null ");

            }
            else
            {
                Console.WriteLine("{0}", album2.Name);
            }
        }

        public Album FindFirst(string name)
        {
            foreach (var item in albums)
            {
                if (item.Name == name)
                {
                    return item; 
                }
            }
            return null;
        }

        public Album FindFirstByAlbum(string name, Artist artist, string releaseDate)
        {
            Album album = new Album(name, artist, releaseDate);
            foreach (var item in albums)
            {
                if (item == album)
                {
                    return item;
                }

                if (item.Equals(album))
                {
                    return item;
                }
            }
            return null;
        }

    }

    // type parameter T in angle brackets
    public class GenericList<T>
    {
        // The nested class is also generic on T.
        private class Node
        {
            // T used in non-generic constructor.
            public Node(T t)
            {
                next = null;
                data = t;
            }

            private Node next;
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            // T as private member data type.
            private T data;

            // T as return type of property.
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;

        // constructor
        public GenericList()
        {
            head = null;
        }

        // T as method parameter type:
        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }

    public class Album
    {
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public string ReleaseDate { get; set; }

        public Album()
        {

        }

        public Album(string name, Artist artist, string releaseDate)
        {
            this.Name = name;
            this.Artist = artist;
            this.ReleaseDate = releaseDate; 
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} {1} {2}", Name, Artist, ReleaseDate); 

            return builder.ToString(); 
        }
    }

    public class Artist
    {
        public string Name { get; set; }

        public Artist()
        {
        }
        public Artist(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Name);

            return builder.ToString();
        }
    }
}
