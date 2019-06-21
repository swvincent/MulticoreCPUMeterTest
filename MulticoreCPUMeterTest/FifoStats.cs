using System;
using System.Collections.Generic;
using System.Linq;

namespace MulticoreCPUMeterTest
{
    class FifoStats
    {
        public int MaxStats { get; }
        public Queue<float> Stats { get; }

        public int Count
        {
            get { return Stats.Count; }
        }

        public FifoStats(int maxStats)
        {
            if (maxStats <= 0)
                throw new ArgumentOutOfRangeException("maxStats",
                    "Max Stats must be greater than 0.");

            MaxStats = maxStats;
            Stats = new Queue<float>();
        }

        public void Enqueue(float item)
        {
            Stats.Enqueue(item);

            if (Stats.Count > MaxStats)
                Stats.Dequeue();
        }

        public float Sum()
        {
            return Stats.Sum();
        }

        public float Average()
        {
            if (Stats.Any())
                return Stats.Sum() / Stats.Count;
            else
                return 0;
        }

        public float Min()
        {
            return Stats.Min();
        }

        public float Max()
        {
            return Stats.Max();
        }

        public float Spread()
        {
            return Stats.Max() - Stats.Min();
        }
    }
}
