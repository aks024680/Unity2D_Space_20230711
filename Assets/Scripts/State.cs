
using UnityEngine;
namespace TSU.TwoD
{/// <summary>
/// 狀態抽象類別
/// </summary>
public abstract class State : MonoBehaviour
{/// <summary>
/// 執行當前狀態
/// </summary>
  public abstract State RunCurrentState();
        protected  Animator ani { get; private set; }
        [field:SerializeField,Header("目標圖層")]
        protected LayerMask layerTarget { get; private set; }
        private void Awake()
        {
            ani = GetComponent<Animator>();
        }
    }

}
