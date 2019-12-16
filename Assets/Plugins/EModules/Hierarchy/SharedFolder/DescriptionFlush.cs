#if UNITY_EDITOR
using UnityEngine;

namespace EModules {
public class DescriptionFlush : MonoBehaviour, IDescriptionFlush {
    [SerializeField]
    string _cachedData;
    public string cachedData {get {return _cachedData;} set {_cachedData = value;}}
}
}
#endif
