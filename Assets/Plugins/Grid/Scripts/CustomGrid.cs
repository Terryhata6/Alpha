using UnityEngine;

public class CustomGrid : MonoBehaviour
{

    [SerializeField] private float gridSize;

    private Vector3 truePosition;

    private void LateUpdate()
    {
        truePosition.x = Mathf.Floor(gameObject.transform.position.x / gridSize) * gridSize;
        truePosition.y = Mathf.Floor(gameObject.transform.position.y / gridSize) * gridSize;
        truePosition.z = Mathf.Floor(gameObject.transform.position.z / gridSize) * gridSize;

        gameObject.transform.position = truePosition;
    }
}
