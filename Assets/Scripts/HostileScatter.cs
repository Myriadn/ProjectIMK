using UnityEngine;

public class HostileScatter : HostileBehaviour
{
    private void OnDisable()
    {
        this.hostile.chase.Enable();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled && !this.hostile.frightened.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            if (node.availableDirections[index] == -this.hostile.movement.direction && node.availableDirections.Count > 1)
            {
                index++;

                if (index == node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            this.hostile.movement.SetDirection(node.availableDirections[index]);
        }
    }
}
