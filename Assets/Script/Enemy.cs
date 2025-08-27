using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {

    }

    float count = 0;
    Vector3 dir = Vector3.forward;
    void Update()
    {
        count += Time.deltaTime;
        if (count > 1)
        {
            dir *= -1;
            count = 0;
        }
        transform.position += dir * Time.deltaTime;
    }
}
