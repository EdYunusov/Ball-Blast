using UnityEngine;
using UnityEngine.Events;

public class Cart : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private LevelBoundary levelBoundary;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float vehicleWidth;

    [Header("Wheels")]
    [SerializeField] private Transform[] wheels;
    [SerializeField] private float wheelRadius;

    [HideInInspector] public UnityEvent CollisionStone;

    private Vector3 movementTarget;
    private float deltaMovement;
    private float lastPositionsX;

    private void Start()
    {
        movementTarget = transform.position;
    }

    private void Update()
    {
        Move();
        RotateWheel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Stone stone = collision.transform.root.GetComponent<Stone>();

        if (stone != null)
        {
            CollisionStone.Invoke();
        }
    }

    private void Move()
    {
        lastPositionsX = transform.position.x;

        transform.position = Vector3.MoveTowards(transform.position, movementTarget, movementSpeed * Time.deltaTime);

        deltaMovement = transform.position.x - lastPositionsX;
    }

    private void RotateWheel()
    {
        float angle = (180 * deltaMovement) / (Mathf.PI * wheelRadius * 2);

        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].transform.Rotate(new Vector3(0, 0, -angle));
        }
    }

    public void SetMovementTarget(Vector3 target)
    {
        movementTarget = ClampMovementTarget(target);
    }

    private Vector3 ClampMovementTarget(Vector3 target)
    {
        float left_border = LevelBoundary.Instance.LeftBorder + vehicleWidth * 0.5f;
        float right_border = LevelBoundary.Instance.RightBorder - vehicleWidth * 0.5f;

        Vector3 movTarget = target;

        movTarget.z = transform.position.z;
        movTarget.y = transform.position.y;

        if (movTarget.x < left_border) movTarget.x = left_border;
        if (movTarget.x > right_border) movTarget.x = right_border;

        return movTarget;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position - new Vector3(vehicleWidth * 0.5f, 0.5f, 0), transform.position + new Vector3(vehicleWidth * 0.5f, -0.5f, 0));
    }
#endif
}
