using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork1 {
    class PlayIsStartedEventArgs : EventArgs {
        public int CompositionNumber { get; private set; }

        public PlayIsStartedEventArgs(int composition) {
            this.CompositionNumber = composition;
        }
    }
}
