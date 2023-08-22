
using UnityEngine;

namespace TSU.TwoD
{
    public class TrackState : State
    {
        [SerializeField, Header("追蹤速度"), Range(0, 5)]
        private float speed = 3.5f;
        [SerializeField, Header("遊走狀態")]
        private WanderState stateWander;
        [Header("攻擊區域")]
        [SerializeField]
        private Vector3 attackSize = Vector3.one;
        [SerializeField]
        private Vector3 attackOffset;
        [SerializeField, Header("攻擊狀態")]
        private AttackState stateAttack;

        private Rigidbody2D rig;
        private string parWalk = "Running";

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1,0.3f,0.3f,0.5f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(attackOffset), attackSize);
        }

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
        }
        public override State RunCurrentState()
        { 
            if (stateWander.TrackTarget()) {
                if (!AttackTarget())
                {
                    ani.SetBool(parWalk, true);
                    ani.speed = 5;
                    rig.velocity = new Vector2(speed * stateWander.direction, rig.velocity.y);
                    return this;
                }
                else
                {
                    ResetState();
                    return stateAttack;
                } 
            }
            else
            {
                ResetState();
                return stateWander;
            }
        }
        
        private void ResetState()
        {
            ani.SetBool(parWalk, false);
            ani.speed = 1f;
            rig.velocity = Vector3.zero;

        }
        public bool AttackTarget()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(attackOffset), attackSize,0,layerTarget);
            return hit;
        }
    }
   

}
