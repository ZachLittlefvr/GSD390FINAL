using UnityEngine;

public class PlayerCamera : MonoBehaviour{


    public Transform player;
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        

        
        
        
        

    // Assign value to Camera position
        transform.position = player.position + offset;

    }


}