using UnityEngine;

public class PowerPaper : Paper
{
    public float duration = 5.0f;

    protected override void Eat()
    {
        FindObjectOfType<GameManager>().PowerPaperEaten(this);
    }
}
