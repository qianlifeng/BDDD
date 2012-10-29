using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Config;
using BDDD.ObjectContainer;

namespace BDDD.Application
{
    public class AppInitEventArgs : EventArgs
    {
        public IConfigSource ConfigSource { get; private set; }
        public IObjectContainer ObjectContainer { get; private set; }
        
        public AppInitEventArgs()
            : this(null, null)
        { }
        
        public AppInitEventArgs(IConfigSource configSource, IObjectContainer objectContainer)
        {
            this.ConfigSource = configSource;
            this.ObjectContainer = objectContainer;
        }
    }
}
