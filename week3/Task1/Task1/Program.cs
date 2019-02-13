using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
        class Program//created class Program(it works as FarManager)
        {
            static string path = @"C:\Users\Aida\Desktop\pp2\PP2\week3\Task1\need";//directory of the path 
            static FileSystemInfo currentFSI;
            static int selectedindex = 0; 
            static Stack<string> hist = new Stack<string>();//creating stack for saving strings(saving layers)


        static void Show()
        {
            Console.SetCursorPosition(0, 0);// cursors position where cursor is equal 0, because it's startpoint from 0 
            DirectoryInfo d = new DirectoryInfo(@path);

                List<FileSystemInfo> li = new List<FileSystemInfo>();
                li.AddRange(d.GetDirectories());//adding directories
                li.AddRange(d.GetFiles());//adding files
                FileSystemInfo[] fsi = li.ToArray();//converting to array fsi because list is not mutable 
                currentFSI = fsi[selectedindex];//the index of the selected item, at the start is 0

                for (int i = 0; i < fsi.Length; i++)
                {
                    FileSystemInfo fs = fsi[i];
                    if (selectedindex == i)//if it is selected item then we paint it with red background color, else color is black
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    if (fs.GetType() == typeof(DirectoryInfo))//the condition works if the selected item is directory, so the foreground color is white, else if it is file then yellow 
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    Console.WriteLine((i + 1) + ". " + fs.Name);//numeration of the each file or directory, here i is 0 and adds 1(numeration starts from 1), +name
                }
            }

            static void Main(string[] args)
            {
                while (true)//infinity loop
                {
                    Show();//recalling the show function
                    ConsoleKeyInfo cki = Console.ReadKey();//считывает то что мы нажимаем на клавише 
                    switch (cki.Key)//same as if else 
                    //considering possible cases that we need for Farmanager
                    {
                        case ConsoleKey.UpArrow:
                            UpArrow();//recalling UpArrow function
                            break;
                        case ConsoleKey.DownArrow:
                            DownArrow();
                            break;
                        case ConsoleKey.Enter:
                            OpenFile();
                            break;
                        case ConsoleKey.Escape:
                            Escape();
                            break;
                        case ConsoleKey.Delete:
                            Delete();
                            break;
                        case ConsoleKey.R:
                            Rename();
                            break;
                    }
                }
            }

            static void UpArrow()//function for navigating up
            {
                selectedindex--;
                if (selectedindex < 0)
                    selectedindex = 0;
            }

            static void DownArrow()//function for navigating down
            {   
                selectedindex++;
            }

            static void OpenFile()//function for reading file/directory
            {
                Console.Clear();//Clear() used to clear console after each pressing of key to hide history

            if (currentFSI.GetType() == typeof(DirectoryInfo))//if its directory then creating new layer of directory and pushing it into stack
            {
                    selectedindex = 0;
                    hist.Push(path);
                    path = currentFSI.FullName;
                    Console.Clear();
            }
                else//if its file we will open content of the file
                {
                    FileStream fs = new FileStream(currentFSI.FullName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);//reading the file through fs 
                    Console.WriteLine(sr.ReadToEnd());//writeline in console all readed content of the file 
                    Console.ReadKey();//pausing the terminal
                    sr.Close();
                    fs.Close();
                }
                Console.Clear();
            }

            static void Escape()//function for going back
            {
                path = hist.Peek();
                hist.Pop();
                selectedindex = 0;
                Console.Clear();
            }

            static void Delete()//function for deleting file and directory
            {
                if (currentFSI.GetType() == typeof(FileInfo))
                {
                    File.Delete(currentFSI.FullName);//deleting file 
                }
                else
                {
                    Directory.Delete(currentFSI.FullName, true);//delete directory and so means all its children also
                }
                Console.Clear();
                selectedindex = 0;//again cursor becomes 0 at a startpoint 
            }

            static void Rename()//function for renaming the file/directory
            {
                Console.SetCursorPosition(10, 30);
                Console.Write("Enter new name:");//writing in console for user
                string path = currentFSI.FullName;
                string pr = new DirectoryInfo(path).Parent.FullName; 
                string newName = Console.ReadLine();// newname that user entered

            if (currentFSI.GetType() == typeof(FileInfo))
                {
                    File.Move(path, pr + "\\" + newName);
                }
                else
                {
                    Directory.Move(path, pr + "\\" + newName);
                }

                Console.Clear();//Clear() used to clear console after each pressing of key to hide history
            }
        }
    }