using UnityEngine;

public class Tower : MonoBehaviour
{
    public void Scale(float min, float max)
    {
        float randNo = Random.Range(min, max);
        float y = Random.Range(min, max);
        gameObject.transform.localScale = new Vector3(randNo, y, randNo);
    }
}