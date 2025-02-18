using UnityEngine;

public class WallSpawner : MonoBehaviour {

    public GameObject cubePrefab; // Prefab cube
    public Transform ground; // Reference to the Ground object
    public Transform container; // Container for created cubes
    public int cubeCount = 100; // Number of cubes
    public float cubeHeight = 0.5f; // Height of the cube above the surface

    void Start() {
        SpawnCubes();
    }

    void SpawnCubes() {
        // Getting the boundaries "Ground"
        Renderer groundRenderer = ground.GetComponent<Renderer>();
        Vector3 groundSize = groundRenderer.bounds.size;
        Vector3 groundPosition = ground.position;

        for (int i = 0; i < cubeCount; i++) {
            // Random position on the Ground surface
            float randomX = Random.Range(groundPosition.x - groundSize.x / 2, groundPosition.x + groundSize.x / 2);
            float randomZ = Random.Range(groundPosition.z - groundSize.z / 2, groundPosition.z + groundSize.z / 2);
            Vector3 spawnPosition = new Vector3(randomX, groundPosition.y + cubeHeight, randomZ);

            // Create a cube inside the container
            GameObject newCube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity, container);
        }
    }
}
