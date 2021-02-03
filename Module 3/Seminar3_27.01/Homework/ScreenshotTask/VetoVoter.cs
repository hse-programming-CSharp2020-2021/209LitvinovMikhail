using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenshotTask {
    class VetoVoter {

        public string Name { get; private set; }

        public VetoVoter(string name) => this.Name = name;

        public void VoteHandler(object sender, VetoEventArgs vetoEventArgs) {
            int chance = new Random().Next() % 5;
            if (vetoEventArgs.VetoBy == null && chance == 0) {
                vetoEventArgs.VetoBy = this;
            }
        }
    }
}
