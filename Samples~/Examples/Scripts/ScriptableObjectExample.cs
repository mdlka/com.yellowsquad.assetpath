using UnityEngine;

namespace YellowSquad.AssetPath.Samples.Examples
{
    [CreateAssetMenu(menuName = "Create ScriptableObjectExample", fileName = "ScriptableObjectExample", order = 56)]
    public class ScriptableObjectExample : ScriptableObject
    {
        [SerializeField] private ResourcesReference<GameObject> _gameObjectPath;
        [SerializeField] private ResourcesReference<Rigidbody> _rigidbodyPath;
        [SerializeField] private ResourcesReference<AudioSource> _audioSourcePath;
    }
}