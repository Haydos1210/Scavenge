using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Input input = GetComponent<Input>();
        transform.Translate(Vector3.forward * Time.deltaTime); 
    }
}
