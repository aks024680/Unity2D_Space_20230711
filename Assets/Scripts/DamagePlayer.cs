using UnityEngine;
using UnityEngine.UI;
using Fungus;
using System.Collections;

namespace Space
{
    public class DamagePlayer : DamageSystem
    {
        [SerializeField, Header("血條")]
        private Image imgHP;
        [SerializeField, Header("遊戲管理器")]
        protected Flowchart fungusGM;
        [SerializeField, Header("受傷著色器材質球")]
        private Material mHurt;

        public override void Damage(float getDamage)
        {
            base.Damage(getDamage);
            imgHP.fillAmount = hp / hpMax;
            StartCoroutine(DamageEffect());
        }

        private void OnEnable()
        {
            mHurt.SetFloat("_hurtfloat", 0);
        }

        private void OnDisable()
        {
            mHurt.SetFloat("_hurtfloat", 0);
        }

        protected override void Dead()
        {
            fungusGM.SendFungusMessage("遊戲失敗");
            Destroy(gameObject);
        }
        private IEnumerator DamageEffect()
        {
            for(int i = 0;i < 2;i++)
            {
                mHurt.SetFloat("_hurtfloat", 0.5f);
                yield return new WaitForSeconds(0.25f);
                mHurt.SetFloat("_hurtfloat", 0f);
                yield return new WaitForSeconds(0.25f);
            }
        }
    }

}

