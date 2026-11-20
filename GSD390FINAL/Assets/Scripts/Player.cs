using UnityEngine;
using UnityEngine.SceneManagement;
//Player inherits monoBehaviour
public class Player : MonoBehaviour
{


    public float jumpHeight;
    public float moveSpeed;
    //accessing the rigidbody property
    public Rigidbody rb;
    private Vector3 move;
    private bool isGrounded;
    private int Boost;
    private int BoostTimer;
    //start is used to initialize jumpHeight here
    void Start()
    {
        //start at 4 jump height
        BoostTimer = 100;
        Boost = 1;
        moveSpeed = 15;
        isGrounded = true;
        Renderer renderer = GetComponent<Renderer>();
    }



    void Update()
    {
        if(BoostTimer > 100)
        {
            Material mat = GetComponent<Renderer>().material;
            //green
            mat.color = new Color(0,1,0,1);

        }
        else
        {
            Material mat = GetComponent<Renderer>().material;
            //blue
            mat.color = new Color(0,0,1,1);
        }
        //calls jump if space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump(jumpHeight);
            isGrounded = false;
        }
        //resets game
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }
        
        if(Input.GetKeyDown(KeyCode.LeftShift) && BoostTimer > 100){
            Boost = 100;
            BoostTimer = 0;
        }
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveZ = Input.GetAxisRaw("Vertical");   
        move = new Vector3(moveX, 0, moveZ).normalized;
        

        //movement
        
        
    }
    void FixedUpdate(){
                BoostTimer = BoostTimer + 1;
                rb.AddForce(move * moveSpeed * Boost, ForceMode.Force);
                Boost = 1;
    }
    //adds upward force to the player
    void Jump(float height)
    {
        //modifies the property

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, height, rb.linearVelocity.z);

    }   
    void OnCollisionEnter (Collision hit)
{
     if(hit.transform.gameObject.tag == "Enemy")
     {
          SceneManager.LoadScene("GameOver");
     }
     if(hit.transform.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
}
    /*
    void Move(float direction)
    {
        //modifies the property
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, height, rb.linearVelocity.z);

    }
    */


}

