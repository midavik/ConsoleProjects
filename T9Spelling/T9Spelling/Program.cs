using System;
using System.Collections.Generic;
using System.IO;

namespace T9Spelling
{
    class Program
    {
        // Input cases from keyboard
        //static void Main(string[] args)
        //{
        //    ConsoleKeyInfo keyInfo;
            
        //    List<string> messages = new List<string>();

        //    var messageConverter = new MessageConverter();
        //    messageConverter.MapSymbols();

        //    do
        //    {
        //        messages.Clear();
        //        Console.Clear();
                
        //        Console.WriteLine("Input");
        //        Console.WriteLine("Enter number of cases:");
        //        string casesNumber = Console.ReadLine();

        //        if (messageConverter.ValidateNumberOfCases(casesNumber))
        //        {
        //            int N = int.Parse(casesNumber);
        //            Console.WriteLine("Enter your cases:");

        //            for(int i = 0; i < N; i++)
        //            {
        //                messages.Add(Console.ReadLine());
        //            }

        //            Console.WriteLine();
        //            Console.WriteLine("Output");

        //            for (int i = 0; i < messages.Count; i++)
        //            {
        //                if (messageConverter.ValidateMessage(messages[i]))
        //                {
        //                    try
        //                    {
        //                        Console.WriteLine(string.Format("Case #{0}: {1}", (i + 1), messageConverter.ConvertMessage(messages[i])));
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Console.WriteLine(string.Format("Error Exception during converion of Case #{0}: '{1}'", (i + 1), messages[i]));
        //                    }
        //                }
        //                else Console.WriteLine(string.Format("Case #{0}: '{1}' is not valid!", (i + 1), messages[i]));
        //            }
        //        }
        //        else Console.WriteLine(string.Format("Number of cases '{0}' is not valid value!", casesNumber));
        //        keyInfo = Console.ReadKey();
        //    }
        //    while (keyInfo.Key != ConsoleKey.Escape);
        //}

        // Input cases from file. First param is the file name.


        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo;

            List<string> messages = new List<string>();

            var messageConverter = new MessageConverter();
            messageConverter.MapSymbols();

            do
            {
                messages.Clear();
                Console.Clear();

                Console.WriteLine("Input");
                Console.WriteLine("Enter file name:");
                string fileName = Console.ReadLine();

                try
                {
                    if (!messageConverter.FileExists(fileName))
                        Console.WriteLine(string.Format("Attention! Coud not find file: {0}", fileName));
                    else
                    {
                        using (StreamReader sr = new StreamReader(fileName))
                        {
                            string casesNumber = sr.ReadLine();
                            if (messageConverter.ValidateNumberOfCases(casesNumber))
                            {
                                int number = 0;
                                int N = int.Parse(casesNumber);
                               

                                while (number < N)
                                {
                                    messages.Add(sr.ReadLine());
                                    number++;
                                }

                                Console.WriteLine();
                                Console.WriteLine("Output");

                                for (int i = 0; i < messages.Count; i++)
                                {
                                    if (messageConverter.ValidateMessage(messages[i]))
                                    {
                                        try
                                        {
                                            Console.WriteLine(string.Format("Case #{0}: {1}", (i + 1), messageConverter.ConvertMessage(messages[i])));
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(string.Format("Error Exception during converion of Case #{0}: '{1}'", (i + 1), messages[i]));
                                        }
                                    }
                                    else Console.WriteLine(string.Format("Case #{0}: '{1}' is not valid!", (i + 1), messages[i]));
                                }
                            }
                            else Console.WriteLine(string.Format("Number of cases '{0}' is not valid value!", casesNumber));
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(string.Format("FileNotFoundException during opening file: {0}", fileName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Exception during opening file: {0}", fileName));
                }
                keyInfo = Console.ReadKey();
                
            }
            while (keyInfo.Key != ConsoleKey.Escape);
        }

    }
}

