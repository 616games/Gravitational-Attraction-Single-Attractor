using UnityEngine;

public class Attractor : MonoBehaviour
{
    #region --Fields / Properties--
    
    /// <summary>
    /// The position of the attractor.
    /// </summary>
    [SerializeField]
    private GlobalVector3 _attractorPosition;

    /// <summary>
    /// The gravitational constant used by all planets.
    /// </summary>
    [SerializeField]
    private GlobalFloat _gravitationalConstant;
    
    /// <summary>
    /// The mass of the attractor.
    /// </summary>
    [SerializeField]
    private GlobalFloat _attractorMass;
    
    /// <summary>
    /// Cached Transform component.
    /// </summary>
    private Transform _transform;
    
    #endregion
    
    #region --Unity Specific Methods--

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        UpdatePosition();
    }
    
    #endregion
    
    #region --Custom Methods--

    /// <summary>
    /// Initializes variables and caches components.
    /// </summary>
    private void Init()
    {
        _transform = transform;
    }

    /// <summary>
    /// Constantly update the attractor's position to the global variable.
    /// </summary>
    private void UpdatePosition()
    {
        _attractorPosition.value = _transform.position;
    }
    
    #endregion
    
}