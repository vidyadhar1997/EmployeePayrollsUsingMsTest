using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePyrolls
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee payroll using thread = ");
            string[] words = CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");
            #region ParallelTasks
            Parallel.Invoke(() =>
            {
                Console.WriteLine("Being first task");
                GetLongestWord(words);
            },
            () =>
            {
                GetMostCommonWords(words);
            },
            () =>
            {
                GetCountForWord(words, "sleep");
            }
            );

            #endregion
        }

        private static void GetCountForWord(string[] words, string term)
        {
           var findWord= from word in words
            where word.ToUpper().Contains(term.ToUpper())
            select word;
            Console.WriteLine($"Task 3 ----------the word ''''{term}'''' occors { findWord.Count()} times.");
        }

        private static void GetMostCommonWords(string[] words)
        {
          var frequencyOrder= from word in words where word.Length > 6 group word by word into g orderby g.Count() descending select g.Key;
            var commonWords = frequencyOrder.Take(30);
            StringBuilder sb = new StringBuilder();
            sb.Append("Task 2---The most common word are");
            foreach (var  v in commonWords)
            {
                sb.AppendLine(" " + v);

            }
            Console.WriteLine(sb.ToString());
        }
        private static string GetLongestWord(string[] words)
        {
           var longestWord= (from w in words orderby w.Length descending select w).First();
            Console.WriteLine($"Task 1 ----The longest word is { longestWord}");
            return longestWord;
        }

        static string[] CreateWordArray(string url)
        {
            Console.WriteLine($"Retriving from{url}");
          string blog=  new WebClient().DownloadString(url);
            return blog.Split(
                new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '_', '/' },
                StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
