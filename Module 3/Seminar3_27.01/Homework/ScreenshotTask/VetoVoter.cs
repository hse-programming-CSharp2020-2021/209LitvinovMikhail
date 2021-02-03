using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenshotTask {
    class VetoVoter {

        public string Name { get; private set; }

        public void VoteHandler(object sender, VetoEventArgs vetoEventArgs) {
            int chance = new Random().Next() % 5;
            if (chance == 0) {
                vetoEventArgs.VetoBy = this;
            }
        }
    }
}
