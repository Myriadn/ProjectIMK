using UnityEngine;

public class Hostile : MonoBehaviour
{
    public Movement movement { get; private set; }
    public HostileHome home { get; private set; }
    public HostileScatter scatter { get; private set; }
    public HostileChase chase { get; private set; }
    public HostileFrightened frightened { get; private set; }
    public HostileBehaviour initialBehaviour;
    public Transform target;
    public int points = 65;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<HostileHome>();
        this.scatter = GetComponent<HostileScatter>();
        this.chase = GetComponent<HostileChase>();
        this.frightened = GetComponent<HostileFrightened>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();

        this.frightened.Disable();
        this.chase.Disable();
        this.scatter.Enable();

        if (this.home != this.initialBehaviour)
        {
            this.home.Disable();
        }

        if (this.initialBehaviour != null)
        {
            this.initialBehaviour.Enable();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (this.frightened.enabled)
            {
                FindObjectOfType<GameManager>().HostileEaten(this);
            }
            else
            {
                FindObjectOfType<GameManager>().PlayerEaten();
            }
        }
    }
}
