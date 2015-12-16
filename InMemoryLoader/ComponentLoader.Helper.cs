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
	/// <summary>
	/// Component loader.
	/// </summary>
	public partial class ComponentLoader
	{
		/// <summary>
		/// Classes the exists.
		/// </summary>
		/// <returns><c>true</c>, if exists was classed, <c>false</c> otherwise.</returns>
		/// <param name="paramClassName">Parameter class name.</param>
		public bool ClassExists (string paramClassName)
		{
			var value = this.ClassReferences.Where (cls => cls.Value.ClassType.Name.Contains (paramClassName)).FirstOrDefault ();

			if (!string.IsNullOrEmpty (value.Key)) {
				return true;
			} else {
				return false;
			}
		}
	}
}

