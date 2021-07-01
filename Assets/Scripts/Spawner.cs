using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    #region --Fields / Properties--
    
    /// <summary>
    /// Game object to be spawned.
    /// </summary>
    [SerializeField]
    private GameObject _planet;

    /// <summary>
    /// Minimum amount of time before spawning.
    /// </summary>
    [SerializeField]
    private float _minimumSpawnTime;

    /// <summary>
    /// Maximum amount of time before spawning.
    /// </summary>
    [SerializeField]
    private float _maximumSpawnTime;

    /// <summary>
    /// Reference to the attractor's position to use for the random position of instantiation.
    /// </summary>
    [SerializeField]
    private GlobalVector3 _attractorPosition;

    [SerializeField]
    private Transform _planetsParent;

    /// <summary>
    /// Random spawn time for each planet.
    /// </summary>
    private float _spawnTime;

    /// <summary>
    /// Tracker for spawn time.
    /// </summary>
    private float _spawnTimer;
    
    #endregion
    
    #region --Unity Specific Methods--

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Spawn();
    }
    
    #endregion
    
    #region --Custom Methods--

    /// <summary>
    /// Initializes variables and caches components.
    /// </summary>
    private void Init()
    {
        _spawnTime = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

    /// <summary>
    /// Spawns a planet in a random position based on the attractor's position.
    /// </summary>
    private void Spawn()
    {
        _spawnTimer += Time.deltaTime;

        if (!(_spawnTimer > _spawnTime)) return;
        
        Vector3 _position = _attractorPosition.value;
        _position.x = Random.Range(_position.x - 10, _position.x + 10);
        _position.y = Random.Range(_position.y - 10, _position.y + 10);
        _position.z = Random.Range(_position.z - 10, _position.z + 10);
        Instantiate(_planet, _position, Quaternion.identity, _planetsParent);
        
        _spawnTimer = 0.0f;
        _spawnTime = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
    
    #endregion
    
}
