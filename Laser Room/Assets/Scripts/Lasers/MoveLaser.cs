using UnityEngine;

public class MoveLaser : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float distance = 5.0f;

    public enum AxisDirection
    {
        Horizontal,
        Vertical
    }
    
    [SerializeField] private AxisDirection axisDirection = AxisDirection.Horizontal;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        float offset = Mathf.PingPong(Time.time * speed, distance);

        if (axisDirection == AxisDirection.Horizontal)
        {
            transform.localPosition = new Vector3(startPosition.x + offset, startPosition.y, startPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(startPosition.x, startPosition.y + offset, startPosition.z);

        }
    }
}
