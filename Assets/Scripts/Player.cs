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

    }

    private void Update()
    {

    }
}
