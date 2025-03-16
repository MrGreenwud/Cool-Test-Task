using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Enigmatic.Experimental.Eniject
{
    [DefaultExecutionOrder(-999)]
    public sealed class SceneContainer : MonoBehaviour
    {
        [SerializeField] private List<SceneInstaller> m_Installers;

        private Dictionary<(string, Type), Registration> m_Registrations = new Dictionary<(string, Type), Registration>();
        private HashSet<(string, Type)> m_Resolution = new HashSet<(string, Type)>();

        private void Awake()
        {
            GlobalContainer.AddContainer(this);

            foreach (SceneInstaller installer in m_Installers)
                installer.Install(this);
        }

        private void OnDestroy()
        {
            GlobalContainer.RemoveContainer(this);
        }

        public void RegisterSingle<T>(string tag, Func<object> factory)
        {
            Register<T>(tag, factory, true, null);
        }
        public void RegisterSingle<T>(Func<object> factory)
        {
            Register<T>(null, factory, true, null);
        }

        public void RegisterTransient<T>(string tag, Func<object> factory)
        {
            Register<T>(tag, factory, false, null);
        }
        public void RegisterTransient<T>(Func<object> factory)
        {
            Register<T>(null, factory, false, null);
        }

        public void RegisterInstance<T>(string tag, Func<object> factory)
        {
            Register<T>(tag, factory, true, null);
        }
        public void RegisterInstance<T>(string tag, T instance)
        {
            Register<T>(tag, null, true, instance);
        }
        public void RegisterInstance<T>(T instance)
        {
            Register<T>(null, null, true, instance);
        }
        public void RegisterInstance<T>(Func<object> factory)
        {
            Register<T>(null, factory, true, null);
        }

        internal bool TryGet<T>(out T result, string tag = null)
        {
            (string, Type) key = (tag, typeof(T));

            try
            {
                if (m_Resolution.Contains(key))
                    throw new Exception("Cycle Requirements");

                m_Resolution.Add(key);

                if (m_Registrations.TryGetValue(key, out Registration registration))
                {
                    if (registration.IsSingle)
                    {
                        if (registration.Instance == null)
                        {
                            if (registration.Factory != null)
                                registration.Instance = registration.Factory.Invoke();
                            else
                                throw new Exception("Factory is not found!");
                        }

                        result = (T)registration.Instance;
                        return true;
                    }

                    result = (T)registration.Factory();
                    return true;
                }

                result = default;
                return false;
            }
            finally
            {
                m_Resolution.Remove(key);
            }
        }

        internal void Register<T>(string tag, Func<object> factory, bool isSingle, object instance)
        {
            (string, Type) key = (tag, typeof(T));
            m_Registrations.Add(key, new Registration(factory, isSingle, instance));
        }
    }
}