using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork1 {
    class Hornist : OrchestraPlayer {
        public Hornist (string name) : base(name) { }
        public override void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs eventArgs) {
            Console.WriteLine($"Violinist {this.Name} starts playing composition #{eventArgs.CompositionNumber}: Du-du-du!");
        }
    }
}
