
using UnityEngine;
namespace TSUTwoD
{
    /// <summary>
    /// 2D橫向卷軸腳色控制待機、跑步、跳躍
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        [SerializeField, Range(3, 500), Header("移動速度")]
        private float speed = 3.5f;

        private Rigidbody2D rig;

        private Animator ani;
        private string run_str = "Running";
        [SerializeField, Header("檢查地板尺寸")]
        private Vector3 v3CheckGroundSize = Vector3.one;
        [SerializeField, Header("檢查地板位移")]
        private Vector3 v3CheckGroundOffset = Vector3.zero;
        [SerializeField, Header("檢查是否碰觸到地板的圖層")]
        private LayerMask layerCheckGround;

        [SerializeField, Range(0.1f, 1500), Header("跳躍力道")]
        private float jumpForce = 500f;

        private void Awake()
        {
            //print("<color=yellow>喚醒事件</color>");
            rig = GetComponent<Rigidbody2D>();
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0.3f, 0.5f);
            Gizmos.DrawCube(transform.position + v3CheckGroundOffset, v3CheckGroundSize);
        }
        private void Start()
        {
            //print("<color=green>開始事件</color>");
            ani = GetComponent<Animator>();
        }
        private void Update()
        {
            MoveAndFlip();
            //CheckGround();
            Jump();
        }
        private void Jump() { 
        if(CheckGround() &&Input.GetKeyDown(KeyCode.Space)) {
                rig.AddForce(new Vector2(0, jumpForce));
            }
        }
        private bool CheckGround()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + v3CheckGroundOffset, v3CheckGroundSize,0, layerCheckGround);
            return hit;
            //print($"<color=red>觸碰到地板:{hit.name}</color>");
        }
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
            ani.SetBool(run_str, h != 0);
        }
    }
}
