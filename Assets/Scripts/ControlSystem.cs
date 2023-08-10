
using UnityEngine;
namespace TSUTwoD
{
    /// <summary>
    /// 2D橫向卷軸腳色控制待機、跑步、跳躍
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        #region 資料

        
        [SerializeField, Range(3, 500), Header("移動速度")]
        private float speed = 3.5f;

        private Rigidbody2D rig;

        private Animator ani;
        private string parRun = "Running";
        private string parJum = "Jumping";
        [SerializeField, Header("檢查地板尺寸")]
        private Vector3 v3CheckGroundSize = Vector3.one;
        [SerializeField, Header("檢查地板位移")]
        private Vector3 v3CheckGroundOffset = Vector3.zero;
        [SerializeField, Header("檢查是否碰觸到地板的圖層")]
        private LayerMask layerCheckGround;

        [SerializeField, Range(0.1f, 1500), Header("跳躍力道")]
        private float jumpForce = 500f;
        #endregion

        #region 事件
        /// <summary>
        /// 呼叫鋼體
        /// </summary>
        private void Awake()
        {
            //print("<color=yellow>喚醒事件</color>");
            rig = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// 繪製觸發碰地板的圖
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0.3f, 0.5f);
            Gizmos.DrawCube(transform.position + v3CheckGroundOffset, v3CheckGroundSize);
        }

        /// <summary>
        /// 呼叫動畫系統
        /// </summary>
        private void Start()
        {
            //print("<color=green>開始事件</color>");
            ani = GetComponent<Animator>();
        }

        /// <summary>
        /// 執行移動及跳躍
        /// </summary>
        private void Update()
        {
            MoveAndFlip();
            //CheckGround();
            Jump();
        }
        #endregion

        #region 方法

        
        /// <summary>
        /// 跳躍腳本
        /// </summary>
        private void Jump() { 
        if(CheckGround() &&Input.GetKeyDown(KeyCode.Space)) {
                rig.AddForce(new Vector2(0, jumpForce));
            }
        }

        /// <summary>
        /// 確認是否在地上
        /// </summary>
        /// <returns>回傳判斷是否在地板的layer</returns>
        private bool CheckGround()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + v3CheckGroundOffset, v3CheckGroundSize,0, layerCheckGround);
            ani.SetBool(parJum, !hit);
            return hit;
            //print($"<color=red>觸碰到地板:{hit.name}</color>");
        }

        /// <summary>
        /// 移動腳本
        /// </summary>
        private void MoveAndFlip()
        {
            //float v = Input.GetAxis("Vertical");
            ////print("<color=red>更新事件</color>");
            //print("<color=red> 垂直移動的值</color>" + v );
            float h = Input.GetAxis("Horizontal");
            rig.velocity = new Vector2(h * speed, rig.velocity.y);

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //print("按下 A ");
                transform.eulerAngles = new Vector3(0, 180, 0);

            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                //print("按下 D ");
                transform.eulerAngles = Vector3.zero;
            }
            ani.SetBool(parRun, h != 0);
        }
        #endregion
    }
}
