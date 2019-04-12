using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDSBenchMarking
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeBuilder tb = new TreeBuilder();
            Node root = tb.CreateTree(11, 0);
            Console.WriteLine("BFS Runs: \nMean (ns) \tStandard Deviation");
            string bfsText = "BFS Runs: Mean (ns) \tStandard Deviation";
            System.IO.File.WriteAllText(@"C:\Users\purke\Desktop\IPC\BFSTestRuns.txt", bfsText);
            for (int i = 0; i < 30; i++)
            {
                BenchmarkBFS(root, 10_000);
            }
            Console.WriteLine("DFS Runs: \nMean (ns) \tStandardDeviation");
            string dfsText = "DFS Runs: Mean (ns) \tStandard Deviation";
            System.IO.File.WriteAllText(@"C:\Users\purke\Desktop\IPC\DFSTestRuns.txt", dfsText);
            for (int i = 0; i < 30; i++)
            {
                BenchmarkDFS(root, 10_000);
            }

            Console.WriteLine("~~~~~Done~~~~~");
            SystemInfo();

            Console.Read();
        }

        public static double BenchmarkBFS(Node root, int noOfRuns)
        {
            BreadthFirstSearch bfs = new BreadthFirstSearch();
            int n = 10;
            int count = noOfRuns;
            double dummy = 0.0;
            double st = 0.0, sst = 0.0;
            for (int j = 0; j < n; j++)
            {
                Timer t = new Timer();
                for (int i = 0; i < count; i++)
                    dummy += bfs.IterativeSearch(root, true);
                double time = t.Check() * 1e9 / count;
                st += time;
                sst += time * time;
            }
            double mean = st / n, sdev = Math.Sqrt((sst - mean * mean * n) / (n - 1));
            string meanStr = mean.ToString("#.0");
            string stdevStr = sdev.ToString("#.000");
            Console.WriteLine(meanStr + "\t\t" + stdevStr);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\purke\Desktop\IPC\BFSTestRuns.txt", true))
            {
                file.WriteLine(meanStr + "," + stdevStr);
            }
            return dummy / n;
        }

        public static double BenchmarkDFS(Node root, int noOfRuns)
        {
            DepthFirstSearch dfs = new DepthFirstSearch();
            int n = 10;
            int count = noOfRuns;
            double dummy = 0.0;
            double st = 0.0, sst = 0.0;
            for (int j = 0; j < n; j++)
            {
                Timer t = new Timer();
                for (int i = 0; i < count; i++)
                    dfs.IterativeSearch(root, true);
                double time = t.Check() * 1e9 / count;
                st += time;
                sst += time * time;
            }
            double mean = st / n, sdev = Math.Sqrt((sst - mean * mean * n) / (n - 1));
            string meanStr = mean.ToString("#.0");
            string stdevStr = sdev.ToString("#.000");
            Console.WriteLine(meanStr + "\t\t" + stdevStr);
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\Users\purke\Desktop\IPC\DFSTestRuns.txt", true))
            {
                file.WriteLine(meanStr + "," + stdevStr);
            }
            return dummy / n;
        }

        public static double BenchmarkBFS(Node root)
        {
            int n = 10, count = 1, totalCount = 0;
            double dummy = 0.0, runningTime = 0.0, st = 0.0, sst = 0.0;
            Console.WriteLine("mark5");
            Console.WriteLine(" Mean\t\tSTD\t\tcount");
            do
            {
                BreadthFirstSearch bfs = new BreadthFirstSearch();
                count *= 2;
                st = sst = 0.0;
                for (int j = 0; j < n; j++)
                {
                    Timer t = new Timer();
                    for (int i = 0; i < count; i++)
                        dummy += bfs.IterativeSearch(root, true);
                    runningTime = t.Check();
                    double time = runningTime * 1e9 / count;
                    st += time;
                    sst += time * time;
                    totalCount += count;
                }
                double mean = st / n, sdev = Math.Sqrt((sst - mean * mean * n) / (n - 1));
                Console.Write(mean.ToString("#.0") + "\t\t" + sdev.ToString("#.000") + "\t\t" + count + "\n");
            } while (runningTime < 0.25 && count < Int32.MaxValue / 2);
            Console.WriteLine("BreadthFirstSearch - done");
            return dummy / totalCount;
        }

        public static double BenchmarkDFS(Node root)
        {
            int n = 10, count = 1, totalCount = 0;
            double dummy = 0.0, runningTime = 0.0, st = 0.0, sst = 0.0;
            Console.WriteLine("mark5");
            Console.WriteLine(" Mean\t\tSTD\t\tcount");
            do
            {
                DepthFirstSearch dfs = new DepthFirstSearch();
                count *= 2;
                st = sst = 0.0;
                for (int j = 0; j < n; j++)
                {
                    Timer t = new Timer();
                    for (int i = 0; i < count; i++)
                        dummy += dfs.IterativeSearch(root, true);
                    runningTime = t.Check();
                    double time = runningTime * 1e9 / count;
                    st += time;
                    sst += time * time;
                    totalCount += count;
                }
                double mean = st / n, sdev = Math.Sqrt((sst - mean * mean * n) / (n - 1));
                Console.Write(mean.ToString("#.0") + "\t\t" + sdev.ToString("#.000") + "\t\t" + count + "\n");
            } while (runningTime < 0.25 && count < Int32.MaxValue / 2);
            Console.WriteLine("DepthFirstSearch - done");
            return dummy / totalCount;
        }

        private static void SystemInfo()
        {
            Console.WriteLine("# OS          {0}", Environment.OSVersion.VersionString);
            Console.WriteLine("# .NET vers.  {0}", Environment.Version);
            Console.WriteLine("# 64-bit OS   {0}", Environment.Is64BitOperatingSystem);
            Console.WriteLine("# 64-bit proc {0}", Environment.Is64BitProcess);
            Console.WriteLine("# CPU         {0}; {1} \"procs\"", Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"), Environment.ProcessorCount);
            Console.WriteLine("# Date        {0:s}", DateTime.Now);
        }
    }
}
