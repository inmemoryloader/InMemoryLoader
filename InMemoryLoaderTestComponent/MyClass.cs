using System;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoaderTestComponent
{
	public class MyClass : AbstractPowerUpComponent
	{
		private static readonly ILog log = LogManager.GetLogger (typeof(MyClass));

		public MyClass ()
		{
			log.DebugFormat ("Create a new instance of Type: {0}", this.GetType ().ToString ());
		}

		public int MultiplyTwoInt (int paramOne, int paramTwo)
		{
			return paramOne * paramTwo;
		}

		public int MultiplyThreeInt (int paramOne, int paramTwo, int paramThree)
		{
			return paramOne * paramTwo * paramThree;
		}
	}
}

