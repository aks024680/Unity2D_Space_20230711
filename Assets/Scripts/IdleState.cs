
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

        private float timeIdle;

        private float timer;

        private void Start()
        {
          timeIdle = Random.Range(rangeIdleTime.x, rangeIdleTime.y);
            print($"<color=purple>隨機等待時間 : {timeIdle}</color>");
        }

        public override State RunCurrentState()
        {
            timer += Time.deltaTime;
            print($"<color=blue>計時器 : {timer}</color>");
            if(timer >= timeIdle ) startWander = true;
           if(startWander)
            {
                return stateWander;
            }
            else
            {
                return this;
            }
        }
    }

}
