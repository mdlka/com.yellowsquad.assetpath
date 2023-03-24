using UnityEngine;
using UnityEngine.UI;

namespace YellowSquad.AssetPath.Samples.Examples
{
    public class TypeExamples : MonoBehaviour
    {
        [AssetPath(typeof(Object))] [SerializeField] private string _objectValue;
        [AssetPath(typeof(GameObject))] [SerializeField] private string _gameObjectValue;
        [AssetPath(typeof(AudioClip))] [SerializeField] private string _audioClipValue;
        [AssetPath(typeof(ScriptableObject))] [SerializeField] private string _scriptableObject;
        [AssetPath(typeof(Texture2D))] [SerializeField] private string _texture2D;
        [AssetPath(typeof(Animator))] [SerializeField] private string _animator;
        [AssetPath(typeof(AudioSource))] [SerializeField] private string _audioSource;
        [AssetPath(typeof(Transform))] [SerializeField] private string _transform;
        [AssetPath(typeof(Image))] [SerializeField] private string _image;
        [AssetPath(typeof(GameObject))] [SerializeField] private string _playerPrefab;

        public void Awake()
        {
            GameObject player = Resources.Load<GameObject>(new ResourcesPath(_playerPrefab).Value());
            Debug.Log(player.name);
        }
    }
}
