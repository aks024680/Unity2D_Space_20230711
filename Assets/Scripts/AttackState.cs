
using Space;
using UnityEngine;

namespace TSU.TwoD
{
    public class AttackState : State
    {
        [SerializeField, Header("送出攻擊檢測的時間點"), Range(0, 5)]
        private float timeSendAttackCheck = 0.5f;
        [SerializeField, Header("攻擊結束的時間點"), Range(0, 5)]
        private float timeAttackEnd = 1.5f;
        [SerializeField, Header("追蹤狀態")]
        private TrackState stateTrack;
        [SerializeField, Header("敵人資料")]
        private DataBasic data;

        private bool canSendAttack = true;
        private string parAttack = "Attack";
        private float timer;

        private DamageSystem damageSystem;

        private void Start()
        {
            damageSystem = GameObject.Find("SpaceGirl").GetComponent<DamageSystem>();
        }
        public override State RunCurrentState()
        {
            if (timer == 0)
            {
                ani.SetTrigger(parAttack);

            }
            else
            {
                if (timer >= timeSendAttackCheck && canSendAttack)
                {
                    canSendAttack = false;
                    if (stateTrack.AttackTarget())
                    {
                        //print("<color=#69f>擊中玩家!</color>");
                        damageSystem.Damage(data.attack);
                    }
                }
                else if (timer >= timeAttackEnd)
                {
                    canSendAttack = true;
                    timer = 0;
                    return stateTrack;
                }
            }
            timer += Time.deltaTime;
            return this;
        }

        public void ResetAttackState()
        {
            timer = 0;
            canSendAttack = true;
        }
    }

}
