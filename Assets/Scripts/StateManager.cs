
using UnityEngine;

namespace TSU.TwoD
{
public class StateManager : MonoBehaviour
{
        [SerializeField,Header("預設狀態")]
        public State stateDefault;

        private void Update()
        {
            RunStateMachine();
        }

        private void RunStateMachine()
        {
            State nextState = stateDefault?.RunCurrentState();
            if(nextState != null)
            {
                stateDefault = nextState;
            }
        }
}

}

