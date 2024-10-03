using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [Header("lol")]
    [Tooltip("Number of Objects to be instatiated")]
    [Range(1, 10)]
    [SerializeField]
    private int num;
    [HideInInspector]
    public string prefabName;
    [SerializeField]
    private GameObject prefabToInstatiate;

    [Header("lmao even")]
    [SerializeField]
    private int speed;
    //[SerializeField]
    //private Vector3 position;

    [Range(0, 5)]
    [SerializeField]
    private int maxX;
    [Range(0, 5)]
    [SerializeField]
    private int maxY;
    [Range(0, 5)]
    [SerializeField]
    private int maxZ;

    // Start is called before the first frame update
    void Start()
    {
        CreateObjects();
    }
    /// <summary>
    /// We will create a new object instantiating a prefab
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void CreateObject()
    {
        Vector3 randomPos = new Vector3(Random.Range(0, maxX), Random.Range(0, maxY), Random.Range(0, maxZ));
        Instantiate(prefabToInstatiate, randomPos, Quaternion.identity);

    }
    /// <summary>
    /// Creates several objects
    /// </summary>
    private void CreateObjects()
    {
        for (int i = 0; i < num; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(0, maxX), Random.Range(0, maxY), Random.Range(0, maxZ));
            Instantiate(prefabToInstatiate, randomPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateObject();
        }
    }
    /// <summary>
    /// this method will suck
    /// </summary>
    public void Hello()
    {
        print("hi");
    }
}
