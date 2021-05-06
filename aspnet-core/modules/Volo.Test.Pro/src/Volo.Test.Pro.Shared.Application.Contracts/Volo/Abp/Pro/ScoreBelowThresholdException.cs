using System;
using Volo.Abp;

namespace Volo.Test.Pro
{
    [Serializable]
    public class ScoreBelowThresholdException : UserFriendlyException
    {
        public ScoreBelowThresholdException(string message)
            : base(message)
        {
        }
    }
}
