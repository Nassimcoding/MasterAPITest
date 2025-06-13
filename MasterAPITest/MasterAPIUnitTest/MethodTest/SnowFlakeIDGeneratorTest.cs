using System;
using System.Reflection;
using System.Threading;
using Xunit;
using MasterAPITest.Models;

namespace MasterAPIUnitTest.MethodTest
{
    public class SnowFlakeIDGeneratorTest
    {

        [Fact]
        public void CreateId_ShouldReturnUniqueValues_WhenCalledConsecutively()
        {
            var gen = new SnowFlakeIDGenerator(machineId: 1);

            long id1 = gen.CreateId();
            long id2 = gen.CreateId();

            Assert.NotEqual(id1, id2);
        }

        [Fact]
        public void CreateId_ShouldBeDifference_ByMachineNumber()
        {
            var gen = new SnowFlakeIDGenerator(machineId: 1);
            var gen2 = new SnowFlakeIDGenerator(machineId: 2);

            long id1 = gen.CreateId();
            long id2 = gen2.CreateId();

            Assert.NotEqual(id1, id2);
        }

        //[Fact]
        //public void CreateId_ShouldThrowIfClockMovesBackwards()
        //{
        //    var gen = new SnowFlakeIDGenerator(machineId: 1);

        //    // 先呼叫一次，設定 _lastTimestamp
        //    long initial = gen.CreateId();

        //    // 透過反射把 _lastTimestamp 設到未來，模擬時鐘回撥
        //    var lastTimestampField = typeof(SnowFlakeIDGenerator)
        //        .GetField("_lastTimestamp", BindingFlags.NonPublic | BindingFlags.Instance);
        //    long future = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + 1000;
        //    lastTimestampField.SetValue(gen, future);

        //    var ex = Assert.Throws<InvalidOperationException>(() => gen.CreateId());
        //    Assert.Contains("Clock moved backwards", ex.Message);
        //}

        [Fact]
        public void CreateId_ShouldWaitNextMillis_WhenSequenceOverflows()
        {
            var gen = new SnowFlakeIDGenerator(machineId: 2);

            // 初始化一次
            gen.CreateId();

            // 把 _lastTimestamp 固定在同一毫秒，並把 _sequence 設為最大
            var tsField = typeof(SnowFlakeIDGenerator)
                .GetField("_lastTimestamp", BindingFlags.NonPublic | BindingFlags.Instance);
            var seqField = typeof(SnowFlakeIDGenerator)
                .GetField("_sequence", BindingFlags.NonPublic | BindingFlags.Instance);

            long lastTs = (long)tsField.GetValue(gen);
            tsField.SetValue(gen, lastTs);
            // SequenceBits = 12, MaxSequence = 4095
            seqField.SetValue(gen, (long)((-1L ^ (-1L << 12))));

            // 下一個 ID 的 timestamp 部分至少要比 lastTs + 1 (毫秒) 大
            long newId = gen.CreateId();
            // 解碼 timestamp：((newId >> (SequenceBits + MachineIdBits)) + Twepoch)
            const int SequenceBits = 12, MachineIdBits = 9;
            const long Twepoch = 1577836800000L;
            long decodedTs = ((newId >> (SequenceBits + MachineIdBits)) + Twepoch);

            Assert.True(decodedTs >= lastTs + 1, "序號溢位後，應等到下一毫秒再繼續產生");
        }
    }
}



