using Fungus;
using TMPro;
using UnityEngine;

namespace Space
{
    /// <summary>
    /// 金幣管理器
    /// </summary>
    public class CoinManager : MonoBehaviour
    {
        [SerializeField, Header("遊戲管理器")]
        private Flowchart flowchartGM;

        private TextMeshProUGUI textCoin;
        private int coinCurrent;
        private int coinTotal = 10;

        private void Awake()
        {
            textCoin = GameObject.Find("coinText").GetComponent<TextMeshProUGUI>();
            textCoin.text = $"金幣數量 : {coinCurrent} / {coinTotal}";
        }
        private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
        {
            if (collision.gameObject.name.Contains("UI_Icon_Coin")) EatCoin(collision.gameObject);
        }
        private void EatCoin(GameObject coin)
        {
            AudioClip sound = SoundManager.instance.soundCoin;
            SoundManager.instance.PlaySound(sound, 0.7f, 1.7f);

            Destroy(coin);
            textCoin.text = $"金幣數量 : {++coinCurrent} / {coinTotal}";
            if (coinCurrent >= coinTotal)
            {
                AudioClip soundWin = SoundManager.instance.soundWin;
                SoundManager.instance.PlaySound(soundWin, 0.7f, 1.7f);
                flowchartGM.SendFungusMessage("遊戲勝利");
            }
            }
    }
}

