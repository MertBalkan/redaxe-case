using System;
using UnityEngine;

namespace RedAxeCase
{
    public class PlayerGarageManager : SingletonMonoBehaviour<PlayerGarageManager>
    {
        [SerializeField] private PlayerGarageCarSpawner _playerGarageCarSpawner;
        public PlayerGarageCarSpawner PlayerGarageCarSpawner { get => _playerGarageCarSpawner; set => _playerGarageCarSpawner = value; }

        protected override void Awake()
        {
            base.Awake();
            _playerGarageCarSpawner = FindObjectOfType<PlayerGarageCarSpawner>();
        }
    }
}
