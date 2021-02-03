using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork1 {
    class Violinist : OrchestraPlayer {
        public Violinist(string name) : base(name) { }

        public override void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs eventArgs) {
            Console.WriteLine($"Violinist {this.Name} plays composition #{eventArgs.CompositionNumber}: La-la!");
        }
    }
}
