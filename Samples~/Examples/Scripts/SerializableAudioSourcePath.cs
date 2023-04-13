using System;
using System.Collections.Generic;
using UnityEngine;

namespace YellowSquad.AssetPath.Samples.Examples
{
    [Serializable]
    public class SerializableAudioSourcePath
    {
        [SerializeField] private ResourcesReference<AudioSource> _audioSourcePath;
        [SerializeField] private ResourcesReference<AudioSource>[] _audioSourcePathArray;
        [SerializeField] private List<ResourcesReference<AudioSource>> _audioSourcePathList;
    }
}