namespace ShippinRate.Infrastructure
{
    public static class LinqExtensions
    {
        public static async IAsyncEnumerable<TResult> WhenEach<TResult>(Task<TResult>[] tasks)
        {
            foreach (var task in Interleaved(tasks))
            {
                var t = await task;
                yield return await t;
            }
        }

        public static async IAsyncEnumerable<TResult> WhenEach<TResult>(IEnumerable<Task<TResult>> tasks)
        {
            foreach (var task in Interleaved(tasks))
            {
                var t = await task;
                yield return await t;
            }
        }

        public static Task<Task<T>>[] Interleaved<T>(IEnumerable<Task<T>> tasks)
        {
            var inputTasks = tasks.ToList();
            var buckets = new TaskCompletionSource<Task<T>>[inputTasks.Count];
            var result = new Task<Task<T>>[buckets.Length];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new TaskCompletionSource<Task<T>>();
                result[i] = buckets[i].Task;
            }

            int nextTaskIndex = -1;
            Action<Task<T>> continuation = completed => { 
                var bucket = buckets[Interlocked.Increment(ref nextTaskIndex)];
                bucket.TrySetResult(completed);
            };
            foreach (var inputTask in inputTasks)
                inputTask.ContinueWith(continuation, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
            
            return result;
        }
    }
}
