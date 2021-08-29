using UnityEngine;
using UnityEngine.UI;

public class FinishBarController : MonoBehaviour
{
    public Slider FinishBar;

    PlayerMovements _playerMoveScript;
    float _roadLength;

    void Awake()
    {
        FinishBar.value = 0f;
        _playerMoveScript = GetComponent<PlayerMovements>();
        _roadLength = _playerMoveScript.RoadLineScript.LengthLine;
    }

    void Update()
    {
        if (_playerMoveScript.Stay)
        {
            return;
        }
        else
        {
            FinishBar.value += (_playerMoveScript.SpeedTotal / (_roadLength * 0.95f)) * Time.deltaTime;
        }
    }
}
