using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class CustomiseSet : MonoBehaviour
{
    [Header("Colours")]
    public Material[] mats;
    public GameObject head, body, ear1, ear2, eye, beard, hair;
    public int headMatsIndex, bodyMatsIndex, earMatsIndex, eyeMatsIndex, beardMatsIndex, hairMatsIndex, matsMaxIndex;

    [Header("Stats")]
    public GameObject[] healthBars;
    public GameObject[] manaBars;
    public GameObject[] staminaBars;
    public int healthStat, healthMinStat, manaStat, manaMinStat, staminaStat, staminaMinStat, maxStat, skillPoints, skillPointsMax;

    [Header("Classes")]
    public Dropdown classDropDown;

    // Use this for initialization
    void Start()
    {
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
        skillPointsMax = 5;
        skillPoints = skillPointsMax;

        classDropDown.value = 0; // set Default class before Load

        ClassCheck();

        Load();

        Debug.Log("classDropDown.value = " + classDropDown.value);
    }

    // Update is called once per frame
    void Update()
    {

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
            return;
        }

        if (hairMatsIndex == matsMaxIndex)
        {
            hair.GetComponent<Renderer>().material = mats[0]; // reset Mats to Zero
            hairMatsIndex = 0;
            return;
        }
    }

    public void RandomColoursButton()
    {
        headMatsIndex = Random.Range(0, matsMaxIndex);
        bodyMatsIndex = Random.Range(0, matsMaxIndex);
        earMatsIndex = Random.Range(0, matsMaxIndex);
        eyeMatsIndex = Random.Range(0, matsMaxIndex);
        beardMatsIndex = Random.Range(0, matsMaxIndex);
        hairMatsIndex = Random.Range(0, matsMaxIndex);

        head.GetComponent<Renderer>().material = mats[headMatsIndex];
        body.GetComponent<Renderer>().material = mats[bodyMatsIndex];
        ear1.GetComponent<Renderer>().material = mats[earMatsIndex];
        ear2.GetComponent<Renderer>().material = mats[earMatsIndex];
        eye.GetComponent<Renderer>().material = mats[eyeMatsIndex];
        beard.GetComponent<Renderer>().material = mats[beardMatsIndex];
        hair.GetComponent<Renderer>().material = mats[hairMatsIndex];
    }
    #endregion

    #region Stats
    public void HealthButton()
    {
        if (healthStat < maxStat && skillPoints > 0)
        {
            healthStat = healthStat + 1; // increment healthStat

            skillPoints = skillPoints - 1;
            Debug.Log("skillPoints = " + skillPoints);

            healthBars[healthStat - 1].SetActive(true); // activate appropriate healthbar

            return;
        }

        if ((healthStat >= maxStat && skillPoints > 0) || (maxStat - healthStat >= 0 && skillPoints == 0))
        {
            skillPoints = skillPoints + (healthStat - healthMinStat); // give the skillPoints back

            healthStat = healthMinStat; // reset healthStat if trying to go past max
            Debug.Log("healthStat = " + healthStat);

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

            return;
        }
    }

    public void ManaButton()
    {
        if (manaStat < maxStat && skillPoints > 0)
        {
            manaStat = manaStat + 1; // increment healthStat

            skillPoints = skillPoints - 1;
            Debug.Log("skillPoints = " + skillPoints);

            manaBars[manaStat - 1].SetActive(true); // activate appropriate healthbar

            return;
        }

        if ((manaStat >= maxStat && skillPoints > 0) || (maxStat - manaStat >= 0 && skillPoints == 0))
        {
            skillPoints = skillPoints + (manaStat - manaMinStat); // give the skillPoints back

            manaStat = manaMinStat; // reset healthStat if trying to go past max
            Debug.Log("manaStat = " + manaStat);

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

            return;
        }
    }

    public void StaminaButton()
    {
        if (staminaStat < maxStat && skillPoints > 0)
        {
            staminaStat = staminaStat + 1; // increment healthStat

            skillPoints = skillPoints - 1;
            Debug.Log("skillPoints = " + skillPoints);

            staminaBars[staminaStat - 1].SetActive(true); // activate appropriate healthbar

            return;
        }

        if ((staminaStat >= maxStat && skillPoints > 0) || (maxStat - staminaStat >= 0 && skillPoints == 0))
        {
            skillPoints = skillPoints + (staminaStat - staminaMinStat); // give the skillPoints back

            staminaStat = staminaMinStat; // reset healthStat if trying to go past max
            Debug.Log("staminaStat = " + staminaStat);

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

            return;
        }
    }

    public void ClassCheck()
    {
        switch (classDropDown.value) // for classDropDown.value
        {
            case 0: // if classDropDown.value == 0
                skillPoints = skillPointsMax; // reset skillPoints when choosing new Class

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

                break;

            case 1:
                skillPoints = skillPointsMax;

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

                break;

            case 2:
                skillPoints = skillPointsMax;

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

                break;

            case 3:
                skillPoints = skillPointsMax;

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

                break;

            case 4:
                skillPoints = skillPointsMax;

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

                break;

            case 5:
                skillPoints = skillPointsMax;

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

        classDropDown.value = PlayerPrefs.GetInt("Class Dropdown");

    }
}
