using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Core.CrossCuttingConcerns.Logging;
using AydinCompany.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace AydinCompany.Core.Aspects.Postsharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)] //sadece metotların ve sınıfların üzerinde uygulanabilir ancak constructor dahil olmaz. yani class instance'si hazırlandıktan sonra dahil olduğu için constructor dahil olmaz. çünkü nesne oluşurken constructor devreye giriyor oluştuktan sonra değil.
    public class LogAspect : OnMethodBoundaryAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;

        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
            
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof(LoggerService)) throw new Exception("Loglayıcı tipi doğru bir tip değil.");
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled) return; //info özelliği pasifse kestik. sağlamcı programlama.
            try
            {
                var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter()
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                }).ToList();
                var logDetail = new LogDetail()
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParameters
                };
                _loggerService.Info(logDetail);
                base.OnEntry(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
