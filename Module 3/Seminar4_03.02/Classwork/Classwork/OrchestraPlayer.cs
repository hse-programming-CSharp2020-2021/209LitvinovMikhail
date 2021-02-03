using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork1
{
    abstract class OrchestraPlayer {
        public string Name { get; private set; }

        public OrchestraPlayer(string name) => this.Name = name;

        abstract public void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs eventArgs);
    }
}
