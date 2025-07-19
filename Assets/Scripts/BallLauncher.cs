using UnityEngine;

public class BallLauncher : Interactable
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform ballSpawnPos;
    [SerializeField] private Vector2 ballDirection;
    [SerializeField] private float ballSpeed;

    float ballsLeft = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void interact() {
        if(ballsLeft > 0) {
            GameObject ball = Instantiate(ballPrefab, ballSpawnPos.position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().linearVelocity = ballDirection.normalized * ballSpeed;
            ballsLeft--;
        }
    }

    // prob have to delete before build
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(ballSpawnPos.position, (Vector2)ballSpawnPos.position + ballDirection);
    }
}
