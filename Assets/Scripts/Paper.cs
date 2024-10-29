using UnityEngine;

public class Paper : MonoBehaviour
{
    public int points = 10;

    protected virtual void Eat()
    {
        FindObjectOfType<GameManager>().PaperEaten(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Eat();
        }
    }
}
