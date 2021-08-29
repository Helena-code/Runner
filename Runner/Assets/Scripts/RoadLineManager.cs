using System.Collections.Generic;
using UnityEngine;

public class RoadLineManager : MonoBehaviour
{
    public enum LineNumber
    {
        First,
        Second,
        Third,
        Forth,
        Default = 99,
    }

    public float LengthLine
    {
        get { return _lengthLine; }
    }

    public List<Transform> Lines;

    List<float> _linesPosX;
    float _lengthLine;
    float _minDist;

    void Awake()
    {
        _minDist = 0.1f;
        _linesPosX = new List<float>();

        for (int i = 0; i < Lines.Count; i++)
        {
            _linesPosX.Add(Lines[i].position.x);
        }
        _lengthLine = Lines[0].transform.localScale.z;
    }

    public LineNumber CheckLineNumber(float playerPosX)
    {
        for (int i = 0; i < _linesPosX.Count; i++)
        {
            if ((playerPosX - _linesPosX[i]) <= _minDist)
            {
                return (LineNumber)i;
            }
        }

        Debug.LogError("Player Not On The Line");
        return LineNumber.Default;
    }

    public float GetTargetLine(LineNumber ln, bool leftswipe, bool rightswipe)
    {
        if (leftswipe)
        {
            int temp = (int)ln - 1;
            return _linesPosX[temp];
        }
        else
        if (rightswipe)
        {
            int temp = (int)ln + 1;
            return _linesPosX[temp];
        }

        Debug.LogError("Player Not On The Line");
        return _linesPosX[(int)ln];
    }

    public bool CheckLineToMove(LineNumber ln, bool leftswipe, bool rightswipe)
    {
        if (leftswipe && (int)ln > 0)
        {
            return true;
        }
        else
        {
            if (rightswipe && (int)ln != (_linesPosX.Count - 1))
            {
                return true;
            }
            else return false;
        }
    }
}
