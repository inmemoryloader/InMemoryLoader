using System;
using InMemoryLoader;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoaderTestConsole
{
	/// <summary>
	/// Main class.
	/// </summary>
	class MainClass
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger (typeof(MainClass));
		/// <summary>
		/// The app base.
		/// </summary>
		private static AppBase appBase = AppBase.Instance;


		/// <summary>
		/// The test component path.
		/// </summary>

		// Linux Mono Environment
		// private const string testComponentPath = "/home/kaysta/github.com/InMemoryLoader/InMemoryLoaderTestComponent/bin/Debug/InMemoryLoaderTestComponent.dll";

		// Windows Environment
		private const string testComponentPath = @"C:\Users\kayst\OneDrive\Development\github\InMemoryLoader\InMemoryLoaderTestComponent\bin\Debug\InMemoryLoaderTestComponent.dll";

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main (string[] args)
		{
			log.InfoFormat ("{0}", "Start InMemoryLoaderTestConsole");
			log.InfoFormat ("{0}", "--------------------------------------------------------------------------------");

			log.DebugFormat ("{0}", "Setup DynamicClassSetup");

			// Setup the TestComponent Class
			IDynamicClassSetup setup = new DynamicClassSetup ();
			setup.Assembly = testComponentPath;
			setup.Class = "MyClass";
			object[] paramInit = { AbstractPowerUpComponent.Key };

			// Initialize the Loader and TestComponent
			log.DebugFormat ("{0}", "InitComponent");
			appBase.ComponentLoader.InitComponent (setup, paramInit);

			// Initialize the Component Registry
			log.DebugFormat ("{0}", "InitClassRegistry");
			appBase.ComponentLoader.InitClassRegistry ();

			// Get the Class Reference for MyClass
			log.DebugFormat ("{0}", "GetClassReference");
			var testComponent = appBase.ComponentLoader.GetClassReference ("MyClass");

			// Invoke the Method MultiplyTwoInt
			log.DebugFormat ("{0}", "InvokeMethod");
			object[] paramArgument = { 8, 19 };
			var retResult = appBase.ComponentLoader.InvokeMethod (testComponent, "MultiplyTwoInt", paramArgument);

			// Print the Result
			log.InfoFormat ("Result: {0}", retResult);

			Console.ReadKey ();
		}
	}
}
