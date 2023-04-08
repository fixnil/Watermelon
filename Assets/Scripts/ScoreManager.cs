using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int _score;
    private Text _scoreText;

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            _scoreText.text = value.ToString().PadLeft(3, '0');
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _scoreText = this.transform.Find("ScoreText").GetComponent<Text>();
    }
}
