using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpDrop
{
    public class Worker
    {
        internal static Dictionary<string, CancellationTokenSource> CancellationTokenMapping = new Dictionary<string, CancellationTokenSource>();
        internal static Dictionary<string, string> ErrorMapping = new Dictionary<string, string>();

        /// <summary>
        /// Run code per usual, whether it's a block of code or passing a method
        /// </summary>
        /// <param name="identifier">Used for Cancelling the code execution and retrieving and possible error</param>
        /// <param name="action"></param>
        public static void Run(string identifier, Action action)
        {
            if (action == null)
            {
                throw new ActionRequiredException("An action is required. Please provide");
            }

            if (string.IsNullOrEmpty(identifier))
            {
                throw new IdentifierRequiredException("An identifier is required. Please provide.");
            }

            var operation = new Operation(action);

            if (!Worker.ErrorMapping.ContainsKey(identifier))
            {
                Worker.ErrorMapping.Add(identifier, string.Empty);
            }

            var cancellationToken = new CancellationTokenSource();
            var token = cancellationToken.Token;

            if (Worker.CancellationTokenMapping.ContainsKey(identifier))
            {
                Worker.CancellationTokenMapping.Remove(identifier);
            }

            Worker.CancellationTokenMapping.Add(identifier, cancellationToken);

            bool isWorking = true;

            try
            {
                var task = new Task(() =>
                {
                    operation.DoWork();
                }, token);

                task.Start();

                while (isWorking)
                {
                    if (token.IsCancellationRequested || task.IsCanceled || task.IsCompleted || task.IsFaulted)
                    {
                        Worker.ErrorMapping[identifier] = task.Exception.Message;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Worker.ErrorMapping[identifier] = ex.Message;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public static void Cancel(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                return;
            }

            var cancellationToken = Worker.CancellationTokenMapping[identifier];
            if (cancellationToken != null)
            {
                cancellationToken.Cancel();
            }
        }

        public static string GetError(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                return string.Empty;
            }

            return Worker.ErrorMapping[identifier];
        }
    }
}
