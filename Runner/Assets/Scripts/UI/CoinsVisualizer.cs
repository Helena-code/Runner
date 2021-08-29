using UnityEngine;
using UnityEngine.UI;

public class CoinsVisualizer : MonoBehaviour
{
    public Text CoinsText;

    public void ChangeText(int coinsTotal)
    {
        CoinsText.text = $"Coins: {coinsTotal}";
    }
}
