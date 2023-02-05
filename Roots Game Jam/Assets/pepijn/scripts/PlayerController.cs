using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    private float direction = 0f;
    private Rigidbody2D player;
    //GroundCheck
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    [Header("Camera")]
    public GameObject camera;
    [Range(0, 50)] public float FollowSpeed;
    [Header("Roots")]
    public GameObject rootPrefab;
    public GameObject rootMover;
    public Line activeRoot;
    public Line previousRoot;
    public float speedModifier;
    public float rotationForce;
    public bool isRooting;
    public bool hitStone;
    public float WaterLevel;
    public RootCollide rootCollisionCheck;
    [Header("RootSplitter")]
    public bool isSplitting;
    public int selectionIndex;
    public GameObject selectionObject;
    public GameObject selectionObjectPrefab;


    [Header("EnergyIntegration")]
    public EnergyManager energyman;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (!isRooting && !isSplitting)
        {
            MoveCamera(transform);
            HandleMovement();
        }
        HandleRoot();
        HandleSplit();
        if (isSplitting)
        {
            MoveCamera(selectionObject.transform);
        }
        if (isRooting)
        {
            MoveCamera(rootMover.transform);
        }
    }

    public void HandleMovement()
    {
        //basic movement mechanics

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }
    }

    public void MoveCamera(Transform target)
    {
        Vector3 newPosition = target.position;
        newPosition.z = -10;
        camera.transform.position = Vector3.Lerp(camera.transform.position, newPosition, FollowSpeed * Time.deltaTime);
    }

    public void HandleRoot()
    {
        direction = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTouchingGround && activeRoot == null && energyman.currentWaterEnergy > 0 && !hitStone)
            {
                if (!isSplitting)
                {
                    isRooting = true;
                    GameObject newRoot = Instantiate(rootPrefab);
                    WaterLevel = energyman.GetWater();
                    activeRoot = newRoot.GetComponent<Line>();
                }
                else
                {
                    rootMover.transform.position = selectionObject.transform.position;
                    float angle = Random.Range(-180,181);
                    rootMover.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); ;
                    isRooting = true;
                    isSplitting = false;
                    GameObject newRoot = Instantiate(rootPrefab);
                    WaterLevel = energyman.GetWater();
                    activeRoot = newRoot.GetComponent<Line>();
                }
            }
            else if (activeRoot != null)
            {
                isRooting = false;
                hitStone = false;
                activeRoot.SetWaterUsed(WaterLevel-energyman.currentWaterEnergy);
                previousRoot = activeRoot;
                activeRoot = null;
                rootMover.transform.position = new Vector2(transform.position.x, transform.position.y - 1.2f);
                rootMover.transform.rotation = groundCheck.rotation;
            }
        }


        if (activeRoot != null && energyman.currentWaterEnergy > 0)
        {
            energyman.UseWaterDirt();
            MoveRootMover(direction);
            activeRoot.UpdateLine(rootMover.transform.position);
            activeRoot.SetCollider();
            switch (rootCollisionCheck.col.layer)
            {
                case 6:
                    speedModifier = 3;
                    energyman.UseWaterDirt();
                    break;
                case 7:
                    energyman.GainWaterPrecise(WaterLevel*0.75f);
                    hitStone = true;
                    activeRoot.slingRootBack();
                    isRooting = false;
                    hitStone = false;
                    activeRoot = null;
                    rootMover.transform.position = new Vector2(transform.position.x, transform.position.y - 1.2f);
                    rootMover.transform.rotation = groundCheck.rotation;
                    break;
                case 8:
                    if (energyman.currentSunEnergy > 0) {
                        speedModifier = 2;
                        energyman.UseWaterMoss();
                        energyman.UseSun();
                    }
                    else
                    {
                        hitStone = true;
                        activeRoot.slingRootBack();
                        isRooting = false;
                        hitStone = false;
                        activeRoot = null;
                        rootMover.transform.position = new Vector2(transform.position.x, transform.position.y - 1.2f);
                        rootMover.transform.rotation = groundCheck.rotation;
                    }
                    break;
                default:
                    speedModifier = 3;
                    break;
            }
        }
        

        
    }

    public void HandleSplit()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!isSplitting)
            {
                isSplitting = true;
                selectionIndex = 0;
            }
            else
            {
                isSplitting = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && isSplitting)
        {
            if (selectionIndex > 10) selectionIndex-=7;
            else selectionIndex = previousRoot.lr.positionCount - 1;
        }
        if (Input.GetKeyDown(KeyCode.D) && isSplitting)
        {
            if (selectionIndex < previousRoot.lr.positionCount - 11) selectionIndex+=7;
            else selectionIndex = 0;
        }
        if (isSplitting)
        {
            RenderSelection(previousRoot.SelectPointOnRoot(selectionIndex));
        }
    }

    public void RenderSelection(Vector2 position)
    {
        if (selectionObject == null)
        {
            selectionObject = Instantiate(selectionObjectPrefab);
        }
        else
        {
            print("dirty nigg...");
            float angle = 90 - selectionObject.transform.rotation.z;
            selectionObject.transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
            selectionObject.transform.position = position;
        }
    }


   

    public void MoveRootMover(float dir)
    {
        rootMover.transform.Rotate(Vector3.forward * dir * Time.deltaTime * rotationForce);
        rootMover.transform.Translate(Vector2.down * Time.deltaTime * speedModifier);
    }
}
