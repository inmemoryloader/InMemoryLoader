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
		/// Gets the class reference.
		/// </summary>
		/// <returns>The class reference.</returns>
		/// <param name="AssemblyName">Assembly name.</param>
		/// <param name="ClassName">Class name.</param>
		public IDynamicClassInfo GetClassReference (string AssemblyName, string ClassName)
		{
			if (this.ClassReferences.ContainsKey (AssemblyName) == false) {

				Assembly assembly;

				if (this.AssemblyReferences.ContainsKey (AssemblyName) == false) {
					this.AssemblyReferences.Add (AssemblyName, assembly = Assembly.LoadFrom (AssemblyName));
				} else {
					assembly = (Assembly)this.AssemblyReferences [AssemblyName];
				}

				foreach (Type type in assembly.GetTypes()) {

					if (type.IsClass == true) {

						if (type.IsSubclassOf (typeof(AbstractPowerUpComponent))) {

							if (type.FullName.EndsWith ("." + ClassName)) {

								IDynamicClassInfo classInfo = new DynamicClassInfo (type, Activator.CreateInstance (type));
								this.ClassReferences.Add (AssemblyName, classInfo);
								return (classInfo);
							}
						} else {
							throw (new System.Exception ("Class is not typeof(AbstractPowerUpComponent)"));
						}
					}

				}

				throw (new System.Exception ("Could not instantiate Class"));
			}

			return ((DynamicClassInfo)this.ClassReferences [AssemblyName]);
		}

		/// <summary>
		/// Gets the class reference.
		/// </summary>
		/// <returns>The class reference.</returns>
		/// <param name="paramClassName">Parameter class name.</param>
		public IDynamicClassInfo GetClassReference (string paramClassName)
		{
			var value = this.ClassReferences.Where (cls => cls.Value.ClassType.Name.Contains (paramClassName)).FirstOrDefault ();

			if (!string.IsNullOrEmpty (value.Key)) {
				return value.Value;
			} else {
				return null;
			}
		}
	}
}

