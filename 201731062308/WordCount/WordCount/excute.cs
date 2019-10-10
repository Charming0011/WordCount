using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;



namespace WordCount
{
    public class excute : Process //具体执行相关事务的类
    {
        public int CountChar(string Fpath)
        {
            StreamReader sr = new StreamReader(Fpath);//在自定义path路径创建读文件流
            string s;
            char[] charArray;
            int CountChar = 0;
            while ((s = sr.ReadLine()) != null)
            {
                charArray = s.ToCharArray();//将读取的每一行送入char数组中
                for (int j = 0; j < charArray.Length; j++)
                {
                    CountChar++;//计算每一个字符
                }
            }
            return CountChar;//返回有多少个字符
        }

        public int CountLine(string Fpath)
        {
            //throw new NotImplementedException();
            StreamReader sr = new StreamReader(Fpath);//创建读文件流
            string s;
            int line = 0;
            while ((s = sr.ReadLine()) != null)//读取文件总行数
            {
                line++;
            }
            return line;//返回行数
        }

        public int CountWord(string Fpath)
        {
            //throw new NotImplementedException();
            excute doCount = new excute();
            Dictionary<string, int> dictionary = CountFrequency(Fpath);
            int CountWord = 0;
            foreach (KeyValuePair<string, int> dic in dictionary)//遍历字典里面的每一个单词，结果为总单词数
            {
                CountWord += dic.Value;
            }
            return CountWord;
        }
        public Dictionary<string, int> CountFrequency(string Fpath)//计算每个单词的频数，结果传入字典并返回,字典中的key是单词的值，value是单词的频数
        {
            StreamReader sr = new StreamReader(Fpath);//在自定义path路径创建读文件流
            string s;
            Dictionary<string, int> fre = new Dictionary<string, int>();
            while ((s = sr.ReadLine()) != null)//读取文件的每一行到字符串s
            {
                string[] words = Regex.Split(s, " ");//将字符串s按空格分割，即划分每一个单词
                // string[] words = Regex.Split(s,@"\W+");
                foreach (string word in words)//计算每行各个单词数
                {
                    if (fre.ContainsKey(word))//判断字典是否包含该单词，若包含，该单词频数加一，若不包含，将该单词添加到字典
                    {
                        fre[word]++;
                    }
                    else
                    {
                        fre[word] = 1;
                    }
                }
            }
            return fre;
        }

        public Dictionary<string, int> SortDictionary_Desc(Dictionary<string, int> dic)
        {
            //throw new NotImplementedException();
            List<KeyValuePair<string, int>> myList = new List<KeyValuePair<string, int>>(dic);
            myList.Sort(delegate (KeyValuePair<string, int> s1, KeyValuePair<string, int> s2)//按value比较两个单词，并按value大小排序
            {
                return s2.Value.CompareTo(s1.Value);
            });
            dic.Clear();
            foreach (KeyValuePair<string, int> pair in myList)//遍历整个字典，并按value值为字典排序
            {
                if (pair.Key != null && pair.Key != ":" && pair.Key != "," && pair.Key != ".")
                    dic.Add(pair.Key, pair.Value);
            }
            return dic;
        }

        public void ToFile(string Fpath, string Outpath)
        {
            //throw new NotImplementedException();
            excute doCount = new excute();
            int countword = doCount.CountWord(Fpath);//调用计算总单词数方法，结果保存在countword
            int countchar = doCount.CountChar(Fpath);//调用计算总字符数方法，结果保存在countchar
            int countline = doCount.CountLine(Fpath);//调用计算行数方法，结果保存在countline
            StreamWriter sw = null;
            Dictionary<string, int> a = doCount.SortDictionary_Desc(doCount.CountFrequency(Fpath));//调用计算频数并排序的方法，将结果保存到dictionary字典中
            if (Outpath == null)
            {
                //sw = new StreamWriter(@"");//在默认路径创建写文件流
                Console.WriteLine("请指定输出路径");
            }
            if (Outpath != null)
            {
                sw = new StreamWriter(Outpath);//在自定义path路径创建写文件流
            }
            Console.SetOut(sw);//结果写入文件
            Console.WriteLine("characters：" + countchar);
            Console.WriteLine("words：" + countword);
            Console.WriteLine("lines：" + countline);
            Console.WriteLine("Fre：");
            foreach (KeyValuePair<string, int> pair in a)//遍历a字典里面的每一条信息
            {
                string key = pair.Key;
                int value = pair.Value;
                Console.WriteLine("{0}  {1}", key, value);
            }
            sw.Flush();
            sw.Close();
        }
    }
}
