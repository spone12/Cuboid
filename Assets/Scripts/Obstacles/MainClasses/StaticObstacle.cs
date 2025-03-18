using UnityEngine;

public abstract class StaticObstacle : Obstacles {
    public override void Spawn(Vector3 position) {
        Instantiate(gameObject, position, Quaternion.identity);
    }
}
