using UnityEngine;

public class PreviewRotatior : MonoBehaviour
{
    [SerializeField] public Vector3 vector;

    void Update()
    {
        transform.rotation *= Quaternion.Euler(vector * Time.deltaTime);
    }
}