using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Loop
{
    public abstract class BaseState
    {
        public abstract void InitState();
        public abstract void UpdateState();
        public abstract void DisposeState();
    } 
}
