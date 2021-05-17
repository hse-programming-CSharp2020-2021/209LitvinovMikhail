using System;

namespace Homework {
    class DataBaseException : Exception {
        public DataBaseException() { }

        public DataBaseException(string message) : base(message) { }
    }
}
