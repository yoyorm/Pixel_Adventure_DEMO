using TMPro;


public class PlayerUI : BaseUI<PlayerUI>
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        timeText.text = $"Time: {(int)LevelManager.Instance.GetTimeCost()}";
        scoreText.text = $"Score: {LevelManager.Instance.GetScore()}";
    }
}
