using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



//this script can be found in the Component section under the option Character Set Up 
//Character Movement
[AddComponentMenu("Character Set Up/Character Movement")]

//This script requires the component Character controller
[RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour
{
    #region Variables
    //[Header("Characters MoveDirection")]
    [Header("Character's MoveDirection")]

    //vector3 called moveDirection
    //we will use this to apply movement in worldspace
    public Vector3 moveDir = Vector3.zero;

    //private CharacterController (https://docs.unity3d.com/ScriptReference/CharacterController.html) charC
    private CharacterController charC;

    //[Header("Character Variables")]
    [Header("Character Variables")]

    //public float variables jumpSpeed, speed, gravity
    public float jumpSpeed = 8.0f;
    public float speed = 6.0f;
    public float gravity = 20.0f;

    [Header("Stamina")]
    public float staminaTimerFloat;
    public float staminaTimerMax;
    public float staminaTimerCountdown;
    public bool staminaBool;
    public GUIStyle staminaBarOrange;

    [Header("Shoot")]
    public GameObject[] bulletPrefabs;
    public Transform bulletSpawn;
    public float bulletSpeed;
    public float bulletLife;
    public GameObject customiseManager;

    [Header("Mana")]
    public int manaCounter, manaMax;
    public bool manaBool;
    public GUIStyle manaBarBlue;

    #endregion

    #region Start
    void Start()
    {
        //charc is on this game object we need to get the character controller that is attached to it
        charC = this.GetComponent<CharacterController>();

        staminaTimerCountdown = 1;
        staminaBool = false;

        //Debug.Log("playerMana = " + gameObject.GetComponent<PlayerStats>().playerMana);
        manaBool = false;

        bulletSpeed = 20;
        bulletLife = 6;

        //Debug.Log("PlayerStat's playerStamina = " + gameObject.GetComponent<PlayerStats>().playerStamina);
    }
    #endregion

    #region Update
    void Update()
    {
        GetStaminaStatFunction();

        GetManaCount();

        //if our character is grounded
        if (charC.isGrounded)
        {
            //we are able to move in game scene meaning
            //Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
            //Input(https://docs.unity3d.com/ScriptReference/Input.html)
            //moveDir is equal to a new vector3 that is affected by Input.Get Axis.. Horizontal, 0, Vertical
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            //moveDir is transformed in the direction of our moveDir
            moveDir = transform.TransformDirection(moveDir);

            //our moveDir is then multiplied by our speed
            moveDir *= speed;

            //we can also jump if we are grounded so
            //in the input button for jump is pressed then
            /*if (Input.GetButton("Jump"))
            {
                //our moveDir.y is equal to our jump speed
                moveDir.y = jumpSpeed;
            }*/

            StaminaTimerFunction();
        }

        //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed my time.deltaTime to normalize it
        moveDir.y -= gravity * Time.deltaTime;

        //we then tell the character Controller that it is moving in a direction timesed Time.deltaTime
        charC.Move(moveDir * Time.deltaTime);

        Shoot();
    }
    #endregion

    void StaminaTimerFunction() // if Player is pressing a Movement Key, minus Stamina/reduce Speed, if not, increase Stamina/normal Speed
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            staminaTimerFloat = staminaTimerFloat - (staminaTimerCountdown * Time.deltaTime);
            //Debug.Log("staminaTimerFloat = " + staminaTimerFloat);

            if (staminaTimerFloat <= 0) // keep from going below Zero
            {
                staminaTimerFloat = 0;
                speed = 0.5f;
            }

            if (staminaTimerFloat > 0) // to allow normal speed if stamina above 0
            {
                speed = gameObject.GetComponent<PlayerStats>().playerStamina;
            }
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            staminaTimerFloat = staminaTimerFloat + ((staminaTimerCountdown * 2) * Time.deltaTime);
            //Debug.Log("staminaTimerFloat = " + staminaTimerFloat);

            if (staminaTimerFloat >= staminaTimerMax) // keep from going above Max Stat value
            {
                staminaTimerFloat = staminaTimerMax;
                speed = gameObject.GetComponent<PlayerStats>().playerStamina;
            }
        }
    }

    void GetStaminaStatFunction() // Get Stamina value
    {
        if (gameObject.GetComponent<PlayerStats>().playerStamina != 0 && staminaBool == false)
        {
            switch (gameObject.GetComponent<PlayerStats>().playerStamina)
            {
                case 1:
                    staminaTimerFloat = 1f;
                    staminaTimerMax = staminaTimerFloat;

                    break;

                case 2:
                    staminaTimerFloat = 2f;
                    staminaTimerMax = staminaTimerFloat;

                    break;

                case 3:
                    staminaTimerFloat = 3f;
                    staminaTimerMax = staminaTimerFloat;

                    break;

                case 4:
                    staminaTimerFloat = 4f;
                    staminaTimerMax = staminaTimerFloat;

                    break;

                case 5:
                    staminaTimerFloat = 5f;
                    staminaTimerMax = staminaTimerFloat;

                    break;

                case 6:
                    staminaTimerFloat = 6f;
                    staminaTimerMax = staminaTimerFloat;

                    break;
            }

            staminaBool = true;
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (manaCounter > 0)
            {
                GameObject bullet = Instantiate(bulletPrefabs[customiseManager.GetComponent<CustomiseSet>().eyeMatsIndex], bulletSpawn.position, bulletSpawn.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
                Destroy(bullet, bulletLife);

                manaCounter = manaCounter - 1;
                //Debug.Log("manaCounter = " + manaCounter);
            }
        }
    }

    void GetManaCount()
    {
        if (manaBool == false && gameObject.GetComponent<PlayerStats>().playerMana != 0)
        {
            manaCounter = gameObject.GetComponent<PlayerStats>().playerMana;
            manaMax = manaCounter;

            //Debug.Log("manaCounter = " + manaCounter);

            manaBool = true;
        }
    }

    void OnGUI()
    {
        
        if (SceneManager.GetActiveScene().name == "Game")
        {
            float scrW = Screen.width / 16; // Dividing Screen Width into 16 parts, value of scrW = 1
            float scrH = Screen.height / 9; // Dividing Screen Height into 9 parts, value of scrH = 1

            //GUI.Box(new Rect(6f * scrW, scrH, 4 * scrW, 0.5f * scrH), "HEALTH"); //
            //GUI.Box(new Rect(6f * scrW, scrH, playerHealth * (4 * scrW) / playerHealthMax, 0.5f * scrH), "", healthBarRed); //

            // MANA
            GUI.Box(new Rect(6f * scrW, 8f * scrH, 4 * scrW, 0.5f * scrH), ""); //
            GUI.Box(new Rect(6f * scrW, 8f * scrH, manaCounter * (4 * scrW) / manaMax, 0.5f * scrH), "", manaBarBlue); //

            // STAMINA
            GUI.Box(new Rect(6f * scrW, 7.5f * scrH, 4 * scrW, 0.5f * scrH), ""); //
            GUI.Box(new Rect(6f * scrW, 7.5f * scrH, staminaTimerFloat * (4 * scrW) / staminaTimerMax, 0.5f * scrH), "", staminaBarOrange);
        }
    }
}










