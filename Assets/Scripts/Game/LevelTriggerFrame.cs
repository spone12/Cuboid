using UnityEngine;

public class LevelTriggerFrame : MonoBehaviour {
    public Color lineColor = Color.green; // Edge colour
    public float lineWidth = 0.05f; // Line thickness

    private LineRenderer lr; // Storing a link to LineRenderer

    void Start() {
        DrawWireframe();
    }

    void DrawWireframe() {
        // Check if there is already a LineRenderer, if not - add it
        lr = GetComponent<LineRenderer>();
        if (lr == null) {
            lr = gameObject.AddComponent<LineRenderer>();
        }

        // Configuring LineRenderer
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = lineColor;
        lr.endColor = lineColor;
        lr.positionCount = 16; // Number of vertices
        lr.useWorldSpace = false;

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, 0.5f), new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f), new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, 0.5f), new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f), new Vector3(0.5f, 0.5f, 0.5f)
        };

        lr.SetPositions(vertices);
        lr.loop = true; // Close the lines
    }
}
