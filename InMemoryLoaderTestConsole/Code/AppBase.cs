﻿using System;
using InMemoryLoader;
using log4net;

namespace InMemoryLoaderTestConsole
{
	internal class AppBase
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(AppBase));
		/// <summary>
		/// The instance.
		/// </summary>
		private static volatile AppBase instance;
		/// <summary>
		/// The sync root.
		/// </summary>
		private static object syncRoot = new Object ();

		/// <summary>
		/// Gets or sets the component loader.
		/// </summary>
		/// <value>The component loader.</value>
		public ComponentLoader ComponentLoader { 
			get;
			set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:InMemoryLoaderTestConsole.AppBase"/> class.
		/// </summary>
		private AppBase ()
		{
			log4net.Config.XmlConfigurator.Configure ();
			ComponentLoader = ComponentLoader.Instance;
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static AppBase Instance {
			get {
				if (instance == null) {
					lock (syncRoot) {
						if (instance == null) {							
							instance = new AppBase ();
							log.DebugFormat ("Create a new instance of Type: {0}", instance.GetType ().ToString ());
						}
					}
				}

				return instance;
			}
		}
	}
}