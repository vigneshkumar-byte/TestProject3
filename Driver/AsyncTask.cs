using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestProject3.Driver
{
    public class AsyncTask<T>:Lazy<Task<T>>
    {
        public AsyncTask(Func<Task<T>>taskFactory):base(()=>Task.Factory.StartNew(taskFactory).Unwrap())
        {
            
        }
        public TaskAwaiter<T>GetAwaiter()
        {
            return Value.GetAwaiter();
        }
    }
}
