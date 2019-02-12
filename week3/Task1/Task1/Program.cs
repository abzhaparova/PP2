using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
        class Program
        {
            static string path = @"C:\Users\Aida\Desktop\pp2\PP2\week3\Task1\need";
            static FileSystemInfo currentFSI;
            static int selectedindex = 0;
            static Stack<string> hist = new Stack<string>();


            static void Show()
            {
                Console.SetCursorPosition(0, 0);
                DirectoryInfo d = new DirectoryInfo(@path);

                List<FileSystemInfo> li = new List<FileSystemInfo>();
                li.AddRange(d.GetDirectories());
                li.AddRange(d.GetFiles());
                FileSystemInfo[] fsi = li.ToArray();
                currentFSI = fsi[selectedindex];

                for (int i = 0; i < fsi.Length; i++)
                {
                    FileSystemInfo fs = fsi[i];
                    if (selectedindex == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    if (fs.GetType() == typeof(DirectoryInfo))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    Console.WriteLine(i + 1 + ". " + fs.Name);
                }
            }

            static void Main(string[] args)
            {

                while (true)
                {
                    Show();
                    ConsoleKeyInfo cki = Console.ReadKey();
                    switch (cki.Key)
                    {
                        case ConsoleKey.UpArrow:
                            UpArrow();
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

            static void UpArrow()
            {
                selectedindex--;
                if (selectedindex < 0)
                {
                    selectedindex = 0;
                }
            }

            static void DownArrow()
            {
                selectedindex++;
            }

            static void OpenFile()
            {
                Console.Clear();

                if (currentFSI.GetType() == typeof(DirectoryInfo))
                {
                    selectedindex = 0;
                    hist.Push(path);
                    path = currentFSI.FullName;
                    Console.Clear();
                }
                else
                {
                    FileStream fs = new FileStream(currentFSI.FullName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    Console.WriteLine(sr.ReadToEnd());
                    Console.ReadKey();
                    sr.Close();
                    fs.Close();
                }
                Console.Clear();
            }

            static void Escape()
            {
                path = hist.Peek();
                hist.Pop();
                selectedindex = 0;
                Console.Clear();
            }

            static void Delete()
            {
                if (currentFSI.GetType() == typeof(FileInfo))
                {
                    File.Delete(currentFSI.FullName);
                }
                else
                {
                    Directory.Delete(currentFSI.FullName, true);
                }
                Console.Clear();
                selectedindex = 0;
            }

            static void Rename()
            {
                Console.SetCursorPosition(10, 30);
                Console.Write("Enter new name:");
                string path = currentFSI.FullName;
                string pr = new DirectoryInfo(path).Parent.FullName; //до ForLab3
                string newName = Console.ReadLine();

                if (currentFSI.GetType() == typeof(FileInfo))
                {
                    File.Move(path, pr + "\\" + newName);
                }
                else
                {
                    Directory.Move(path, pr + "\\" + newName);
                }

                Console.Clear();


            }

        }
    }