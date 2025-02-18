using UnityEngine;

public class ObjectDynamic : MonoBehaviour
{

    public Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f); // Minimum size
    public Vector3 maxScale = new Vector3(3f, 3f, 3f); // Maximum size
    public float speed = 2f; // Rate of change

    private Vector3 targetScale;

    void Start() {
        setRandomRange();
    }

    void Update() {
        // Smoothly resize
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);

        // If the target size is reached, select a new random size
        if (Vector3.Distance(transform.localScale, targetScale) < 0.01f) {
            setRandomRange();
        }
    }

    private void setRandomRange() {
        // Set a random size within minScale and maxScale
        targetScale = new Vector3(
            Random.Range(minScale.x, maxScale.x),
            Random.Range(minScale.y, maxScale.y),
            Random.Range(minScale.z, maxScale.z)
        );
    }
}
