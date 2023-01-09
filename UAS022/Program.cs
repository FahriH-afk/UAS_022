using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS022
{
    class Node
    {
        public string nama, kelas;
        public int NIM;
        public Node next;
        public Node prev;
    }

    class Double
    {
        Node START;

        public Double()
        {
            START = null;
        }
        public void add()
        {
            string nm, kls;
            int nim;
            Console.Write("\nMasukkan Nama Siswa : ");
            nm = (Console.ReadLine());
            Console.Write("\nMasukkan Kelas Siswa : ");
            kls = (Console.ReadLine());
            Console.Write("\nMasukkan NIM Siswa : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Node newnode = new Node();
            newnode.nama = nm;
            newnode.kelas = kls;
            newnode.NIM = nim;

            if (START == null || (nim <= START.NIM))
            {
                if ((START != null) && (nm == START.nama))
                {
                    Console.WriteLine("Nomor Yang Ingin Dimasukkan Sudah Ada");
                    return;
                }
                newnode.next = START;
                if(START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }

            Node previous, current;
            for (current = previous = START;
                current != null && nim >= current.NIM;
                previous = current, current = current.next)
            {
                if (nim == current.NIM)
                {
                    Console.WriteLine("\nNomor Yang Dimasukkan Tidak Bisa Di Duplikat");
                    return;
                }
            }

            newnode.next = current;
            newnode.prev = previous;

            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode; 
            previous.next = newnode;
; 
        }
        public bool search(int nim, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                nim >= current.NIM; previous = current,
                current = current.next) ; { }
            return (current != null);
        }
        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if (ListEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nReplay Nomor Yang Akan Diurutkan" + "Masukkan Nomor:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.NIM + " " + currentNode.nama + " " + currentNode.kelas + "\n");
            }
        }
        public void Traverse()
        {
            if(ListEmpty())
                Console.WriteLine("\nThe Record in the list are : ");
            else
            {
                Console.WriteLine("\nThe Records in the list are : ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.NIM + " " + currentNode.nama + " " + currentNode.kelas + "\n");
                Console.WriteLine();
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Double obj = new Double();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambahkan Data");
                    Console.WriteLine("2. Mencari Data");
                    Console.WriteLine("3. Mengurutkan Data");
                    Console.WriteLine("4. Menampilkan Data");
                    Console.WriteLine("5. Keluar\n");
                    Console.WriteLine("6. Masukkan Pilihanmu (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.add();
                            }
                            break;
                        case '2':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nList Masih Kosong");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nMasukkan Kelas Yang Ingin Kamu Cari : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nKelas Tidak Ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData Ditemukan");
                                    Console.WriteLine("\nKelas : " + curr.kelas);
                                    Console.WriteLine("\nNIM : " + curr.NIM);
                                    Console.WriteLine("\nNama : " + curr.nama);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.Traverse();
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check For The Values Entered. ");
                }
            }
        }
    }
}









//Nomor 2 (Menggunakan Double Linked List)
//Nomor 3 (TOP merupakan sebuah jalan atau yang digunakan sebagai penambah data dan menghapus data)
//Nomor 4 (Ditambahkan di akhir disebut Front dan dihapus dari yang paling akhir disebut REAR)
//Nomor 5 (a. Mempunyai 4 kedalaman)
//        (b. In Order ( 15,20,31,32,25,35,30,48,50,66,67,94,98,69,99,65,90,70)