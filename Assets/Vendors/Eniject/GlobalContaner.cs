using System;
using System.Collections.Generic;

namespace Enigmatic.Experimental.Eniject
{
    public static class GlobalContainer
    {
        private static List<SceneContainer> m_SceneContainers = new List<SceneContainer>();

        internal static void AddContainer(SceneContainer container)
        {
            m_SceneContainers.Add(container);
        }

        internal static void RemoveContainer(SceneContainer container)
        {
            m_SceneContainers.Remove(container);
        }

        public static T Get<T>(string tag = null)
        {
            T result = default;

            foreach(SceneContainer container in m_SceneContainers)
            {
                if(container.TryGet(out result, tag))
                    return result;
            }

            throw new Exception($"{typeof(T)}");
        }
    }
}
