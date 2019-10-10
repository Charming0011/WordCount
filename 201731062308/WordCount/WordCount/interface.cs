using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public interface Process 
    {
        int CountChar(string Fpath);//统计总字符
        int CountWord(string Fpath);//统计单词数
        int CountLine(string Fpath);//统计行数
        Dictionary<string, int> CountFrequency(string path);//统计词频
        Dictionary<string, int> SortDictionary_Desc(Dictionary<string, int> dic);//进行排序
        void ToFile(string Fpath, string Outpath);//写入文件
    };
}
