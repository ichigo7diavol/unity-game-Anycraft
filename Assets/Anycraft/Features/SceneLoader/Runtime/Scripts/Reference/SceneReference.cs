using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.SceneLoader
{
    [Serializable]
    [UsedImplicitly]
    public sealed partial class SceneReference
    {
        [HideInInspector]
        [SerializeField] private string _path;
        [HideInInspector]
        [SerializeField] private int _buildIndex;
    
        public string Path => _path;
        public int BuildIndex => _buildIndex;

        public SceneReference()
        {
        }

        public SceneReference(string path, int buildIndex)
        {
        }
    }
}