using System.Data.Entity;using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AydinCompany.Core.Aspects.Postsharp.ExceptionAspects;
using AydinCompany.Core.Aspects.Postsharp.LogAspects;
using AydinCompany.Core.Aspects.Postsharp.PerformanceAspects;
using AydinCompany.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("AydinCompany.Northwind.Business")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("AydinCompany.Northwind.Business")]
[assembly: AssemblyCopyright("Copyright ©  2023")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: LogAspect(typeof(FileLogger), AttributeTargetTypes = "AydinCompany.Northwind.Business.Concrete.Manager.*")] //ilgili namespace'nin içindeki tüm Manager sınıflarına Loglama Aspect'ini uygular.
[assembly: LogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "AydinCompany.Northwind.Business.Concrete.Manager.*")] //ilgili namespace'nin içindeki tüm Manager sınıflarına Loglama Aspect'ini uygular.
[assembly: ExceptionLogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "AydinCompany.Northwind.Business.Concrete.Manager.*")]
[assembly: PerformanceCounterAspect(6, AttributeTargetTypes = "AydinCompany.Northwind.Business.Concrete.Manager.*")]


// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("bc5ef0c4-7af2-43e2-a0d7-1a770365a0f0")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
