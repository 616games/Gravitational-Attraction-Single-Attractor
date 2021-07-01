using UnityEngine;

/// <summary>
/// By declaring type T, inheritors of this class can determine what type they want to be.
/// </summary>
public abstract class GlobalVariable<T> : ScriptableObject, ISerializationCallbackReceiver
{
    #region --Fields / Properties--
    
    /// <summary>
    /// Declared initial value of the type of variable specified by the inheriting class.
    /// </summary>
    [SerializeField]
    private T _value;
    
    /// <summary>
    /// Get/Set the _runtimeValue and not the declared _value so _value is never overwritten.
    /// </summary>
    public T value { get { return _runtimeValue; } set { _runtimeValue = value; } }

    /// <summary>
    /// The value of this variable used during runtime.
    /// </summary>
    private T _runtimeValue;
    
    #endregion
    
    #region --Unity Specific Methods--
    
    /// <summary>
    /// Take the declared _value and use the _runtimeValue when the game is running.
    /// </summary>
    public void OnBeforeSerialize()
    {
        _runtimeValue = _value;
    }

    public void OnAfterDeserialize()
    {
    }
    
    #endregion
}
