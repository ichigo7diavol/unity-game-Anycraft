using System;
using UnityEngine;

namespace Anycraft.Features.SceneLoader
{
    [Serializable]
    public sealed partial class SceneReference
    {
        [HideInInspector]
        [SerializeField] private string _path;
        [HideInInspector]
        [SerializeField] private int _buildIndex;
    
    
        private string Path => _path;
        private int BuildIndex => _buildIndex;
    }
}