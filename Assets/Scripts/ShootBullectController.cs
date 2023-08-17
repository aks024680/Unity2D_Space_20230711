
using UnityEngine;

namespace TSU.TwoD
{
public class ShootBullectController : MonoBehaviour
{
        [SerializeField,Header("子彈預置物")]
        private GameObject prefabBullect;
        [SerializeField,Header("生成子彈位置")]
        private Transform bullectSpawn;

        private Animator ani;
        private string parFire = "Shooting";
        [SerializeField,Header("發射子彈力道"),Range(0,5000)]
        private float powerBullect = 1000;
        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            Fire();
        }
        private void Fire()
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                ani.SetTrigger(parFire);
                GameObject tempBullect = Instantiate(prefabBullect, bullectSpawn.position,transform.rotation);
                tempBullect.GetComponent<Rigidbody2D>().AddForce(transform.right* powerBullect);
            }
        }
    }

}

