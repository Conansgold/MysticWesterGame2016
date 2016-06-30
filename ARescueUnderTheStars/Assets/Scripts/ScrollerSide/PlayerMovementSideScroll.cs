using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController2D))]
public class PlayerMovementSideScroll : MonoBehaviour
{
    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    public float moveSpeed = 5;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .25f;
    float timeToWallUnstick;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    PlayerController2D controller;

    public Transform firePoint;
    public GameObject gunBullet;

    bool m_isAxisInUse = false;

    private Quaternion pieceRotation;
    private float shotTimer = 0;
    private int clipLeft = 60;
    private float shotTimerReset = .5f;


    public int starCount = 0;
    public AudioClip FireSound;
   

    void Start()
    {
        controller = GetComponent<PlayerController2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }


     void OnGUI()
     {
        GUI.Label(new Rect(15 , 10, 200, 100), starCount + " / 5");
     }


     void Update()
     {
         if(starCount == 5)
         {
             Camera.main.orthographicSize = 55;
             GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().target = GameObject.FindGameObjectWithTag("Paralax");
         }

         if (shotTimer <= 0 && Input.GetAxisRaw("Fire1") != 0)
         {
             if (m_isAxisInUse == false)
             {
                 GetComponent<AudioSource>().clip = FireSound;
                 pieceRotation = Quaternion.AngleAxis(90, Vector3.forward);
                 GetComponent<AudioSource>().volume = .03f;
                 GetComponent<AudioSource>().Play();
                 Instantiate(gunBullet, firePoint.position, pieceRotation);


                 clipLeft -= 1;
                 shotTimer = shotTimerReset;

                 m_isAxisInUse = true;

             }
         }
         if (Input.GetAxisRaw("Fire1") == 0)
         {
             m_isAxisInUse = false;
         }

         shotTimer -= Time.deltaTime;
         Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
         int wallDirX = (controller.collisions.left) ? -1 : 1;

         controller.FaceDir(input);

         float targetVelocityX = input.x * moveSpeed;
         velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

         bool wallSliding = false;
         if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
         {
             wallSliding = true;

             if (velocity.y < -wallSlideSpeedMax)
             {
                 velocity.y = -wallSlideSpeedMax;
             }

             if (timeToWallUnstick > 0)
             {
                 velocityXSmoothing = 0;
                 velocity.x = 0;

                 if (input.x != wallDirX && input.x != 0)
                 {
                     timeToWallUnstick -= Time.deltaTime;
                 }
                 else {
                     timeToWallUnstick = wallStickTime;
                 }
             }
             else {
                 timeToWallUnstick = wallStickTime;
             }

         }

         if (Input.GetKeyDown(KeyCode.Space))
         {
             if (wallSliding)
             {
                 if (wallDirX == input.x)
                 {
                     velocity.x = -wallDirX * wallJumpClimb.x;
                     velocity.y = wallJumpClimb.y;
                 }
                 else if (input.x == 0)
                 {
                     velocity.x = -wallDirX * wallJumpOff.x;
                     velocity.y = wallJumpOff.y;
                 }
                 else {
                     velocity.x = -wallDirX * wallLeap.x;
                     velocity.y = wallLeap.y;
                 }
             }
             if (controller.collisions.below)
             {
                 velocity.y = maxJumpVelocity;
             }
         }
         if (Input.GetKeyUp(KeyCode.Space))
         {
             if (velocity.y > minJumpVelocity)
             {
                 velocity.y = minJumpVelocity;
             }
         }


         velocity.y += gravity * Time.deltaTime;
         controller.Move(velocity * Time.deltaTime, input);

         if (controller.collisions.above || controller.collisions.below)
         {
             velocity.y = 0;
         }

     }

     void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Star")
         {
             if (!coll.GetComponent<Star>().collected)
             {
                 starCount += 1;
                 /*
                 coll.transform.localScale = coll.transform.localScale * .25f;
                 coll.transform.parent = GameObject.FindGameObjectWithTag("Paralax").transform;
                 for (int i = 0; i < coll.gameObject.transform.childCount; i++)
                 {
                     Transform Go = coll.gameObject.transform.GetChild(i);
                     Go.localScale = Go.localScale * .25f;
                 }
                 coll.transform.position = coll.GetComponent<Star>().StarLocation;*/
                coll.GetComponent<Star>().collected = true;
                coll.GetComponent<Star>().target.SetActive(true);
            }
            Destroy(coll.gameObject);
        }
        if(coll.transform.tag == "Dimmer")
        {
            GameObject.FindGameObjectWithTag("MainLight").GetComponent<Light>().intensity -= .1f;
        }

        if (coll.transform.tag == "FadeTo1")
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioFade>().fadingto1 = true;
        }
        if (coll.transform.tag == "FadeTo2")
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioFade>().fadingto2 = true;
        }
        if (coll.transform.tag == "FadeTo3")
        {
            Debug.Log("Music3");
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioFade>().fadingto3 = true;
        }

    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.transform.tag == "Dimmer")
        {
            Debug.Log("Dimmed");
            GameObject.FindGameObjectWithTag("MainLight").GetComponent<Light>().intensity += .1f;
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.transform.tag == "Box")
        {
           // coll.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(5* velocity.x, -1), gameObject.transform.position);
        }
        
        if (coll.transform.tag == "Door")
        {
            if (coll.GetComponent<DoorInformation>().optional)
            {
                if (Input.GetAxis("Vertical") > .6)
                {
                    transform.position = coll.GetComponent<DoorInformation>().TargetDoor.transform.position + new Vector3( coll.GetComponent<DoorInformation>().xOffset, 0);
                }
            }
            else
            {
                Debug.Log("And time to teleport");
                transform.position = coll.GetComponent<DoorInformation>().TargetDoor.transform.position + new Vector3(coll.GetComponent<DoorInformation>().xOffset, 0);
            }
        }

    }

   void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Topple")
        {
            ;//coll.rigidbody.AddForceAtPosition(velocity * 15 + new Vector3(0,-3), gameObject.transform.position);
        }
    }
}
