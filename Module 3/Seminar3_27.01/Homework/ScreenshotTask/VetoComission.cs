﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenshotTask {
    class VetoComission {
        private event EventHandler<VetoEventArgs> OnVote;

        public VetoEventArgs Vote (string proposal) {

        }
    }
}