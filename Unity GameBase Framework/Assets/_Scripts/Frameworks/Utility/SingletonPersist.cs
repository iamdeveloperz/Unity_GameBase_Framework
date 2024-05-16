
using UnityEngine;

public class SingletonPersist<T> : Singleton<T> where T : MonoBehaviour
{
    protected override void Initialize()
    {
        DontDestroyOnLoad(this);
    }
}