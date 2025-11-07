using UnityEngine;

public class CreateBall : MonoBehaviour
{
    public GameObject prefab;
    private float elapsedTime = 0f;

    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Color color = RandomColor();
            Vector3 randPos = RandomPos(-10f, 10f);
            GameObject ball = CreateBallColor(color, randPos);
            DestroyBall(ball); // destroy after 3 seconds
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1f)
        {
            Color color = RandomColor();
            Vector3 randPos = RandomPos(-10f, 10f);
            GameObject ball = CreateBallColor(color, randPos);
            DestroyBall(ball); // destroy after 3 seconds
            elapsedTime = 0f;
        }
    }

    private GameObject CreateBallColor(Color color, Vector3 position)
    {
        GameObject ball = Instantiate(prefab, position, Quaternion.identity);
        Material material = ball.GetComponent<MeshRenderer>().material;

        material.SetColor("_Color", color);

        if (material.shader.name == "Universal Render Pipeline/Lit")
        {
            material.SetColor("_BaseColor", color);
        }
        return ball;
    }

    private void DestroyBall(GameObject ball)
    {
        Destroy(ball, 3f);
    }

    private Color RandomColor()
    {
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            1f
        );
    }

    private Vector3 RandomPos(float min, float max)
    {
        return new Vector3(
            Random.Range(min, max),
            Random.Range(min, max),
            0
        );
    }
}