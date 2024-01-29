using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager instance { get; private set; }

    public BattleManager battleManager;
    public PoolManager poolManager;

    [AssetSelector(Paths = "Assets/Resources/Levels")]
    public LevelSO LevelData;

    public float Score { get; set; }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);

        Application.targetFrameRate = 60;
        DOTween.Init(true, true, LogBehaviour.Verbose);

        battleManager = FindAnyObjectByType<BattleManager>();
        poolManager = FindAnyObjectByType<PoolManager>();
    }

    private void Start()
    {
        // Initialize any necessary game state here
        Score = 0f;
    }

}
