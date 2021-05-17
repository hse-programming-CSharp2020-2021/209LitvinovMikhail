using System;

namespace Homework {
    interface IEntityFactory<out T>
    {
        T Instance { get; }
    }
}
