using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    namespace Shifrovanie_Cezar
    {
        class Program
        {
            static void Main()
            {
                do
                {
                    string path = @"Text.txt";
                    uint k = 0;
                    string s = "";
                    string result = "";
                    uint shift;
                    Console.WriteLine("Введите 1 для шифрования или 2 для дешифрования");
                    while ((k != 1) && (k != 2))
                    {
                        uint.TryParse(Console.ReadLine(), out k);
                        if ((k != 1) && (k != 2))
                            Console.WriteLine("Ошибка ввода, повторите попытку");
                    }
                    Console.WriteLine("Введите величину сдвига");
                    while (!uint.TryParse(Console.ReadLine(), out shift))
                    {
                        Console.WriteLine("Ошибка ввода, повторите попытку");
                    }
                    if (shift > 32)
                        shift = shift % 32;
                    if (k == 1)
                    {
                        Console.WriteLine("Строка считывается из файла!");
                        s = File.ReadAllText(path, Encoding.Default);
                        //Цикл по каждому символу строки
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (((int)(s[i]) < 1040) || ((int)(s[i]) > 1103))
                                result += s[i];
                            if ((Convert.ToInt16(s[i]) >= 1072) && (Convert.ToInt16(s[i]) <= 1103))
                            {
                                if (Convert.ToInt16(s[i]) + shift > 1103)
                                    result += Convert.ToChar(Convert.ToInt16(s[i]) + shift - 32);
                                else
                                    result += Convert.ToChar(Convert.ToInt16(s[i]) + shift);
                            }
                            if ((Convert.ToInt16(s[i]) >= 1040) && (Convert.ToInt16(s[i]) <= 1071))
                            {
                                if (Convert.ToInt16(s[i]) + shift > 1071)
                                    result += Convert.ToChar(Convert.ToInt16(s[i]) + shift - 32);
                                else
                                    result += Convert.ToChar(Convert.ToInt16(s[i]) + shift);
                            }
                        }
                        Console.WriteLine("Строка успешно зашифрована!");
                        StreamWriter sr = new StreamWriter(@"Text2.txt", false);
                        sr.Write(result);
                        sr.Close();
                        Console.WriteLine(result);
                    }
                    if (k == 2)
                    {
                        StreamWriter sr1 = new StreamWriter(@"Text3.txt", false);
                        for (shift = 1; shift < 33; shift++)
                        {
                            result = "";
                            Console.WriteLine("Строка считывается из файла!");
                            StreamReader sr = new StreamReader(@"Text2.txt");
                            s = sr.ReadToEnd();
                            sr.Close();
                            for (int i = 0; i < s.Length; i++)
                            {
                                if (Convert.ToInt16(s[i]) == 32)
                                    result += ' ';
                                if ((Convert.ToInt16(s[i]) >= 1072) && (Convert.ToInt16(s[i]) <= 1103))
                                {
                                    if (Convert.ToInt16(s[i]) - shift < 1072)
                                        result += Convert.ToChar(Convert.ToInt16(s[i]) - shift + 32);
                                    else
                                        result += Convert.ToChar(Convert.ToInt16(s[i]) - shift);
                                }
                                if ((Convert.ToInt16(s[i]) >= 1040) && (Convert.ToInt16(s[i]) <= 1071))
                                {
                                    if (Convert.ToInt16(s[i]) - shift < 1040)
                                        result += Convert.ToChar(Convert.ToInt16(s[i]) - shift + 32);
                                    else
                                        result += Convert.ToChar(Convert.ToInt16(s[i]) - shift);
                                }
                            }
                            //Вывод на экран дешифрованной строки
                            Console.WriteLine("Строка успешно дешифрована!");
                            sr1.Write(result);
                            sr1.WriteLine();
                            Console.WriteLine(result);
                            
                        }
                        sr1.Close();
                    }
                    Console.WriteLine("Для выхода из программы нажмите Escape");
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
         
        }
    }
}