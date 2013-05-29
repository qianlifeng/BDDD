using System;
using BDDD.Config;
using BDDD.ObjectContainer;

namespace BDDD.Application
{
    public class AppInitEventArgs : EventArgs
    {
        public AppInitEventArgs()
            : this(null, null)
        {
        }

        public AppInitEventArgs(IConfigSource configSource, IObjectContainer objectContainer)
        {
            ConfigSource = configSource;
            ObjectContainer = objectContainer;
        }

        public IConfigSource ConfigSource { get; private set; }
        public IObjectContainer ObjectContainer { get; private set; }
    }
}