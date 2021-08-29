using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _anim;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _anim.SetBool("run", false);
        _anim.SetBool("attack", false);
        _anim.SetBool("pay", false);
        _anim.SetBool("win", false);
    }

    public void Running(bool yesno)
    {
        if (yesno)
        {
            _anim.SetBool("attack", false);
            _anim.SetBool("pay", false);
            _anim.SetBool("win", false);
        }
        _anim.SetBool("run", yesno);
    }

    public void Winning()
    {
        _anim.SetBool("run", false);
        _anim.SetBool("attack", false);
        _anim.SetBool("pay", false);

        _anim.SetBool("win", true);
    }

    public void Attacking()
    {
        _anim.SetBool("attack", true);
    }

    public void Paying()
    {
        _anim.SetBool("pay", true);
    }
}
