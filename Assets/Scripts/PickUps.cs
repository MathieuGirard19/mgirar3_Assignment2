using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUps : MonoBehaviour
{
    private List<GameObject> _gameObjectList;
    private List<Color> _cubeColors;
    private GameObject _tempObj;
    public float radius = 10f;
    public float rotationSpeed;
    public Vector3 rotationAngle;
    public GameObject prefab;
    public int numObjects = 8;

    // Start is called before the first frame update

    void Start()
    {
        _cubeColors = new List<Color>();
        _gameObjectList = new List<GameObject>();
        _cubeColors.Add(Color.blue);
        _cubeColors.Add(Color.red);
        _cubeColors.Add(Color.yellow);
        for (int i = 0; i < numObjects; i++)
        {
            //split circle into equal amount of angles, then pick angle using i
            float angle = i * Mathf.PI * 2 / numObjects;
            //set position of new object using x and z coordinates, then put to radius
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0.1f, Mathf.Sin(angle)) * radius;
            //initiate and set to temp
            _tempObj = Instantiate(prefab, pos, new Quaternion(90f, 45f, 45f, 0f));
            //set the color of the object randomly from the list of colors
            _tempObj.GetComponent<Renderer>().material.color = _cubeColors[Random.Range(0, 3)];
            _gameObjectList.Add(_tempObj);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //access the list and rotate each cube in list
        foreach (GameObject temp in _gameObjectList)
        {
            temp.transform.Rotate(rotationAngle * rotationSpeed, Space.World);
        }

    }

    

    //  void OnTriggerEnter(Collider other)
    // {
    //     print("in");
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         print("hit");
    //         gameObject.SetActive(false);
    //     }
    // }
    
}
