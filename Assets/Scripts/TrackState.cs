
using UnityEngine;

namespace TSU.TwoD
{
    public class TrackState : State
    {
        public override State RunCurrentState()
        {
            return this;
        }
    }

}
