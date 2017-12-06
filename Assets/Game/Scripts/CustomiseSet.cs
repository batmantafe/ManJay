using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class CustomiseSet : MonoBehaviour
{
    public string currentScene;

    [Header("Colours")]
    public Material[] mats;
    public GameObject head, body, ear1, ear2, eye, beard, hair;
    public int headMatsIndex, bodyMatsIndex, earMatsIndex, eyeMatsIndex, beardMatsIndex, hairMatsIndex, matsMaxIndex;

    [Header("Stats")]
    public GameObject[] healthBars;
    public GameObject[] manaBars;
    public GameObject[] staminaBars;
    public GameObject[] speedBars;
    public GameObject[] sneakyBars;
    public GameObject[] shootBars;
    public GameObject[] skillBars;
    public int healthStat, healthMinStat,
        manaStat, manaMinStat,
        staminaStat, staminaMinStat,
        speedStat, speedMinStat,
        sneakyStat, sneakyMinStat,
        shootStat, shootMinStat,
        maxStat, skillPoints, skillPointsMax;

    [Header("Classes")]
    public Dropdown classDropDown;
    public GameObject player;

    [Header("Character Name")]
    public string charName;
    public Text yourName;

    // Use this for initialization
    void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;

        headMatsIndex = 0; // Sets Defaults before Load
        bodyMatsIndex = 0;
        earMatsIndex = 0;
        eyeMatsIndex = 0;
        beardMatsIndex = 0;
        hairMatsIndex = 0;

        matsMaxIndex = mats.Length - 1;

        healthStat = 1;
        manaStat = 1;
        staminaStat = 1;
        maxStat = 6;
        skillPointsMax = 10;
        skillPoints = skillPointsMax;

        if (SceneManager.GetActiveScene().name == "Customise") // Only do this in the Customise scene
        {
            classDropDown.value = 0; // set Default class before Load
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        ClassCheck();

        Load();

        /*Debug.Log("healthStat = " + healthStat);
        Debug.Log("manaStat = " + manaStat);
        Debug.Log("staminaStat = " + staminaStat);
        Debug.Log("speedStat = " + speedStat);
        Debug.Log("sneakyStat = " + sneakyStat);
        Debug.Log("shootStat = " + shootStat);*/
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shortcuts();
    }

    void Shortcuts()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Customise")
            {
                Application.Quit();
            }

            if (SceneManager.GetActiveScene().name == "Game")
            {
                SceneManager.LoadScene("Customise");
            }
        }

        if (Input.GetKey(KeyCode.F1))
        {
            SceneManager.LoadScene(currentScene, LoadSceneMode.Single); // LoadSceneMode.single loads a Single Scene (not overlapping an existing scene)
        }
    }

    #region Colours
    public void HeadColourButton()
    {
        if (headMatsIndex < matsMaxIndex)
        {
            head.GetComponent<Renderer>().material = mats[headMatsIndex + 1]; // whatever Mats is, plus One
            headMatsIndex = headMatsIndex + 1;
            return;
        }

        if (headMatsIndex == matsMaxIndex)
        {
            head.GetComponent<Renderer>().material = mats[0]; // reset Mats to Zero
            headMatsIndex = 0;
            return;
        }
    }

    public void BodyColourButton()
    {
        if (bodyMatsIndex < matsMaxIndex)
        {
            body.GetComponent<Renderer>().material = mats[bodyMatsIndex + 1]; // whatever Mats is, plus One
            bodyMatsIndex = bodyMatsIndex + 1;
            return;
        }

        if (bodyMatsIndex == matsMaxIndex)
        {
            body.GetComponent<Renderer>().material = mats[0]; // reset Mats to Zero
            bodyMatsIndex = 0;
            return;
        }
    }

    public void EarColourButton()
    {
        if (earMatsIndex < matsMaxIndex)
        {
            ear1.GetComponent<Renderer>().material = mats[earMatsIndex + 1]; // whatever Mats is, plus One
            ear2.GetComponent<Renderer>().material = mats[earMatsIndex + 1];
            earMatsIndex = earMatsIndex + 1;
            return;
        }

        if (earMatsIndex == matsMaxIndex)
        {
            ear1.GetComponent<Renderer>().material = mats[0]; // reset Mats to Zero
            ear2.GetComponent<Renderer>().material = mats[0];
            earMatsIndex = 0;
            return;
        }
    }

    public void EyeColourButton()
    {
        if (eyeMatsIndex < matsMaxIndex)
        {
            eye.GetComponent<Renderer>().material = mats[eyeMatsIndex + 1]; // whatever Mats is, plus One
            eyeMatsIndex = eyeMatsIndex + 1;
            return;
        }

        if (eyeMatsIndex == matsMaxIndex)
        {
            eye.GetComponent<Renderer>().material = mats[0]; // reset Mats to Zero
            eyeMatsIndex = 0;
            return;
        }
    }

    public void BeardColourButton()
    {
        if (beardMatsIndex < matsMaxIndex)
        {
            beard.GetComponent<Renderer>().material = mats[beardMatsIndex + 1]; // whatever Mats is, plus One
            beardMatsIndex = beardMatsIndex + 1;
            return;
        }

        if (beardMatsIndex == matsMaxIndex)
        {
            beard.GetComponent<Renderer>().material = mats[0]; // reset Mats to Zero
            beardMatsIndex = 0;
            return;
        }
    }

    public void HairColourButton()
    {
        if (hairMatsIndex < matsMaxIndex)
        {
            hair.GetComponent<Renderer>().material = mats[hairMatsIndex + 1]; // whatever Mats is, plus One
            hairMatsIndex = hairMatsIndex + 1;

            if (player.GetComponent<PlayerHat>().hatToggleBool == true)
            {
                player.GetComponent<PlayerHat>().customHat.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;
                player.GetComponent<PlayerHat>().customHat.transform.Find("Hat 1 Bottom").gameObject.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;
            }

            return;
        }

        if (hairMatsIndex == matsMaxIndex)
        {
            hair.GetComponent<Renderer>().material = mats[0]; // reset Mats to Zero
            hairMatsIndex = 0;

            if (player.GetComponent<PlayerHat>().hatToggleBool == true)
            {
                player.GetComponent<PlayerHat>().customHat.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;
                player.GetComponent<PlayerHat>().customHat.transform.Find("Hat 1 Bottom").gameObject.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;
            }

            return;
        }
    }

    public void RandomColoursButton()
    {
        headMatsIndex = Random.Range(0, matsMaxIndex + 1);
        bodyMatsIndex = Random.Range(0, matsMaxIndex + 1);
        earMatsIndex = Random.Range(0, matsMaxIndex + 1);
        eyeMatsIndex = Random.Range(0, matsMaxIndex + 1);
        beardMatsIndex = Random.Range(0, matsMaxIndex + 1);
        hairMatsIndex = Random.Range(0, matsMaxIndex + 1);

        head.GetComponent<Renderer>().material = mats[headMatsIndex];
        body.GetComponent<Renderer>().material = mats[bodyMatsIndex];
        ear1.GetComponent<Renderer>().material = mats[earMatsIndex];
        ear2.GetComponent<Renderer>().material = mats[earMatsIndex];
        eye.GetComponent<Renderer>().material = mats[eyeMatsIndex];
        beard.GetComponent<Renderer>().material = mats[beardMatsIndex];
        hair.GetComponent<Renderer>().material = mats[hairMatsIndex];

        if (player.GetComponent<PlayerHat>().hatToggleBool == true)
        {
            player.GetComponent<PlayerHat>().customHat.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;
            player.GetComponent<PlayerHat>().customHat.transform.Find("Hat 1 Bottom").gameObject.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;
        }
    }
    #endregion

    #region Stats
    public void HealthButton()
    {
        if (healthStat < maxStat && skillPoints > 0)
        {
            healthStat = healthStat + 1; // increment healthStat

            skillPoints = skillPoints - 1;
            //Debug.Log("skillPoints = " + skillPoints);

            healthBars[healthStat - 1].SetActive(true); // activate appropriate healthbar

            SkillBarUpdate(); // take from Skill Bar

            return;
        }

        if ((healthStat >= maxStat && skillPoints > 0) || (maxStat - healthStat >= 0 && skillPoints == 0))
        {
            skillPoints = skillPoints + (healthStat - healthMinStat); // give the skillPoints back

            healthStat = healthMinStat; // reset healthStat if trying to go past max
            //Debug.Log("healthStat = " + healthStat);

            switch (healthMinStat)
            {
                case 1:
                    healthBars[0].SetActive(true);
                    healthBars[1].SetActive(false);
                    healthBars[2].SetActive(false);
                    healthBars[3].SetActive(false);
                    healthBars[4].SetActive(false);
                    healthBars[5].SetActive(false);
                    break;

                case 2:
                    healthBars[0].SetActive(true);
                    healthBars[1].SetActive(true);
                    healthBars[2].SetActive(false);
                    healthBars[3].SetActive(false);
                    healthBars[4].SetActive(false);
                    healthBars[5].SetActive(false);
                    break;

                case 3:
                    healthBars[0].SetActive(true);
                    healthBars[1].SetActive(true);
                    healthBars[2].SetActive(true);
                    healthBars[3].SetActive(false);
                    healthBars[4].SetActive(false);
                    healthBars[5].SetActive(false);
                    break;
            }

            SkillBarUpdate(); // take from Skill Bar

            return;
        }
    }

    public void ManaButton()
    {
        if (manaStat < maxStat && skillPoints > 0)
        {
            manaStat = manaStat + 1; // increment healthStat

            skillPoints = skillPoints - 1;
            //Debug.Log("skillPoints = " + skillPoints);

            manaBars[manaStat - 1].SetActive(true); // activate appropriate healthbar

            SkillBarUpdate();

            return;
        }

        if ((manaStat >= maxStat && skillPoints > 0) || (maxStat - manaStat >= 0 && skillPoints == 0))
        {
            skillPoints = skillPoints + (manaStat - manaMinStat); // give the skillPoints back

            manaStat = manaMinStat; // reset healthStat if trying to go past max
            //Debug.Log("manaStat = " + manaStat);

            switch (manaMinStat)
            {
                case 1:
                    manaBars[0].SetActive(true);
                    manaBars[1].SetActive(false);
                    manaBars[2].SetActive(false);
                    manaBars[3].SetActive(false);
                    manaBars[4].SetActive(false);
                    manaBars[5].SetActive(false);
                    break;

                case 2:
                    manaBars[0].SetActive(true);
                    manaBars[1].SetActive(true);
                    manaBars[2].SetActive(false);
                    manaBars[3].SetActive(false);
                    manaBars[4].SetActive(false);
                    manaBars[5].SetActive(false);
                    break;

                case 3:
                    manaBars[0].SetActive(true);
                    manaBars[1].SetActive(true);
                    manaBars[2].SetActive(true);
                    manaBars[3].SetActive(false);
                    manaBars[4].SetActive(false);
                    manaBars[5].SetActive(false);
                    break;
            }

            SkillBarUpdate();

            return;
        }
    }

    public void StaminaButton()
    {
        if (staminaStat < maxStat && skillPoints > 0)
        {
            staminaStat = staminaStat + 1; // increment healthStat

            skillPoints = skillPoints - 1;
            //Debug.Log("skillPoints = " + skillPoints);

            staminaBars[staminaStat - 1].SetActive(true); // activate appropriate healthbar

            SkillBarUpdate();

            return;
        }

        if ((staminaStat >= maxStat && skillPoints > 0) || (maxStat - staminaStat >= 0 && skillPoints == 0))
        {
            skillPoints = skillPoints + (staminaStat - staminaMinStat); // give the skillPoints back

            staminaStat = staminaMinStat; // reset healthStat if trying to go past max
            //Debug.Log("staminaStat = " + staminaStat);

            switch (staminaMinStat)
            {
                case 1:
                    staminaBars[0].SetActive(true);
                    staminaBars[1].SetActive(false);
                    staminaBars[2].SetActive(false);
                    staminaBars[3].SetActive(false);
                    staminaBars[4].SetActive(false);
                    staminaBars[5].SetActive(false);
                    break;

                case 2:
                    staminaBars[0].SetActive(true);
                    staminaBars[1].SetActive(true);
                    staminaBars[2].SetActive(false);
                    staminaBars[3].SetActive(false);
                    staminaBars[4].SetActive(false);
                    staminaBars[5].SetActive(false);
                    break;

                case 3:
                    staminaBars[0].SetActive(true);
                    staminaBars[1].SetActive(true);
                    staminaBars[2].SetActive(true);
                    staminaBars[3].SetActive(false);
                    staminaBars[4].SetActive(false);
                    staminaBars[5].SetActive(false);
                    break;
            }

            SkillBarUpdate();

            return;
        }
    }

    public void SpeedButton()
    {
        if (speedStat < maxStat && skillPoints > 0)
        {
            speedStat = speedStat + 1; // increment healthStat

            skillPoints = skillPoints - 1;
            //Debug.Log("skillPoints = " + skillPoints);

            speedBars[speedStat - 1].SetActive(true); // activate appropriate healthbar

            SkillBarUpdate();

            return;
        }

        if ((speedStat >= maxStat && skillPoints > 0) || (maxStat - speedStat >= 0 && skillPoints == 0))
        {
            skillPoints = skillPoints + (speedStat - speedMinStat); // give the skillPoints back

            speedStat = speedMinStat; // reset healthStat if trying to go past max
            //Debug.Log("speedStat = " + speedStat);

            switch (speedMinStat)
            {
                case 1:
                    speedBars[0].SetActive(true);
                    speedBars[1].SetActive(false);
                    speedBars[2].SetActive(false);
                    speedBars[3].SetActive(false);
                    speedBars[4].SetActive(false);
                    speedBars[5].SetActive(false);
                    break;

                case 2:
                    speedBars[0].SetActive(true);
                    speedBars[1].SetActive(true);
                    speedBars[2].SetActive(false);
                    speedBars[3].SetActive(false);
                    speedBars[4].SetActive(false);
                    speedBars[5].SetActive(false);
                    break;

                case 3:
                    speedBars[0].SetActive(true);
                    speedBars[1].SetActive(true);
                    speedBars[2].SetActive(true);
                    speedBars[3].SetActive(false);
                    speedBars[4].SetActive(false);
                    speedBars[5].SetActive(false);
                    break;
            }

            SkillBarUpdate();

            return;
        }
    }

    public void SneakyButton()
    {
        if (sneakyStat < maxStat && skillPoints > 0)
        {
            sneakyStat = sneakyStat + 1; // increment healthStat

            skillPoints = skillPoints - 1;
            //Debug.Log("skillPoints = " + skillPoints);

            sneakyBars[sneakyStat - 1].SetActive(true); // activate appropriate healthbar

            SkillBarUpdate();

            return;
        }

        if ((sneakyStat >= maxStat && skillPoints > 0) || (maxStat - sneakyStat >= 0 && skillPoints == 0))
        {
            skillPoints = skillPoints + (sneakyStat - sneakyMinStat); // give the skillPoints back

            sneakyStat = sneakyMinStat; // reset healthStat if trying to go past max
            //Debug.Log("sneakyStat = " + sneakyStat);

            switch (sneakyMinStat)
            {
                case 1:
                    sneakyBars[0].SetActive(true);
                    sneakyBars[1].SetActive(false);
                    sneakyBars[2].SetActive(false);
                    sneakyBars[3].SetActive(false);
                    sneakyBars[4].SetActive(false);
                    sneakyBars[5].SetActive(false);
                    break;

                case 2:
                    sneakyBars[0].SetActive(true);
                    sneakyBars[1].SetActive(true);
                    sneakyBars[2].SetActive(false);
                    sneakyBars[3].SetActive(false);
                    sneakyBars[4].SetActive(false);
                    sneakyBars[5].SetActive(false);
                    break;

                case 3:
                    sneakyBars[0].SetActive(true);
                    sneakyBars[1].SetActive(true);
                    sneakyBars[2].SetActive(true);
                    sneakyBars[3].SetActive(false);
                    sneakyBars[4].SetActive(false);
                    sneakyBars[5].SetActive(false);
                    break;
            }

            SkillBarUpdate();

            return;
        }
    }

    public void ShootButton()
    {
        if (shootStat < maxStat && skillPoints > 0)
        {
            shootStat = shootStat + 1; // increment healthStat

            skillPoints = skillPoints - 1;
            //Debug.Log("skillPoints = " + skillPoints);

            shootBars[shootStat - 1].SetActive(true); // activate appropriate healthbar

            SkillBarUpdate();

            return;
        }

        if ((shootStat >= maxStat && skillPoints > 0) || (maxStat - shootStat >= 0 && skillPoints == 0))
        {
            skillPoints = skillPoints + (shootStat - shootMinStat); // give the skillPoints back

            shootStat = shootMinStat; // reset healthStat if trying to go past max
            //Debug.Log("shootStat = " + shootStat);

            switch (shootMinStat)
            {
                case 1:
                    shootBars[0].SetActive(true);
                    shootBars[1].SetActive(false);
                    shootBars[2].SetActive(false);
                    shootBars[3].SetActive(false);
                    shootBars[4].SetActive(false);
                    shootBars[5].SetActive(false);
                    break;

                case 2:
                    shootBars[0].SetActive(true);
                    shootBars[1].SetActive(true);
                    shootBars[2].SetActive(false);
                    shootBars[3].SetActive(false);
                    shootBars[4].SetActive(false);
                    shootBars[5].SetActive(false);
                    break;

                case 3:
                    shootBars[0].SetActive(true);
                    shootBars[1].SetActive(true);
                    shootBars[2].SetActive(true);
                    shootBars[3].SetActive(false);
                    shootBars[4].SetActive(false);
                    shootBars[5].SetActive(false);
                    break;
            }

            SkillBarUpdate();

            return;
        }
    }

    public void ClassCheck()
    {
        if (SceneManager.GetActiveScene().name == "Customise") // Only do this in the Customise scene
        {
            switch (classDropDown.value) // for classDropDown.value
            {
                case 0: // if classDropDown.value == 0
                    skillPoints = skillPointsMax; // reset skillPoints when choosing new Class
                    SkillBarUpdate();

                    healthStat = 3;
                    healthMinStat = 3;

                    healthBars[0].SetActive(true);
                    healthBars[1].SetActive(true);
                    healthBars[2].SetActive(true);
                    healthBars[3].SetActive(false);
                    healthBars[4].SetActive(false);
                    healthBars[5].SetActive(false);

                    manaStat = 2;
                    manaMinStat = 2;

                    manaBars[0].SetActive(true);
                    manaBars[1].SetActive(true);
                    manaBars[2].SetActive(false);
                    manaBars[3].SetActive(false);
                    manaBars[4].SetActive(false);
                    manaBars[5].SetActive(false);

                    staminaStat = 1;
                    staminaMinStat = 1;

                    staminaBars[0].SetActive(true);
                    staminaBars[1].SetActive(false);
                    staminaBars[2].SetActive(false);
                    staminaBars[3].SetActive(false);
                    staminaBars[4].SetActive(false);
                    staminaBars[5].SetActive(false);

                    speedStat = 3;
                    speedMinStat = 3;

                    speedBars[0].SetActive(true);
                    speedBars[1].SetActive(true);
                    speedBars[2].SetActive(true);
                    speedBars[3].SetActive(false);
                    speedBars[4].SetActive(false);
                    speedBars[5].SetActive(false);

                    sneakyStat = 2;
                    sneakyMinStat = 2;

                    sneakyBars[0].SetActive(true);
                    sneakyBars[1].SetActive(true);
                    sneakyBars[2].SetActive(false);
                    sneakyBars[3].SetActive(false);
                    sneakyBars[4].SetActive(false);
                    sneakyBars[5].SetActive(false);

                    shootStat = 1;
                    shootMinStat = 1;

                    shootBars[0].SetActive(true);
                    shootBars[1].SetActive(false);
                    shootBars[2].SetActive(false);
                    shootBars[3].SetActive(false);
                    shootBars[4].SetActive(false);
                    shootBars[5].SetActive(false);

                    break;

                case 1:
                    skillPoints = skillPointsMax;
                    SkillBarUpdate();

                    healthStat = 3;
                    healthMinStat = 3;

                    healthBars[0].SetActive(true);
                    healthBars[1].SetActive(true);
                    healthBars[2].SetActive(true);
                    healthBars[3].SetActive(false);
                    healthBars[4].SetActive(false);
                    healthBars[5].SetActive(false);

                    manaStat = 1;
                    manaMinStat = 1;

                    manaBars[0].SetActive(true);
                    manaBars[1].SetActive(false);
                    manaBars[2].SetActive(false);
                    manaBars[3].SetActive(false);
                    manaBars[4].SetActive(false);
                    manaBars[5].SetActive(false);

                    staminaStat = 2;
                    staminaMinStat = 2;

                    staminaBars[0].SetActive(true);
                    staminaBars[1].SetActive(true);
                    staminaBars[2].SetActive(false);
                    staminaBars[3].SetActive(false);
                    staminaBars[4].SetActive(false);
                    staminaBars[5].SetActive(false);

                    speedStat = 3;
                    speedMinStat = 3;

                    speedBars[0].SetActive(true);
                    speedBars[1].SetActive(true);
                    speedBars[2].SetActive(true);
                    speedBars[3].SetActive(false);
                    speedBars[4].SetActive(false);
                    speedBars[5].SetActive(false);

                    sneakyStat = 1;
                    sneakyMinStat = 1;

                    sneakyBars[0].SetActive(true);
                    sneakyBars[1].SetActive(false);
                    sneakyBars[2].SetActive(false);
                    sneakyBars[3].SetActive(false);
                    sneakyBars[4].SetActive(false);
                    sneakyBars[5].SetActive(false);

                    shootStat = 2;
                    shootMinStat = 2;

                    shootBars[0].SetActive(true);
                    shootBars[1].SetActive(true);
                    shootBars[2].SetActive(false);
                    shootBars[3].SetActive(false);
                    shootBars[4].SetActive(false);
                    shootBars[5].SetActive(false);

                    break;

                case 2:
                    skillPoints = skillPointsMax;
                    SkillBarUpdate();

                    healthStat = 2;
                    healthMinStat = 2;

                    healthBars[0].SetActive(true);
                    healthBars[1].SetActive(true);
                    healthBars[2].SetActive(false);
                    healthBars[3].SetActive(false);
                    healthBars[4].SetActive(false);
                    healthBars[5].SetActive(false);

                    manaStat = 1;
                    manaMinStat = 1;

                    manaBars[0].SetActive(true);
                    manaBars[1].SetActive(false);
                    manaBars[2].SetActive(false);
                    manaBars[3].SetActive(false);
                    manaBars[4].SetActive(false);
                    manaBars[5].SetActive(false);

                    staminaStat = 3;
                    staminaMinStat = 3;

                    staminaBars[0].SetActive(true);
                    staminaBars[1].SetActive(true);
                    staminaBars[2].SetActive(true);
                    staminaBars[3].SetActive(false);
                    staminaBars[4].SetActive(false);
                    staminaBars[5].SetActive(false);

                    speedStat = 2;
                    speedMinStat = 2;

                    speedBars[0].SetActive(true);
                    speedBars[1].SetActive(true);
                    speedBars[2].SetActive(false);
                    speedBars[3].SetActive(false);
                    speedBars[4].SetActive(false);
                    speedBars[5].SetActive(false);

                    sneakyStat = 1;
                    sneakyMinStat = 1;

                    sneakyBars[0].SetActive(true);
                    sneakyBars[1].SetActive(false);
                    sneakyBars[2].SetActive(false);
                    sneakyBars[3].SetActive(false);
                    sneakyBars[4].SetActive(false);
                    sneakyBars[5].SetActive(false);

                    shootStat = 3;
                    shootMinStat = 3;

                    shootBars[0].SetActive(true);
                    shootBars[1].SetActive(true);
                    shootBars[2].SetActive(true);
                    shootBars[3].SetActive(false);
                    shootBars[4].SetActive(false);
                    shootBars[5].SetActive(false);

                    break;

                case 3:
                    skillPoints = skillPointsMax;
                    SkillBarUpdate();

                    healthStat = 2;
                    healthMinStat = 2;

                    healthBars[0].SetActive(true);
                    healthBars[1].SetActive(true);
                    healthBars[2].SetActive(false);
                    healthBars[3].SetActive(false);
                    healthBars[4].SetActive(false);
                    healthBars[5].SetActive(false);

                    manaStat = 3;
                    manaMinStat = 3;

                    manaBars[0].SetActive(true);
                    manaBars[1].SetActive(true);
                    manaBars[2].SetActive(true);
                    manaBars[3].SetActive(false);
                    manaBars[4].SetActive(false);
                    manaBars[5].SetActive(false);

                    staminaStat = 1;
                    staminaMinStat = 1;

                    staminaBars[0].SetActive(true);
                    staminaBars[1].SetActive(false);
                    staminaBars[2].SetActive(false);
                    staminaBars[3].SetActive(false);
                    staminaBars[4].SetActive(false);
                    staminaBars[5].SetActive(false);

                    speedStat = 2;
                    speedMinStat = 2;

                    speedBars[0].SetActive(true);
                    speedBars[1].SetActive(true);
                    speedBars[2].SetActive(false);
                    speedBars[3].SetActive(false);
                    speedBars[4].SetActive(false);
                    speedBars[5].SetActive(false);

                    sneakyStat = 3;
                    sneakyMinStat = 3;

                    sneakyBars[0].SetActive(true);
                    sneakyBars[1].SetActive(true);
                    sneakyBars[2].SetActive(true);
                    sneakyBars[3].SetActive(false);
                    sneakyBars[4].SetActive(false);
                    sneakyBars[5].SetActive(false);

                    shootStat = 1;
                    shootMinStat = 1;

                    shootBars[0].SetActive(true);
                    shootBars[1].SetActive(false);
                    shootBars[2].SetActive(false);
                    shootBars[3].SetActive(false);
                    shootBars[4].SetActive(false);
                    shootBars[5].SetActive(false);

                    break;

                case 4:
                    skillPoints = skillPointsMax;
                    SkillBarUpdate();

                    healthStat = 1;
                    healthMinStat = 1;

                    healthBars[0].SetActive(true);
                    healthBars[1].SetActive(false);
                    healthBars[2].SetActive(false);
                    healthBars[3].SetActive(false);
                    healthBars[4].SetActive(false);
                    healthBars[5].SetActive(false);

                    manaStat = 3;
                    manaMinStat = 3;

                    manaBars[0].SetActive(true);
                    manaBars[1].SetActive(true);
                    manaBars[2].SetActive(true);
                    manaBars[3].SetActive(false);
                    manaBars[4].SetActive(false);
                    manaBars[5].SetActive(false);

                    staminaStat = 2;
                    staminaMinStat = 2;

                    staminaBars[0].SetActive(true);
                    staminaBars[1].SetActive(true);
                    staminaBars[2].SetActive(false);
                    staminaBars[3].SetActive(false);
                    staminaBars[4].SetActive(false);
                    staminaBars[5].SetActive(false);

                    speedStat = 1;
                    speedMinStat = 1;

                    speedBars[0].SetActive(true);
                    speedBars[1].SetActive(false);
                    speedBars[2].SetActive(false);
                    speedBars[3].SetActive(false);
                    speedBars[4].SetActive(false);
                    speedBars[5].SetActive(false);

                    sneakyStat = 3;
                    sneakyMinStat = 3;

                    sneakyBars[0].SetActive(true);
                    sneakyBars[1].SetActive(true);
                    sneakyBars[2].SetActive(true);
                    sneakyBars[3].SetActive(false);
                    sneakyBars[4].SetActive(false);
                    sneakyBars[5].SetActive(false);

                    shootStat = 2;
                    shootMinStat = 2;

                    shootBars[0].SetActive(true);
                    shootBars[1].SetActive(true);
                    shootBars[2].SetActive(false);
                    shootBars[3].SetActive(false);
                    shootBars[4].SetActive(false);
                    shootBars[5].SetActive(false);

                    break;

                case 5:
                    skillPoints = skillPointsMax;
                    SkillBarUpdate();

                    healthStat = 1;
                    healthMinStat = 1;

                    healthBars[0].SetActive(true);
                    healthBars[1].SetActive(false);
                    healthBars[2].SetActive(false);
                    healthBars[3].SetActive(false);
                    healthBars[4].SetActive(false);
                    healthBars[5].SetActive(false);

                    manaStat = 2;
                    manaMinStat = 2;

                    manaBars[0].SetActive(true);
                    manaBars[1].SetActive(true);
                    manaBars[2].SetActive(false);
                    manaBars[3].SetActive(false);
                    manaBars[4].SetActive(false);
                    manaBars[5].SetActive(false);

                    staminaStat = 3;
                    staminaMinStat = 3;

                    staminaBars[0].SetActive(true);
                    staminaBars[1].SetActive(true);
                    staminaBars[2].SetActive(true);
                    staminaBars[3].SetActive(false);
                    staminaBars[4].SetActive(false);
                    staminaBars[5].SetActive(false);

                    speedStat = 1;
                    speedMinStat = 1;

                    speedBars[0].SetActive(true);
                    speedBars[1].SetActive(false);
                    speedBars[2].SetActive(false);
                    speedBars[3].SetActive(false);
                    speedBars[4].SetActive(false);
                    speedBars[5].SetActive(false);

                    sneakyStat = 2;
                    sneakyMinStat = 2;

                    sneakyBars[0].SetActive(true);
                    sneakyBars[1].SetActive(true);
                    sneakyBars[2].SetActive(false);
                    sneakyBars[3].SetActive(false);
                    sneakyBars[4].SetActive(false);
                    sneakyBars[5].SetActive(false);

                    shootStat = 3;
                    shootMinStat = 3;

                    shootBars[0].SetActive(true);
                    shootBars[1].SetActive(true);
                    shootBars[2].SetActive(true);
                    shootBars[3].SetActive(false);
                    shootBars[4].SetActive(false);
                    shootBars[5].SetActive(false);

                    break;
            }
        }
    }
    
    void SkillBarUpdate()
    {
        //Debug.Log("skillPoints = " + skillPoints);

        switch (skillPoints)
        {
            case 0:
                skillBars[0].SetActive(false);
                skillBars[1].SetActive(false);
                skillBars[2].SetActive(false);
                skillBars[3].SetActive(false);
                skillBars[4].SetActive(false);
                skillBars[5].SetActive(false);
                skillBars[6].SetActive(false);
                skillBars[7].SetActive(false);
                skillBars[8].SetActive(false);
                skillBars[9].SetActive(false);
                break;

            case 1:
                skillBars[0].SetActive(true);
                skillBars[1].SetActive(false);
                skillBars[2].SetActive(false);
                skillBars[3].SetActive(false);
                skillBars[4].SetActive(false);
                skillBars[5].SetActive(false);
                skillBars[6].SetActive(false);
                skillBars[7].SetActive(false);
                skillBars[8].SetActive(false);
                skillBars[9].SetActive(false);
                break;

            case 2:
                skillBars[0].SetActive(true);
                skillBars[1].SetActive(true);
                skillBars[2].SetActive(false);
                skillBars[3].SetActive(false);
                skillBars[4].SetActive(false);
                skillBars[5].SetActive(false);
                skillBars[6].SetActive(false);
                skillBars[7].SetActive(false);
                skillBars[8].SetActive(false);
                skillBars[9].SetActive(false);
                break;

            case 3:
                skillBars[0].SetActive(true);
                skillBars[1].SetActive(true);
                skillBars[2].SetActive(true);
                skillBars[3].SetActive(false);
                skillBars[4].SetActive(false);
                skillBars[5].SetActive(false);
                skillBars[6].SetActive(false);
                skillBars[7].SetActive(false);
                skillBars[8].SetActive(false);
                skillBars[9].SetActive(false);
                break;

            case 4:
                skillBars[0].SetActive(true);
                skillBars[1].SetActive(true);
                skillBars[2].SetActive(true);
                skillBars[3].SetActive(true);
                skillBars[4].SetActive(false);
                skillBars[5].SetActive(false);
                skillBars[6].SetActive(false);
                skillBars[7].SetActive(false);
                skillBars[8].SetActive(false);
                skillBars[9].SetActive(false);
                break;

            case 5:
                skillBars[0].SetActive(true);
                skillBars[1].SetActive(true);
                skillBars[2].SetActive(true);
                skillBars[3].SetActive(true);
                skillBars[4].SetActive(true);
                skillBars[5].SetActive(false);
                skillBars[6].SetActive(false);
                skillBars[7].SetActive(false);
                skillBars[8].SetActive(false);
                skillBars[9].SetActive(false);
                break;

            case 6:
                skillBars[0].SetActive(true);
                skillBars[1].SetActive(true);
                skillBars[2].SetActive(true);
                skillBars[3].SetActive(true);
                skillBars[4].SetActive(true);
                skillBars[5].SetActive(true);
                skillBars[6].SetActive(false);
                skillBars[7].SetActive(false);
                skillBars[8].SetActive(false);
                skillBars[9].SetActive(false);
                break;

            case 7:
                skillBars[0].SetActive(true);
                skillBars[1].SetActive(true);
                skillBars[2].SetActive(true);
                skillBars[3].SetActive(true);
                skillBars[4].SetActive(true);
                skillBars[5].SetActive(true);
                skillBars[6].SetActive(true);
                skillBars[7].SetActive(false);
                skillBars[8].SetActive(false);
                skillBars[9].SetActive(false);
                break;

            case 8:
                skillBars[0].SetActive(true);
                skillBars[1].SetActive(true);
                skillBars[2].SetActive(true);
                skillBars[3].SetActive(true);
                skillBars[4].SetActive(true);
                skillBars[5].SetActive(true);
                skillBars[6].SetActive(true);
                skillBars[7].SetActive(true);
                skillBars[8].SetActive(false);
                skillBars[9].SetActive(false);
                break;

            case 9:
                skillBars[0].SetActive(true);
                skillBars[1].SetActive(true);
                skillBars[2].SetActive(true);
                skillBars[3].SetActive(true);
                skillBars[4].SetActive(true);
                skillBars[5].SetActive(true);
                skillBars[6].SetActive(true);
                skillBars[7].SetActive(true);
                skillBars[8].SetActive(true);
                skillBars[9].SetActive(false);
                break;

            case 10:
                skillBars[0].SetActive(true);
                skillBars[1].SetActive(true);
                skillBars[2].SetActive(true);
                skillBars[3].SetActive(true);
                skillBars[4].SetActive(true);
                skillBars[5].SetActive(true);
                skillBars[6].SetActive(true);
                skillBars[7].SetActive(true);
                skillBars[8].SetActive(true);
                skillBars[9].SetActive(true);
                break;
        }
    }
    
    #endregion

    public void SaveAndPlayButton()
    {
        PlayerPrefs.SetInt("Head Colour", headMatsIndex);
        PlayerPrefs.SetInt("Body Colour", bodyMatsIndex);
        PlayerPrefs.SetInt("Ear Colour", earMatsIndex);
        PlayerPrefs.SetInt("Eye Colour", eyeMatsIndex);
        PlayerPrefs.SetInt("Beard Colour", beardMatsIndex);
        PlayerPrefs.SetInt("Hair Colour", hairMatsIndex);

        PlayerPrefs.SetInt("Class Dropdown", classDropDown.value);

        PlayerPrefs.SetInt("Health Stat", healthStat);
        PlayerPrefs.SetInt("Mana Stat", manaStat);
        PlayerPrefs.SetInt("Stamina Stat", staminaStat);
        PlayerPrefs.SetInt("Speed Stat", speedStat);
        PlayerPrefs.SetInt("Sneaky Stat", sneakyStat);
        PlayerPrefs.SetInt("Shoot Stat", shootStat);

        PlayerPrefs.SetString("CharacterName", charName);

        SceneManager.LoadScene("Game");
    }

    void Load()
    {
        headMatsIndex = PlayerPrefs.GetInt("Head Colour");
        bodyMatsIndex = PlayerPrefs.GetInt("Body Colour");
        earMatsIndex = PlayerPrefs.GetInt("Ear Colour");
        eyeMatsIndex = PlayerPrefs.GetInt("Eye Colour");
        beardMatsIndex = PlayerPrefs.GetInt("Beard Colour");
        hairMatsIndex = PlayerPrefs.GetInt("Hair Colour");

        head.GetComponent<Renderer>().material = mats[headMatsIndex];
        body.GetComponent<Renderer>().material = mats[bodyMatsIndex];
        ear1.GetComponent<Renderer>().material = mats[earMatsIndex];
        ear2.GetComponent<Renderer>().material = mats[earMatsIndex];
        eye.GetComponent<Renderer>().material = mats[eyeMatsIndex];
        beard.GetComponent<Renderer>().material = mats[beardMatsIndex];
        hair.GetComponent<Renderer>().material = mats[hairMatsIndex];

        // Check if there's a Character Name already saved from a previous play-session
        if (PlayerPrefs.GetString("CharacterName") == "")
        {
            charName = "Duane";
            PlayerPrefs.SetString("CharacterName", charName);
        }

        charName = PlayerPrefs.GetString("CharacterName");

        if (SceneManager.GetActiveScene().name == "Customise") // Only do this in the Customise scene
        {
            classDropDown.value = PlayerPrefs.GetInt("Class Dropdown");
        }

        if (SceneManager.GetActiveScene().name == "Game") // Only get saved Stats when in Game scene
        {
            healthStat = PlayerPrefs.GetInt("Health Stat");
            manaStat = PlayerPrefs.GetInt("Mana Stat");
            staminaStat = PlayerPrefs.GetInt("Stamina Stat");
            speedStat = PlayerPrefs.GetInt("Speed Stat");
            sneakyStat = PlayerPrefs.GetInt("Sneaky Stat");
            shootStat = PlayerPrefs.GetInt("Shoot Stat");

            DisplayYourName();
        }
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Customise");
    }

    void OnGUI()
    {
        if (SceneManager.GetActiveScene().name == "Customise")
        {
            float scrW = Screen.width / 16;
            float scrH = Screen.height / 9;
            //int i = 0;

            //name of our character equals a GUI TextField that holds our character name and limit of characters
            //move down the screen with the int using ++ each grouping of GUI elements are moved using this
            charName = GUI.TextField(new Rect(
                //0.25f * scrW,
                9.5f * scrW,
                //scrH + i * (0.5f * scrH),
                scrH + 7f * (0.5f * scrH),
                2f * scrW, 0.5f * scrW),
                charName,
                12);
        }
    }

    public void DisplayYourName()
    {
        yourName.text = "You are " + charName + ".";
    }
}
