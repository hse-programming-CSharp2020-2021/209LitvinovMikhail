using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenshotTask {
    class VetoComission {

        // Не смог понять, почему при определении OnVote в качестве свойства не получается вызвать событие в Vote(string proposal).
        public event EventHandler<VetoEventArgs> OnVote;

        public VetoEventArgs Vote (string proposal) {
            VetoEventArgs result = new VetoEventArgs(proposal);
            OnVote?.Invoke(this, result);
            return result;
        }
    }
}
