using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public PlayerMovements PlayerMoveScript;

    Vector2 _startTouch;
    Vector2 _swipeDist;
    bool _swipeLeft;
    bool _swipeRight;
    bool _dragging;

    void Update()
    {
        #region UNITY_ANDROID
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                _dragging = true;
                _startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                TryMovePlayer();
                Clear();
            }
        }
        #endregion

        #region UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            _dragging = true;
            _startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            TryMovePlayer();
            Clear();
        }
        #endregion

        if (_dragging)
        {
            #region UNITY_ANDROID
            if (Input.touches.Length > 0)
            {
                _swipeDist = Input.touches[0].position - _startTouch;
            }
            #endregion

            #region UNITY_STANDALONE
            if (Input.GetMouseButton(0))
            {
                _swipeDist = (Vector2)Input.mousePosition - _startTouch;
            }
            #endregion
        }

        //checking distance and direction
        if (_swipeDist.magnitude > 100)
        {
            float x = _swipeDist.x;
            float y = _swipeDist.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    _swipeLeft = true;
                }
                else if (x > 0)
                {
                    _swipeRight = true;
                }
            }
        }
    }

    void Clear()
    {
        _startTouch = Vector2.zero;
        _swipeDist = Vector2.zero;
        _dragging = false;
        _swipeLeft = false;
        _swipeRight = false;
    }

    void TryMovePlayer()
    {
        if (_swipeLeft || _swipeRight)
        {
            PlayerMoveScript.MovePlayer(_swipeLeft, _swipeRight);
        }
    }
}

