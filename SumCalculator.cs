using System;

namespace MultithreadProject
{
    public static class SumCalculator
    {
        public static long SumClassic(List<long> array)
        {
            long n = 0;
            for (int i = 0; i < array.Count; i++)
            {
                n += array[i];
            }
            return n;
        }

        public static async Task<long> SumMultithreadAsync(List<long> array)
        {
            Task<long> t0 = Task.Run(() => Compute(0, 6, array.Count));
            Task<long> t1 = Task.Run(() => Compute(1, 6, array.Count));
            Task<long> t2 = Task.Run(() => Compute(2, 6, array.Count));
            Task<long> t3 = Task.Run(() => Compute(3, 6, array.Count));
            Task<long> t4 = Task.Run(() => Compute(4, 6, array.Count));
            Task<long> t5 = Task.Run(() => Compute(5, 6, array.Count));
            Task.WaitAll();
            long result = t0.Result + t1.Result + t2.Result + t3.Result + t4.Result + t5.Result;
            return result;
        }

        public static long SumLINQ(List<long> array)
        {
            return array.AsParallel().Sum();
        }

        public static long Compute(int start, int step, long limit)
        {
            long sum = 0;
            for (long n = start; n < limit; n += step)
                sum += n;
            return sum;
        }
    }
}
