using System.Diagnostics;
using Xunit;

namespace GridTariffApi.Tests
{
    /// <summary>
    /// To be used for marking manual ad hoc integration tests that should only be run if enabled by the developer.
    /// </summary>
    public class DeveloperAdHocFactSkippedUnlessDebuggingAttribute : FactAttribute
    {
        public DeveloperAdHocFactSkippedUnlessDebuggingAttribute()
        {
            if (!Debugger.IsAttached)
            {
                Skip = "Denne testen brukes til ad-hoc-kjøring av utviklere (skippes med mindre man kjører \"Debug\" på testen).";
            }
        }
    }
}
