using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork1 {
    class Bandmaster {

        public event EventHandler<PlayIsStartedEventArgs> PlayIsStarted;

        public void StartPlay (int param) {
            this.PlayIsStarted(this, new PlayIsStartedEventArgs(param));
        }
    }
}
