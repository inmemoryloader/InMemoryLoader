using InMemoryLoaderBase;
using System;
using System.Reflection;

namespace InMemoryLoader
{
	public partial class ComponentLoader
	{
		/// <summary>
		/// Invokes the method.
		/// </summary>
		/// <returns>The method.</returns>
		/// <param name="ClassInfo">Class info.</param>
		/// <param name="MethodName">Method name.</param>
		/// <param name="paramArgs">Parameter arguments.</param>
		public dynamic InvokeMethod(IDynamicClassInfo ClassInfo, string MethodName, Object[] paramArgs)
		{
			try
			{
				var result = ClassInfo.ClassType.InvokeMember(MethodName, BindingFlags.Default | BindingFlags.InvokeMethod, null, ClassInfo.ClassObject, paramArgs);
				return (result);
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Invokes the method.
		/// </summary>
		/// <returns>The method.</returns>
		/// <param name="AssemblyName">Assembly name.</param>
		/// <param name="ClassName">Class name.</param>
		/// <param name="MethodName">Method name.</param>
		/// <param name="paramArgs">Parameter arguments.</param>
		public dynamic InvokeMethod(string AssemblyName, string ClassName, string MethodName, Object[] paramArgs)
		{
			try
			{
				var classInfo = this.GetClassReference(AssemblyName, ClassName);
				var result = (this.InvokeMethod(classInfo, MethodName, paramArgs));
				return result;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}