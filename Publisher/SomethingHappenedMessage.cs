using System;
using Contracts;

namespace Publisher
{
    public class SomethingHappenedMessage : ISomethingHappened
    {
        public DateTime Time { get ; set; }
        public string Observation { get; set; }
    }
}
