using UnityEngine;
using TSU.TwoD;
using Cinemachine;

namespace Space
{
/// <summary>
/// 敵人攻擊
/// </summary>
public class DamageEnemy : DamageSystem
{
        [SerializeField, Header("狀態管理")]
        private StateManager stateManager;
        [SerializeField, Header("受傷狀態")]
        private HitState stateHit;
        [SerializeField, Header("掉落道具")]
        private GameObject prefabItem;

        private Animator ani;
        private string parDead = "Death";
        private Rigidbody2D rig;
        private Collider2D col;

        private CinemachineImpulseSource impulseSource;

        private string nameBullet = "bullet";

        private void Start()
        {
            ani = GetComponent<Animator>();
            stateManager = GetComponent<StateManager>();
            rig = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();
            impulseSource = FindObjectOfType<CinemachineImpulseSource>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //print($"<color=#6f9>碰到的物件:{collision.gameObject}</color>");
            if (collision.gameObject.name.Contains(nameBullet))
            {
                float bulletAttack = collision.gameObject.GetComponent<Bullet>().dataPlayer.attack;
                Damage(bulletAttack);
                Destroy(collision.gameObject);
                stateManager.stateDefault = stateHit;

                AudioClip sound = SoundManager.instance.soundEnemyHit;
                SoundManager.instance.PlaySound(sound, 0.7f, 1.7f);

                impulseSource.GenerateImpulse();
            }
        }
        protected override void Dead()
        {
            ani.SetBool(parDead, true);
            stateManager.enabled = false;
            rig.bodyType = RigidbodyType2D.Kinematic;
            col.enabled = false;
            rig.velocity = Vector3.zero;
            GameObject tempItem = Instantiate(prefabItem,transform.position + Vector3.up,Quaternion.identity);
            tempItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 100));

            AudioClip soundDead = SoundManager.instance.soundEnemyDead;
            SoundManager.instance.PlaySound(soundDead, 0.7f, 1.7f);
        }
    }
}

