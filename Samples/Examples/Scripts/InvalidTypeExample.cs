using UnityEngine;
using UnityEngine.UI;

namespace YellowSquad.AssetPath.Samples.Examples
{
    public class InvalidTypeExample : MonoBehaviour
    {
        [AssetPath(typeof(Object))] [SerializeField] private Object _objectValue;
        [AssetPath(typeof(GameObject))] [SerializeField] private GameObject _gameObjectValue;
        [AssetPath(typeof(AudioClip))] [SerializeField] private AudioClip _audioClipValue;
        [AssetPath(typeof(ScriptableObject))] [SerializeField] private ScriptableObject _scriptableObject;
        [AssetPath(typeof(Texture2D))] [SerializeField] private Texture2D _texture2D;
        [AssetPath(typeof(Animator))] [SerializeField] private Animator _animator;
        [AssetPath(typeof(AudioSource))] [SerializeField] private AudioSource _audioSource;
        [AssetPath(typeof(Transform))] [SerializeField] private Transform _transform;
        [AssetPath(typeof(Image))] [SerializeField] private Image _image;
    }
}