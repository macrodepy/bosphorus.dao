using System.Collections;
using System.Reflection;
using System.Runtime.ExceptionServices;
using Bosphorus.Dao.Client.ResultTransformer;

namespace Bosphorus.Dao.Client.Model
{
    public class MethodExecutionItem : IExecutionItem
    {
        private readonly AbstractMethodExecutionItemList instance;
        private readonly MethodInfo methodInfo;
        private readonly IResultTransformer resultTransformer;

        public MethodExecutionItem(AbstractMethodExecutionItemList instance, MethodInfo methodInfo, IResultTransformer resultTransformer)
        {
            this.instance = instance;
            this.methodInfo = methodInfo;
            this.resultTransformer = resultTransformer;
        }

        public IList Execute()
        {
            try
            {
                object value = methodInfo.Invoke(instance, new object[0]);
                IList result = resultTransformer.Transform(value);
                return result;
            }
            catch (TargetInvocationException exception)
            {
                ExceptionDispatchInfo innerExceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception.InnerException);
                innerExceptionDispatchInfo.Throw();
                return null;
            }
        }

        public override string ToString()
        {
            return methodInfo.Name;
        }
    }
}