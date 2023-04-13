using UnityEngine;

namespace YellowSquad.AssetPath.Samples.Examples
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private ResourcesReference<GameObject> _gameObjectPath;
        [SerializeField] private SerializableAudioSourcePath _audioSources;
        
        private void Awake()
        {
            if (_gameObjectPath.IsNull == false)
                Debug.Log(_gameObjectPath.Load().name);
        }
    }
}