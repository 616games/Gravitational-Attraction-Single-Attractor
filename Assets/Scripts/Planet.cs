using UnityEngine;

public class Planet : MonoBehaviour
{
    #region --Fields / Properties--
    
    /// <summary>
    /// Reference to the attractor's position.
    /// </summary>
    [SerializeField]
    private GlobalVector3 _attractorPosition;

    /// <summary>
    /// Reference to the gravitational constant.
    /// </summary>
    [SerializeField]
    private GlobalFloat _gravitationalConstant;

    /// <summary>
    /// Reference to the attractor's mass.
    /// </summary>
    [SerializeField]
    private GlobalFloat _attractorMass;

    /// <summary>
    /// The planet's mass.
    /// </summary>
    private float _mass;
    public float mass { get; set; }
    
    /// <summary>
    /// Planet's speed and direction.
    /// </summary>
    private Vector3 _velocity;

    /// <summary>
    /// How fast velocity is changing.
    /// </summary>
    private Vector3 _acceleration;
    
    /// <summary>
    /// Cached Transform component.
    /// </summary>
    private Transform _transform;

    /// <summary>
    /// Cached MeshRenderer component.
    /// </summary>
    private MeshRenderer _meshRenderer;
    
    #endregion
    
    #region --Unity Specific Methods--

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Move();
    }
    
    #endregion
    
    #region --Custom Methods--

    /// <summary>
    /// Handles movement.
    /// </summary>
    private void Move()
    {
        ApplyForce(CalculateGravitationalAttraction());
        _velocity += _acceleration;
        _transform.position += _velocity * Time.deltaTime;
        _acceleration = Vector3.zero;
    }

    /// <summary>
    /// Initializes variables and caches components.
    /// </summary>
    private void Init()
    {
        _transform = transform;
        _mass = Random.Range(1.0f, 50.0f);
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.color = Random.ColorHSV();
    }

    /// <summary>
    /// Cumulatively applies the _force passed in as the parameter to _acceleration.
    /// </summary>
    /// <param name="_force"></param>
    private void ApplyForce(Vector3 _force)
    {
        _acceleration += _force / (_mass <= 0.0 ? 1 : _mass);
    }

    /// <summary>
    /// Calculate gravitational attraction to the attractor.
    /// </summary>
    private Vector3 CalculateGravitationalAttraction()
    {
        Vector3 _direction = _attractorPosition.value - _transform.position;
        float _distance = _direction.sqrMagnitude;
        _distance = Mathf.Clamp(_distance, 5.0f, 25.0f);
        float _strength = _gravitationalConstant.value * _mass * _attractorMass.value / _distance;

        return _direction.normalized * _strength;
    }
    
    #endregion
    
}
