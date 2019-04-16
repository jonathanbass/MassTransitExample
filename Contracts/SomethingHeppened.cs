using System;

namespace Contracts
{
    public interface SomethingHappened
    {
        DateTime Time { get; set; }
        string Observation { get; set; }
    }
}
