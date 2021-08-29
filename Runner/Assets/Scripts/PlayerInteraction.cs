using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    InteractMenu _interactMenuScript;
    EnemyLogic _enemyLogicScript;
    CoinsKeeper _goalKeeperScript;
    PlayerMovements _playerMoveScript;
    PlayerAnimation _playerAnimationScript;

    int _enemyPayValue;
    int _coinPayValue;

    void Start()
    {
        _goalKeeperScript = GetComponent<CoinsKeeper>();
        _interactMenuScript = GetComponent<InteractMenu>();
        _playerMoveScript = GetComponent<PlayerMovements>();
        _playerAnimationScript = GetComponent<PlayerAnimation>();
    }

    void PayEnemyLogic()
    {
        ChangeCoinScore(_enemyPayValue);
        _interactMenuScript.HideInteractMenu();
        _playerMoveScript.StopPlayer(false);
    }

    void AttackEnemyLogic()
    {
        _interactMenuScript.HideInteractMenu();
        _playerMoveScript.StopPlayer(false);
    }

    public void ShowInteractMenu()
    {
        _interactMenuScript.ShowInteractMenu();
    }

    public void GetEnemy(EnemyLogic el, int payValue)
    {
        _enemyLogicScript = el;
        _enemyPayValue = -payValue;
        ShowInteractMenu();
    }

    public void GetCoin(int payValue)
    {
        _coinPayValue = payValue;
        ChangeCoinScore(_coinPayValue);
    }

    public void PayEnemy()
    {
        _playerAnimationScript.Paying();
        _enemyLogicScript.Payed();
        // value near animation clip time but shorter
        Invoke("PayEnemyLogic", 1.14f);
    }

    public void AttackEnemy()
    {
        _playerAnimationScript.Attacking();
        _enemyLogicScript.Die();
        // value near animation clip time but shorter
        Invoke("AttackEnemyLogic", 2.15f);
    }

    public void ChangeCoinScore(int value)
    {
        _goalKeeperScript.AddCoins(value);
    }
}
