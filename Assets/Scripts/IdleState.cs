
using UnityEngine;

namespace TSU.TwoD
{
    public class IdleState : State
    {
        [SerializeField,Header("遊走狀態")]
        private WanderState stateWander;
        [SerializeField,Header("是否開始游走")]
        private bool startWander;
        [SerializeField, Header("等待狀態的隨機範圍")]
        private Vector2 rangeIdleTime = new Vector2 (0,3);
        [SerializeField, Header("追蹤狀態")]
        private TrackState stateTrack;

        private float timeIdle;

        private float timer;

        private void Start()
        {
          timeIdle = Random.Range(rangeIdleTime.x, rangeIdleTime.y);
            
        }

        public override State RunCurrentState()
        {
            timer += Time.deltaTime;
            
            if(timer >= timeIdle ) startWander = true;
            if (stateWander.TrackTarget())
            {
                ResetState();
                return stateTrack;
            }
            else if(startWander)
            {
                ResetState();

                return stateWander;
            }
           
            else
            {
                return this;
            }
        }

        private void ResetState()
        {
            timer = 0;
            startWander = false;
            timeIdle = Random.Range(rangeIdleTime.x, rangeIdleTime.y);
        }
    }

}
