using MasterAPITest.IModels;
using Microsoft.AspNetCore.Mvc;

namespace MasterAPITest.Models
{
    public class  GlobalState : IGlobalState
    {
        public static long Serise { get; set; } = 0;

        public static long Increment()
        {
            return Serise++;
        }

        public static long TurnZero()
        {
            return Serise = 0;
        }

    }
}
