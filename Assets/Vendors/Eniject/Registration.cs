using System;

namespace Enigmatic.Experimental.Eniject
{
    internal sealed class Registration
    {
        public Func<object> Factory { get; private set; }
        public bool IsSingle { get; private set; }
        public object Instance { get; set; }

        public Registration(Func<object> factory, bool isSingle, object instance)
        {
            Factory = factory;
            IsSingle = isSingle;
            Instance = instance;
        }
    }
}