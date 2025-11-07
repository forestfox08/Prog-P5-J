using Unity.VisualScripting;
using UnityEngine;

public class Towerspawner : MonoBehaviour
{
    public GameObject Tower;
    private Tower towerClass;

    private void Start()
    {
        towerClass = Tower.GetComponent<Tower>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            towerClass.Scale(0.1f, 5f);
            Instantiate(Tower, RandomPos(-10f, 10f), Quaternion.identity);
        }
    }
    private Vector3 RandomPos(float min, float max)
    {
        float x = Random.Range(min, max);
        float y = Tower.transform.localScale.y;
        float z = Random.Range(min, max);
        Vector3 randPos = new Vector3((float)x, (float)y, (float)z);
        return randPos;
    }
}
