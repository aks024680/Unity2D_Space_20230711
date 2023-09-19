
using UnityEngine;

namespace Space
{
    /// <summary>
    /// 子彈
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        [Header("玩家資料")]
        public DataBasic dataPlayer;

        private void Awake()
        {
            Destroy(gameObject,5);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}

