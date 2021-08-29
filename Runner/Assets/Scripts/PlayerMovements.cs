using UnityEngine;
using static RoadLineManager;

public class PlayerMovements : MonoBehaviour
{
    public RoadLineManager RoadLineScript;
    public float SpeedNormal = 2f;

    public bool Stay
    {
        get { return _isStay; }
    }

    public float SpeedTotal
    {
        get { return _speedTotal; }
    }

    PlayerAnimation _playerAnimationScript;
    Transform _playerTransform;
    Vector3 _movePos;
    Vector3 _swipeMovePos;
    LineNumber _currentLineNumber;

    float _speedTotal;
    // can be used for boost speed
    float _speedCoef;
    float _targetLinePosX;
    bool _isStay;
    bool _swipeMove;

    void Awake()
    {
        _speedCoef = 0f;
        _isStay = true;
        _playerAnimationScript = GetComponent<PlayerAnimation>();
        _playerTransform = GetComponent<Transform>();
        _movePos = Vector3.zero;
        _swipeMovePos = Vector3.zero;
    }

    void Update()
    {
        if (_isStay)
        {
            return;
        }
        else
        {
            _speedTotal = SpeedNormal * _speedCoef;
            _movePos = (Vector3.forward + _swipeMovePos) * _speedTotal * Time.deltaTime;
            _playerTransform.Translate(_movePos);

            if (_swipeMove)
            {
                if (Mathf.Abs(_playerTransform.position.x - _targetLinePosX) <= 0.05f)
                {
                    ClearSwipe();
                }
            }
        }
    }

    void Moving(Vector3 directionSwipe)
    {
        if (!_swipeMove)
        {
            _swipeMovePos = directionSwipe;
            _swipeMove = true;
        }
    }

    void ClearSwipe()
    {
        _swipeMovePos = Vector3.zero;
        _swipeMove = false;
    }

    public void StopPlayer(bool yesno)
    {
        if (yesno)
        {
            _speedCoef = 0f;
        }
        else
        {
            _speedCoef = 1f;
        }
        _playerAnimationScript.Running(!yesno);
        _isStay = yesno;
    }

    public void Winned(bool yesno)
    {
        _playerAnimationScript.Winning();
    }

    public void MovePlayer(bool left, bool right)
    {
        if (_swipeMove)
        {
            return;
        }
        else
        {
            bool leftValue = left;
            bool rightValue = right;
            Vector3 swipeMoveDirection = Vector3.zero;

            if (leftValue)
            {
                swipeMoveDirection = Vector3.left;
            }
            else if (rightValue)
            {
                swipeMoveDirection = Vector3.right;
            }

            _currentLineNumber = RoadLineScript.CheckLineNumber(_playerTransform.position.x);
            // ask about move player possible
            if (RoadLineScript.CheckLineToMove(_currentLineNumber, leftValue, rightValue))
            {
                _targetLinePosX = RoadLineScript.GetTargetLine(_currentLineNumber, leftValue, rightValue);
                Moving(swipeMoveDirection);
            }
        }
    }
}
