using UnityEngine;

public class GameManager
{
    private static int score = 0;
    private static int lives = 3;

    public void plusScore()
    {
        score += 1;
    }

    public void minusLives()
    {
        lives -= 1;
    }
    
    public int getScore()
    {
        return score;
    }

    public int getLives()
    {
        return lives;
    }
}