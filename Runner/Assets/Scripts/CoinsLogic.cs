using UnityEngine;

public class CoinsLogic : MonoBehaviour
{
    int _coinValue;

    void Awake()
    {
        _coinValue = 1;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInteraction>() != null)
        {
            other.GetComponent<PlayerInteraction>().GetCoin(_coinValue);
            Destroy(gameObject);
        }
    }
}
