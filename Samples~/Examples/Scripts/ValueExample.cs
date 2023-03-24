using UnityEngine;

namespace YellowSquad.AssetPath.Samples.Examples
{
    public class ValueExample : MonoBehaviour
    {
        [AssetPath(typeof(GameObject))] [SerializeField] private string _playerPrefab;
        [AssetPath(typeof(Transform))] [SerializeField] private string _playerSpawn;
        [AssetPath(typeof(AudioSource))] [SerializeField] private string _playerAudioSource;
        [SerializeField] private SceneReference _scene;
    }
}
