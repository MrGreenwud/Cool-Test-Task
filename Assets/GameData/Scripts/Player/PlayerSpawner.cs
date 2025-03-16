using Enigmatic.Experimental.Eniject;
using UnityEngine;

namespace Gameplay
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;

        public PlayerController Spawn()
        {
            Vector3 spawnPosition = Vector3.zero;

            PlayerSpawnPoint spawnPoint = FindFirstObjectByType<PlayerSpawnPoint>();

            if (spawnPoint != null)
                spawnPosition = spawnPoint.transform.position;

            GameObject player = Constructor.Instantiate(_playerPrefab);
            player.transform.position = spawnPosition;

            PlayerController playerController = player.GetComponentInChildren<PlayerController>();

            return playerController;
        }
    }
}