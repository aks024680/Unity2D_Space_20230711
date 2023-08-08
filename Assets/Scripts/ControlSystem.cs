
using UnityEngine;
namespace TSUTwoD
{
    /// <summary>
    /// 2D橫向卷軸腳色控制待機、跑步、跳躍
    /// </summary>
public class ControlSystem : MonoBehaviour
{
        [SerializeField,Range(3,500),Header("移動速度")]
        private float speed = 3.5f;
        
        private Rigidbody2D rig;
        private void Awake()
        {
            //print("<color=yellow>喚醒事件</color>");
            rig = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            //print("<color=green>開始事件</color>");
            
        }
        private void Update()
        {
            //float v = Input.GetAxis("Vertical");
            ////print("<color=red>更新事件</color>");
            //print("<color=red> 垂直移動的值</color>" + v );
            float h = Input.GetAxis("Horizontal");
            rig.velocity = new Vector2(h*speed, rig.velocity.y);
        }

    }
}
