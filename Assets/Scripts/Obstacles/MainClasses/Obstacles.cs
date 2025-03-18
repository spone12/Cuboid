using UnityEngine;

public abstract class Obstacles : MonoBehaviour {
    public string Name { get; protected set; } // Name of the object

    public abstract void Spawn(Vector3 position); // Method for spawn obstacle
}
