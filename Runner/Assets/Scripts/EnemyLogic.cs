using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    Collider _coll;
    Animator _anim;
    Transform transf;
    Vector3 _awayPos;

    int _payValue;
    float _speed;
    bool _payed;

    void Start()
    {
        _coll = GetComponent<Collider>();
        _anim = GetComponentInChildren<Animator>();
        transf = GetComponent<Transform>();

        _payValue = 2;
        _speed = 2f;
        // some near distanse to go away when payed
        _awayPos = new Vector3(-0.5f, 0f, 0.5f);
    }

    void Update()
    {
        if (!_payed)
        {
            return;
        }
        else
        {
            transf.Translate(_awayPos * _speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInteraction>() != null)
        {
            other.GetComponent<PlayerMovements>().StopPlayer(true);
            other.GetComponent<PlayerInteraction>().GetEnemy(this, _payValue);
        }
    }

    void StopGoAway()
    {
        _payed = false;
        _anim.SetBool("goAway", false);
    }

    public void Die()
    {
        _coll.enabled = false;
        _anim.SetBool("die", true);
    }

    public void Payed()
    {
        _payed = true;
        _coll.enabled = false;
        _anim.SetBool("goAway", true);
        Invoke("StopGoAway", 0.5f);
    }
}
