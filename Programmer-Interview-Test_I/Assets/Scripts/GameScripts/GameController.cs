using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] private PlayerController playerPrefab;

    [SerializeField] private EnemyController enemyPrefab;

    public PlayerController Player { get; private set; }

    public EnemyController Enemy { get; private set; }

    [SerializeField] private PositionConstraint cameraParentConstraint;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, transform);
        Player.Create();

        ConstraintSource _source = new ConstraintSource();
        _source.sourceTransform = Player.transform;
        _source.weight = 1;
        cameraParentConstraint.SetSource(0, _source);
        cameraParentConstraint.translationOffset = new Vector3(5.76f, 9.15f, -5.79f);
        cameraParentConstraint.constraintActive = true;

        Enemy = Instantiate(enemyPrefab, new Vector3(0, 0, -5), Quaternion.identity, transform);
        Enemy.Create();

        GameData.timeBeingChased = 0;
        GameData.coinsCollectedOnRun = 0;
        GameData.paused = false;

        CoinManager.Manager.CreateCoins(50);
    }

    public void RestartGame()
    {
        if (Player != null)
        {
            Destroy(Player.gameObject);
        }

        if (Enemy != null)
        {
            Destroy(Enemy.gameObject);
        }

        Start();
    }
}
