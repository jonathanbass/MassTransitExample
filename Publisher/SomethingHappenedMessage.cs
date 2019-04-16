using System;
using Contracts;

namespace Publisher
{
    public class SomethingHappenedMessage : SomethingHappened
    {
        public DateTime Time { get ; set; }
        public string Observation { get; set; }
    }
}
