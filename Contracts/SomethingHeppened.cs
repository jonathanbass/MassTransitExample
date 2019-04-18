using System;

namespace Contracts
{
    public interface ISomethingHappened
    {
        DateTime Time { get; set; }
        string Observation { get; set; }
    }
}
