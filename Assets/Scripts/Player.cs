using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public GameObject[] FruitPrefabs;

    public Transform InitLocation;
    public GameObject ReadyFruit;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
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

            mousePosition.y = ReadyFruit.transform.position.y;
            mousePosition.z = ReadyFruit.transform.position.z;

            var radius = ReadyFruit.GetComponent<CircleCollider2D>().radius;
            var minX = -3.2 + radius;
            var maxX = 3.2 - radius;

            if (mousePosition.x < minX)
            {
                mousePosition.x = (float)minX;
            }
            else if (mousePosition.x > maxX)
            {
                mousePosition.x = (float)maxX;
            }

            ReadyFruit.transform.position = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ReadyFruit.GetComponent<Rigidbody2D>().gravityScale = 1;

            ReadyFruit = null;

            this.Invoke(nameof(this.CreateFruit), 0.8F);
        }
    }

    private void CreateFruit()
    {
        var index = Random.Range(0, 4);

        ReadyFruit = Instantiate(FruitPrefabs[index]);

        ReadyFruit.transform.position = InitLocation.position;

        ReadyFruit.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
