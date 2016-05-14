using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace W2Open.GameState.Plugin
{
    public static class PluginController
    {
        public static List<IGameStatePlugin> ActivatedPlugins;

        static PluginController()
        {
            ActivatedPlugins = new List<IGameStatePlugin>();
        }

        /// <summary>
        /// Automatically iterate in all created plugins and call their Install method.
        /// </summary>
        public static void InstallPlugins()
        {
            string pluginInterfaceName = typeof(IGameStatePlugin).Name;
            
            IEnumerable<Type> pluginTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(IGameStatePlugin).IsAssignableFrom(t) && t.Name != pluginInterfaceName);

            Queue<IGameStatePlugin> defaultPlugins = new Queue<IGameStatePlugin>();
            Queue<IGameStatePlugin> otherPlugins = new Queue<IGameStatePlugin>();

            string defaultPlayerRequestPluginNS = nameof(W2Open.GameState.Plugin.DefaultPlayerRequestHandler);
            string defaultTickCountPluginNS = nameof(W2Open.GameState.Plugin.DefaultTickCountHandler);

            // Read all types in this assembly and enqueue them into default or other plugin queues.
            foreach (Type thisPlugin in pluginTypes)
            {
                IGameStatePlugin pluginObj = (IGameStatePlugin)Activator.CreateInstance(thisPlugin);

                if (pluginObj == null)
                    continue;

                if (thisPlugin.Namespace == defaultPlayerRequestPluginNS ||
                    thisPlugin.Namespace == defaultTickCountPluginNS)
                {
                    defaultPlugins.Enqueue(pluginObj);
                }
                else
                {
                    otherPlugins.Enqueue(pluginObj);
                }
            }

            // Install the default plugins firstly.
            foreach (IGameStatePlugin thisPlugin in defaultPlugins)
            {
                thisPlugin.Install();
                ActivatedPlugins.Add(thisPlugin);
            }

            // Then install the other plugins.
            foreach (IGameStatePlugin thisPlugin in otherPlugins)
            {
                thisPlugin.Install();
                ActivatedPlugins.Add(thisPlugin);
            }
        }
    }
}