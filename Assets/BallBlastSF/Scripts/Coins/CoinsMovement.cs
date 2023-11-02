using UnityEngine;

public class CoinsMovement : MonoBehaviour
{
    [SerializeField] private float gravity;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float reboundSpeed;
    [SerializeField] private float gravityOffset;

    private Vector3 velocity;
    private bool UseGravity;

    private void Awake()
    {
        velocity.x = -Mathf.Sign(transform.position.x) * horizontalSpeed;
    }

    private void Update()
    {
        TryEnableGravity();
        Move();
    }

    private void TryEnableGravity()
    {
        if (Mathf.Abs(transform.position.x) <= Mathf.Abs(LevelBoundary.Instance.LeftBorder) - gravityOffset)
        {
            UseGravity = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();

        if (levelEdge != null)
        {
            if (levelEdge.Type == EdgeType.Bottom)
            {
                velocity.y = reboundSpeed;
            }

            if (levelEdge.Type == EdgeType.Left && velocity.x < 0 || levelEdge.Type == EdgeType.Right && velocity.x > 0)
            {
                velocity.x *= -1;
            }
        }

    }

    private void Move()
    {
        if (UseGravity == true)
        {
            velocity.y -= gravity * Time.deltaTime;
        }

        velocity.x = Mathf.Sign(velocity.x) * horizontalSpeed;

        transform.position += velocity * Time.deltaTime;
    }

    public void AddVerticalVelosity(float velocity)
    {
        this.velocity.y += velocity;
    }

    public void SetHorizontalDirection(float direction)
    {
        velocity.x = Mathf.Sign(direction) * horizontalSpeed;
    }
}
