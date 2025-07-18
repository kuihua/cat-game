using UnityEngine;

public class PlatformCollisions : MonoBehaviour
{
    private Platform[] platforms;
    public static PlatformCollisions instance {get; private set;}
    [SerializeField] private Collider2D objectOnlyPlatform;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platforms = FindObjectsByType<Platform>(FindObjectsSortMode.None);
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void disableCollisionWith(Collider2D collider) {
        foreach(Platform platform in platforms) {
            Physics2D.IgnoreCollision(platform.GetComponent<Collider2D>(), collider, true);
        }
        Physics2D.IgnoreCollision(objectOnlyPlatform, collider, true);
    }
}
