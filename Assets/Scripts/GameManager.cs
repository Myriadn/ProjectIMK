using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Hostile[] hostiles;
    public Player player;
    public Transform pellets;
    public int score { get; private set; }
    public int lives { get; private set; }
    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }
    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        foreach (Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        for (int i = 0; i < this.hostiles.Length; i++)
        {
            this.hostiles[i].gameObject.SetActive(true);
        }

        this.player.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        for (int i = 0; i < this.hostiles.Length; i++)
        {
            this.hostiles[i].gameObject.SetActive(false);
        }

        this.player.gameObject.SetActive(false);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void HostileEaten(Hostile hostile)
    {
        SetScore(this.score + hostile.points);
    }

    public void PlayerEaten()
    {
        SetLives(this.lives - 1);

        if (this.lives > 0)
        {
            Invoke(nameof(ResetState), 3.0f);
        }
        else
        {
            GameOver();
        }
    }
}
