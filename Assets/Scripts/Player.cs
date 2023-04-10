using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public GameObject[] FruitPrefabs;

    public Transform InitPostion;
    public GameObject ReadyFruit;

    public GameObject New(int index, Vector3 position)
    {
        var prefab = FruitPrefabs[index];

        var fruit = Instantiate(prefab);

        fruit.transform.position = position;

        return fruit;
    }

    private void Start()
    {
        Instance = this;

        this.CreateFruit();
    }

    private void Update()
    {
        if (ReadyFruit == null)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (ReadyFruit.TryGetComponent<CircleCollider2D>(out var collider))
            {
                var minX = -3.2 + collider.radius;
                var maxX = 3.2 - collider.radius;

                if (mousePosition.x < minX)
                {
                    mousePosition.x = (float)minX;
                }

                if (mousePosition.x > maxX)
                {
                    mousePosition.x = (float)maxX;
                }
            }

            mousePosition.y = ReadyFruit.transform.position.y;
            mousePosition.z = ReadyFruit.transform.position.z;

            ReadyFruit.transform.position = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (ReadyFruit.TryGetComponent<Rigidbody2D>(out var rigidbody))
            {
                rigidbody.gravityScale = 1;
            }

            ReadyFruit = null;

            this.Invoke(nameof(this.CreateFruit), 0.8F);
        }
    }

    private void CreateFruit()
    {
        var index = Random.Range(0, 4);

        ReadyFruit = this.New(index, InitPostion.position);

        if (ReadyFruit.TryGetComponent<Rigidbody2D>(out var rigidbody))
        {
            rigidbody.gravityScale = 0;
        }
    }
}
