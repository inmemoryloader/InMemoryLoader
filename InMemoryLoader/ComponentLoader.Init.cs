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
        /// Inits the class registry.
        /// </summary>
        /// <returns><c>true</c>, if class registry was inited, <c>false</c> otherwise.</returns>
        public bool InitClassRegistry()
        {
            if (ComponentRegistry == null)
            {
                ComponentRegistry = new Dictionary<IDynamicClassSetup, IDynamicClassInfo>();
            }

            foreach (var item in this.ClassReferences)
            {

                var dynclass = new DynamicClassSetup();
                dynclass.Assembly = item.Key;
                dynclass.Class = item.Value.ClassType.Name;

                var type = this.GetClassReference(dynclass.Class);

                if (ComponentRegistry.Keys.Where(ky => ky.Assembly.Contains(dynclass.Assembly)).Count() == 0)
                {
                    ComponentRegistry.Add(dynclass, type);
                    if (log.IsDebugEnabled)
                    {
                        log.DebugFormat("Add AssemblyName: {0}, ClassType.FullName: {1} to ComponentRegistry", dynclass.Assembly, dynclass.Class);
                    }
                }
            }

            if (log.IsDebugEnabled)
            {
                foreach (var item in ComponentRegistry)
                {
                    log.InfoFormat("ComponentRegistry contains AssemblyName: {0}, ClassType.FullName: {1}", item.Key.Assembly, item.Key.Class);
                }
            }

            return true;
        }

        /// <summary>
        /// Inits the component.
        /// </summary>
        /// <returns>The component.</returns>
        /// <param name="ClassSetup">Class setup.</param>
        /// <param name="paramArgs">Parameter arguments.</param>
        public Object InitComponent(IDynamicClassSetup ClassSetup, Object[] paramArgs)
        {
            try
            {
                var returnObject = this.InvokeMethod(ClassSetup.Assembly, ClassSetup.Class, ClassSetup.InitMethod, paramArgs);
                return returnObject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

