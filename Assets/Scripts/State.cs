
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
        private void Awake()
        {
            ani = GetComponent<Animator>();
        }
    }

}
