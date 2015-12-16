using System;
using InMemoryLoader;
using log4net;

namespace InMemoryLoaderTestConsole
{
	internal class AppBase
	{
		private static readonly ILog log = LogManager.GetLogger (typeof(AppBase));
		private static volatile AppBase instance;
		private static object syncRoot = new Object ();

		public ComponentLoader ComponentLoader { 
			get;
			set;
		}

		private AppBase ()
		{
			log4net.Config.XmlConfigurator.Configure ();
			ComponentLoader = ComponentLoader.Instance;
		}

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

