using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenshotTask {
    class VetoEventArgs : EventArgs {
        public string Proposal { get; private set; }

        public VetoVoter VetoBy { get; internal set; } = null;

        public VetoEventArgs(string proposal) {
            this.Proposal = proposal;
        }
    }
}
