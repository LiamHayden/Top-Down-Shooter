using UnityEngine;
using UnityEngine.Rendering;

public class EnemyController : MonoBehaviour
{
    public float forwardSpeed;
    void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.back * forwardSpeed * Time.deltaTime);
    }
}
