using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameOver GameOverScreen;
    public GameWin GameWinScreen;
    public Hostile[] hostiles;
    public Player player;
    public Transform papers;

    public int hostileMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }
    private void Start()
    {
        Time.timeScale = 1f;
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
        foreach (Transform paper in this.papers)
        {
            paper.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        ResetHostileMultiplier();

        for (int i = 0; i < this.hostiles.Length; i++)
        {
            this.hostiles[i].ResetState();
        }

        this.player.ResetState();
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
        Time.timeScale = 0f;

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
        int points = hostile.points * this.hostileMultiplier;
        SetScore(this.score + points);
        this.hostileMultiplier++;
    }

    public void PlayerEaten()
    {
        this.player.gameObject.SetActive(false);

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

    public void PaperEaten(Paper paper)
    {
        paper.gameObject.SetActive(false);

        SetScore(this.score + paper.points);

        if (!HasRemainingPaper())
        {
            GameWinScreen.Setup();
            Time.timeScale = 0f;

            this.player.gameObject.SetActive(false);
            Invoke(nameof(ResetState), 3.0f);
        }
    }

    public void PowerPaperEaten(PowerPaper paper)
    {
        for (int i = 0; i < this.hostiles.Length; i++)
        {
            this.hostiles[i].frightened.Enable(paper.duration);
        }

        PaperEaten(paper);
        CancelInvoke();
        Invoke(nameof(ResetHostileMultiplier), paper.duration);
    }

    private bool HasRemainingPaper()
    {
        foreach (Transform paper in this.papers)
        {
            if (paper.gameObject.activeSelf)
            {
                return true;
            }
        }

        return false;
    }

    private void ResetHostileMultiplier()
    {
        this.hostileMultiplier = 1;
    }
}
