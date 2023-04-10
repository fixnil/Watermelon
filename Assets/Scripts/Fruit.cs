using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour
{
    public int Level;

    private int _index;
    private static int _total;

    private bool _isFirstCollide = true;
    private bool _isFirstTrigger = true;

    private void Start()
    {
        _index = _total++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.gameObject;

        if (other.TryGetComponent<Fruit>(out var otherFruit))
        {
            if (this.gameObject != Player.Instance.ReadyFruit && _index > otherFruit._index)
            {
                if (Level != 11 && Level == otherFruit.Level)
                {
                    Player.Instance.New(Level, this.transform.position);

                    AudioManager.Instance.PlayMergeClip();
                    ScoreManager.Instance.Score += Level * 2;

                    Destroy(other);
                    Destroy(this.gameObject);
                }
                else
                {
                    if (_isFirstCollide)
                    {
                        _isFirstCollide = false;

                        AudioManager.Instance.PlayCollideClip();
                    }
                }
            }
        }
        else if (other.CompareTag(Constants.Floor))
        {
            if (_isFirstCollide)
            {
                _isFirstCollide = false;

                AudioManager.Instance.PlayCollideClip();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.DeathLine))
        {
            if (_isFirstTrigger)
            {
                _isFirstTrigger = false;
            }
            else
            {
                this.GameOver();
            }
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(Constants.SampleScene);
    }
}
