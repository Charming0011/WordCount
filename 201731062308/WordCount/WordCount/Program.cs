using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WordCount
{
    
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = null;
            Process count = new excute();
            string path = null;//读入文件路径标志
            string outPath = null;//写出文件路径标志
            string GetExNum = null;//限制输出个数的值
            string GetNum = null;//指定频数的值
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-i":
                        path = args[i + 1];//寻找是否找到输入文件路径
                        break;
                    case "-m"://-m参数与数字配套使用，用于设置词组长度
                        GetExNum = args[i + 1];
                        break;
                    case "-n"://-n参数与数字搭配使用，用于限制最终输出的单词的个数
                        GetNum = args[i + 1];
                        break;
                    case "-o"://-o表示输出路径
                        outPath = args[i + 1];
                        break;
                }
            }
            if (path != null)
            {
                if (outPath != null)
                {
                    sw = new StreamWriter(outPath);//在outPath创建写文件流
                }
                Console.WriteLine("characters:" + count.CountChar(path));
                Console.WriteLine("words:" + count.CountWord(path));
                Console.WriteLine("lines:" + count.CountLine(path));
                sw.WriteLine(String.Format("characters:" + count.CountChar(path)));
                sw.WriteLine(String.Format("words:" + count.CountWord(path)));
                sw.WriteLine(String.Format("lines:" + count.CountLine(path)));
                /*if (GetExNum != null)//将查找指定频数的结果输出，并写入文件
                {
                    Dictionary<string, int> dictionary = count.CountFrequency(path);
                    dictionary = count.SortDictionary_Desc(dictionary);
                    Console.WriteLine("频数为" + GetExNum + "单词如下：");
                    foreach (KeyValuePair<string, int> dic in dictionary)
                    {
                        if (dic.Value == int.Parse(GetExNum))
                        {
                            sw.WriteLine(String.Format("{0,-10} |{2,5}", "单词：" + dic.Key, 0, "频数：" + dic.Value));
                            Console.WriteLine(String.Format("{0,-10} |{2,5}", "单词：" + dic.Key, 0, "频数：" + dic.Value));
                        }

                    }
                }*/
                if (GetNum != null)//将输出指定数量的单词数，并写入文件
                {
                    int i = 0;
                    Dictionary<string, int> dictionary = count.CountFrequency(path);
                    dictionary = count.SortDictionary_Desc(dictionary);
                    //sw.WriteLine("前" + GetNum + "频数的单词如下：");
                    //Console.WriteLine("前" + GetNum + "频数的单词如下：");
                    foreach (KeyValuePair<string, int> dic in dictionary)
                    {
                        sw.WriteLine(String.Format("{0,-10} |{2,5}",   dic.Key, 0,  dic.Value));
                        Console.WriteLine(String.Format("{0,-10} |{2,5}",  dic.Key, 0,  dic.Value));

                        i++;
                        if (i == int.Parse(GetNum))
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("路径为空，请输入文件路径");
            }
            if (sw != null)
            {
                sw.Flush();
                sw.Close();
            }
        }
    }
}
