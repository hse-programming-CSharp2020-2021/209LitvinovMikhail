using System;

namespace Homework {
    interface IEntityCreator<out T>
    {
        T Instance { get; }
    }
}
