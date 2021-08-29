using UnityEngine;

public class CoinsKeeper : MonoBehaviour
{
    CoinsVisualizer _coinsScript;
    int _coinsTotal;

    void Start()
    {
        _coinsScript = GetComponent<CoinsVisualizer>();
    }

    public void AddCoins(int value)
    {
        _coinsTotal += value;

        if (_coinsTotal < 0)
        {
            _coinsTotal = 0;
        }

        _coinsScript.ChangeText(_coinsTotal);
    }
}
