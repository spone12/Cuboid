using System;
using System.Linq;
using UnityEngine;

public class WallSpawner : MonoBehaviour {

    public GameObject[] prefabObstacles; // Obstacles prefabs

    [SerializeField]
    private string _groundTag = "Ground"; // Tag reference to the Ground object
    private Transform _container; // The container where the obstacles will appear.
    public float appearanceHeight = 0.5f; // Height of appearance above the ground

    [SerializeField]
    private int _obstacleCount = 100; // Number of cubes
    [SerializeField]
    private bool _isDynamicObstacleCount = true;
    [SerializeField]
    private float _spawnPercentage = 8f; // Percentage of occurrence of obstacles at one site

    void Start() {
        SpawnCubes();
    }

    void SpawnCubes() {

        if (prefabObstacles.Length == 0) {
            return;
        }

        GameObject[] _groundObjects = GameObject.FindGameObjectsWithTag(_groundTag);

        foreach (GameObject ground in _groundObjects) {
            // Getting the boundaries "Ground"
            Renderer groundRenderer = ground.GetComponent<Renderer>();

            if (groundRenderer == null) {
                continue;
            }

            Vector3 groundSize = groundRenderer.bounds.size;
            Vector3 groundPosition = ground.transform.position;

            int obstacleCount = _obstacleCount;
            if (_isDynamicObstacleCount) {
                obstacleCount = CalculateObstacleCount(groundSize.z, _spawnPercentage);
            }

            for (int i = 0; i < obstacleCount; i++) {
                // Random position on the Ground surface
                float randomX = UnityEngine.Random.Range(groundPosition.x - groundSize.x / 2, groundPosition.x + groundSize.x / 2);
                float randomZ = UnityEngine.Random.Range(groundPosition.z - groundSize.z / 2, groundPosition.z + groundSize.z / 2);
                Vector3 spawnPosition = new Vector3(randomX, groundPosition.y + appearanceHeight, randomZ);

                // We get a random prefab
                GameObject randomObstacle = prefabObstacles[UnityEngine.Random.Range(0, prefabObstacles.Length)];

                // Create a cube inside the container
                Instantiate(randomObstacle, spawnPosition, Quaternion.identity, _container);
            }
        }
    }

    /**
     * Adding an object to be drawn on the map
     */
    public void AddprefabObstacles(GameObject obj) {
        prefabObstacles.Append(obj);
    }

    /**
     * Calculate obstacles count
     */
    private int CalculateObstacleCount(float objectLength, float percentage) {
        return Mathf.RoundToInt((objectLength * percentage) / 100f);
    }
}
