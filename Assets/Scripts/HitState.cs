
using UnityEngine;

namespace TSU.TwoD
{
    public class HitState : State
    {
        private string parHit = "Hurt";
        private bool isHit;
        private float timeHit = 0.6f;
        private float timer;

        [SerializeField, Header("遊走狀態")]
        private WanderState stateWander;
        [SerializeField, Header("攻擊狀態")]
        private AttackState stateAttack;

        private Transform player;

        private void Start()
        {
            player = GameObject.Find("SpaceGirl").transform;
        }

        public override State RunCurrentState()
        {
            if (!isHit)
            {
                isHit = true;
                ani.SetTrigger(parHit);
                FlipToPlayer();
                stateAttack.ResetAttackState();
            }
            if (isHit)
            {
                timer += Time.deltaTime;
                if (timer > timeHit)
                {
                    isHit = false;
                    return stateWander;
                }
            }
            return this;
        }

        private void FlipToPlayer()
        {
            if (transform.position.x > player.position.x)
            {
                stateWander.direction = -1;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (transform.position.y < player.position.y)
            {
                stateWander.direction = 1;
                transform.eulerAngles = Vector3.zero;
            }
        }
    }

}
