
using UnityEngine;

namespace TSU.TwoD
{
    public class WanderState : State
    {
        [SerializeField,Header("腳色的初始座標")]
        private Vector3 pointOriginal;
        [SerializeField,Header("左邊座標位移")]
        private float OffsetLeft = -2;
        [SerializeField,Header("右邊座標位移")]
        private float OffsetRight = 2;
        [SerializeField,Header("移動速度"),Range(0,5)]
        private float speed = 1.5f;
        [SerializeField, Header("待機狀態")]
        private WanderState stateIdle;
        [SerializeField, Header("是否開始待機")]
        private bool startIdle;
        [SerializeField, Header("遊走狀態的隨機範圍")]
        private Vector2 rangeWanderTime = new Vector2(0, 3);

        private float timeWander;

        private float timer;

        private Vector3 pointLeft => pointOriginal + Vector3.right * OffsetLeft;
        private Vector3 pointRight => pointOriginal + Vector3.right * OffsetRight;
        /// <summary>
        /// 控制敵人移動方向，往右邊+1，往左邊-1
        /// </summary>
        private int direction = 1;
        private Animator anim;
        private string parWander = "Running";
        private Rigidbody2D rb;
        private void Start()
        {
            timeWander = Random.Range(rangeWanderTime.x, rangeWanderTime.y);
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            
            Gizmos.DrawSphere(pointLeft, 0.1f);
            Gizmos.DrawSphere(pointRight, 0.1f);
        }
        public override State RunCurrentState()
        {

          

            if (Vector3.Distance(transform.position, pointRight) < 1f)
            {
                direction = -1;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (Vector3.Distance(transform.position, pointLeft) < 1f)
            {
                direction = 1;
                transform.eulerAngles = Vector3.zero;
            }


            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            anim.SetBool(parWander, true);
            

            timer += Time.deltaTime;
            print($"<color=blue>計時器 : {timer}</color>");
            if (timer >= timeWander) startIdle = true;
            if (startIdle)
            {
                return stateIdle;
            }
            else
            {
                return this;
            }
        }
        [ContextMenu("取得腳色原始座標")]
        private void GetOriginalPoint() { 
        pointOriginal = transform.position;
        }
    }

}
