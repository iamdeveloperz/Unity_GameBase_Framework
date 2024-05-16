
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour 
{
    #region Fields

    private static T _instance;
    private static bool _isApplicationQuit;
    private static readonly object _lock = new();

    #endregion



    #region Properties

    public static T Instance
    {
        get
        {
            if (_isApplicationQuit)
            {
                Debugger.LogWarning("[Singleton] Instance '" + typeof(T) + "' already destroyed.");
                return null;
            }

            lock (_lock)
            {
                return _instance != null ? _instance : GetInstance();
            }
        }
    }

    private static T GetInstance()
    {
        _instance = FindFirstObjectByType<T>();

        if (_instance == null)
        {
            var singleton = new GameObject { name = "[Singleton] " + typeof(T) };
            _instance = singleton.AddComponent<T>();
            
            Debugger.Log("Singleton an instance of '" + typeof(T) + "' created.");
        }

        return _instance;
    }

    #endregion



    #region Unity Events

    private void Awake()
    {
        Initialize();
    }

    private void OnApplicationQuit()
    {
        _isApplicationQuit = true;
    }

    private void OnDestroy()
    {
        lock (_lock)
        {
            if (_instance != this) return;
            
            Destroyed();
        }
    }

    #endregion



    #region Virtual Methods

    protected virtual void Initialize() { }
    protected virtual void Destroyed() => _instance = null;

    #endregion
}
