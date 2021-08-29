using UnityEngine;

public class FinishBorder : MonoBehaviour
{
    public GameManager Gm;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovements>() != null)
        {
            Gm.StopGame();
        }
    }
}
