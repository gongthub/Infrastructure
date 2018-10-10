using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Test.BenchmarkDotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var boKar = BenchmarkRunner.Run<TestBen>();
            //var summary = BenchmarkRunner.Run<Md5VsSha256>();
            //var summary = BenchmarkRunner.Run<Md5VsSha256_2>();
            //Console.WriteLine(boKar);
            //Console.WriteLine(summary);
            Console.ReadKey();
        }
    }

    public class TestBen {

        [Benchmark]
        public void TestOne()
        {
            List<string> lsStrs = new List<string>();

            for (int i = 0; i < 100000; i++)
            {
                lsStrs.Add(i.ToString());
            }
        }
    }
    public class Md5VsSha256
    {
        private const int N = 10000;
        private readonly byte[] data;

        private readonly SHA256 sha256 = SHA256.Create();
        private readonly MD5 md5 = MD5.Create();

        public Md5VsSha256()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Sha256()
        {
            return sha256.ComputeHash(data);
        }

        [Benchmark]
        public byte[] Md5()
        {
            return md5.ComputeHash(data);
        }
    }
    [ClrJob(baseline: true), CoreJob, MonoJob, CoreRtJob]
    [RPlotExporter, RankColumn]
    public class Md5VsSha256_2
    {
        private SHA256 sha256 = SHA256.Create();
        private MD5 md5 = MD5.Create();
        private byte[] data;

        [Params(1000, 10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Sha256() => sha256.ComputeHash(data);

        [Benchmark]
        public byte[] Md5() => md5.ComputeHash(data);
    }

}
