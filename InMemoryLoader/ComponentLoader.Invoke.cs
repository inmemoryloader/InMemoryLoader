using System;
using System.Reflection;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Resources;
using System.Globalization;
using System.Linq;
using log4net;
using InMemoryLoaderBase;

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
		public dynamic InvokeMethod (IDynamicClassInfo ClassInfo, string MethodName, Object[] paramArgs)
		{
			try {
				var result = ClassInfo.ClassType.InvokeMember (MethodName, BindingFlags.Default | BindingFlags.InvokeMethod, null, ClassInfo.ClassObject, paramArgs);
				return (result);
			} catch (Exception ex) {
				throw ex;
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
		public dynamic InvokeMethod (string AssemblyName, string ClassName, string MethodName, Object[] paramArgs)
		{
			try {
				var classInfo = this.GetClassReference (AssemblyName, ClassName);
				var result = (this.InvokeMethod (classInfo, MethodName, paramArgs));
				return result;
			} catch (Exception ex) {
				throw ex;
			}
		}
	}
}

