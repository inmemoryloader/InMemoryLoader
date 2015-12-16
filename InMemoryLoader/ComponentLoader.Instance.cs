﻿using System;
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
		/// The log.
		/// </summary>
		private static ILog log = LogManager.GetLogger (typeof(ComponentLoader));
		/// <summary>
		/// The instance.
		/// </summary>
		private static volatile ComponentLoader instance;
		/// <summary>
		/// The sync root.
		/// </summary>
		private static object syncRoot = new Object ();
		/// <summary>
		/// The assembly references.
		/// </summary>
		public Hashtable AssemblyReferences = new Hashtable ();
		/// <summary>
		/// The class references.
		/// </summary>
		public IDictionary<string, IDynamicClassInfo> ClassReferences;
		/// <summary>
		/// The component registry.
		/// </summary>
		public IDictionary<IDynamicClassSetup, IDynamicClassInfo> ComponentRegistry;

		/// <summary>
		/// Initializes a new instance of the <see cref="InMemoryLoader.InMemoryLoader"/> class.
		/// </summary>
		private ComponentLoader ()
		{
			if (ClassReferences == null) {
				ClassReferences = new Dictionary<string, IDynamicClassInfo> ();
			}
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static ComponentLoader Instance {
			get {
				if (instance == null) {
					lock (syncRoot) {
						if (instance == null) {							
							instance = new ComponentLoader ();
							log.DebugFormat ("Create a new instance of Type: {0}", instance.GetType ().ToString ());
						}
					}
				}

				return instance;
			}
		}
	}
}

