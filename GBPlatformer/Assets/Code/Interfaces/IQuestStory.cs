using System;

namespace GBPlatformer
{
    public interface IQuestStory : IDisposable
    {
        bool IsDone { get; }
    }
}