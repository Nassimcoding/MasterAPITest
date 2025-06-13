using MasterAPITest.IModels;
using System;
using System.Threading;

namespace MasterAPITest.Models
{
    public class SnowFlakeIDGenerator : ISnowFlakeIDGenerator
    {
        // sign 1 bit, timestamp 42 bit, machineIDbit 9 bit, sequencebit 12 bit
        private const long Twepoch = 1577836800000L; // 2020-01-01 UTC 起算
        private const int MachineIdBits = 9;
        private const int SequenceBits = 12;
        private const long MaxMachineId = -1L ^ (-1L << MachineIdBits); // 511
        private const long MaxSequence = -1L ^ (-1L << SequenceBits);   // 4095
        private const int MachineIdShift = SequenceBits;
        private const int TimestampLeftShift = SequenceBits + MachineIdBits;

        private long _lastTimestamp = -1L;
        private long _sequence = 0L;
        private readonly long _machineId;
        private readonly object _lock = new object();

        public SnowFlakeIDGenerator(long machineId)
        {
            if (machineId < 0 || machineId > MaxMachineId)
                throw new ArgumentException($"Machine ID must be between 0 and {MaxMachineId}");
            _machineId = machineId;
        }

        public long CreateId()
        {
            lock (_lock)
            {
                long timestamp = GetCurrentTimeMillis();
                // prevent time manul or accident change 
                //if (timestamp < _lastTimestamp)
                //    throw new InvalidOperationException("Clock moved backwards. Refusing to generate ID.");

                if (timestamp == _lastTimestamp)
                {
                    _sequence = (_sequence + 1) & MaxSequence;
                    if (_sequence == 0)
                    {
                        timestamp = WaitNextMillis(_lastTimestamp);
                    }
                }
                else
                {
                    _sequence = 0;
                }

                _lastTimestamp = timestamp;

                return ((timestamp - Twepoch) << TimestampLeftShift)
                       | (_machineId << MachineIdShift)
                       | _sequence;
            }
        }
        // check current timestamp is bigger then last timestamp
        // if not bigger, id wait one millisecond
        // and assign new timestamp to curren timestamp
        private long WaitNextMillis(long lastTimestamp)
        {
            long timestamp = GetCurrentTimeMillis();
            while (timestamp <= lastTimestamp)
            {
                Thread.SpinWait(10);
                timestamp = GetCurrentTimeMillis();
            }
            return timestamp;
        }
        // get curren timestamp
        private long GetCurrentTimeMillis()
            => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }


}
