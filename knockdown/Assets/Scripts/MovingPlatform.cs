using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float distance = 5.0f;

    public enum AxisDirection
    {
        Horizontal,
        Vertical
    }
    [SerializeField] private AxisDirection axis =  AxisDirection.Horizontal; 
    private Vector3 startPos;
    
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.PingPong(Time.time * speed, distance);

        if (axis == AxisDirection.Horizontal)
        {
            transform.position = new Vector3(startPos.x + offset, startPos.y, startPos.z);
        }
        else
        {
            transform.position = new Vector3(startPos.x, startPos.y + offset, startPos.z);

        }
        
    }
}
