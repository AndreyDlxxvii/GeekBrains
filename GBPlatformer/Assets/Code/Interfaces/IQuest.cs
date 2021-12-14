using System;

namespace GBPlatformer
{
    public interface IQuest : IDisposable
    {
        event EventHandler<IQuest> Completed; 
        bool IsCompleted { get; }
        void Reset();
    }
}