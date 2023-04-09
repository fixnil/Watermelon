using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour
{
    public int Level;

    private long _createTime;
    private bool _isFirstCollide = true;
    private bool _isFirstTrigger = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.gameObject;

        if (other.CompareTag(Constants.Fruit) &&
            Player.Instance.ReadyFruit != this.gameObject)
        {
            var otherFruit = other.GetComponent<Fruit>();

            if (otherFruit.Level == Level && _createTime > otherFruit._createTime)
            {
                var prefab = Player.Instance.FruitPrefabs[Level];
                var fruit = Instantiate(prefab);

                fruit.transform.position = this.transform.position;

                AudioManager.Instance.PlayMergeClip();
                ScoreManager.Instance.Score += Level * 2;

                Destroy(other);
                Destroy(this.gameObject);
            }
            else if (_createTime > otherFruit._createTime)
            {
                if (_isFirstCollide)
                {
                    _isFirstCollide = false;

                    AudioManager.Instance.PlayCollideClip();
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
        var top = collision.gameObject;

        if (top.CompareTag(Constants.DeathLine))
        {
            if (_isFirstTrigger)
            {
                _isFirstTrigger = false;
            }
            else
            {
                SceneManager.LoadScene(Constants.SampleScene);
            }
        }
    }

    private void Start()
    {
        _createTime = DateTime.Now.Ticks;
    }
}
