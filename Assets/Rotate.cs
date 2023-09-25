using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speedRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, speedRotation) * Time.deltaTime);
    }
}
