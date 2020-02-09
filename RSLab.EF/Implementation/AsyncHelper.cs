using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyLibrary.EntityFramework.Implementation
{
    internal static class AsyncHelper
    {
        private static readonly TaskFactory _taskFactory = new
        TaskFactory(CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

        internal static TResult RunSync<TResult>(Func<Task<TResult>> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        internal static void RunSync(Func<Task> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }
}