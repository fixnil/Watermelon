using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    public Text ScoreText;
    public static ScoreManager Instance;

    public int Score
    {
        get => _score;
        set
        {
            _score = value;

            ScoreText.text = value.ToString().PadLeft(3, '0');
        }
    }

    private void Awake()
    {
        Instance = this;
    }
}
