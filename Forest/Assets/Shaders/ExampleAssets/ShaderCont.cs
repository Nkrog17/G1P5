using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderCont : MonoBehaviour
{
    float timer = 0.0f;
    public Renderer[] rend;
    //public Renderer rend;
    float amt;
    bool amt1 = false;
    public GameObject[] prop;
    public AudioSource AudioStart;
    public AudioSource AudioEnd;
    public AudioSource Narrative;
    float fakeTimer;

    // 26, 59, 98, 119, 157, 191, 252, 268, 307, 328
    int[] timerArray = new int[10] {16, 50, 89, 111, 148, 182, 243, 260, 298, 322 };
    public static int counter = 0;
    public static bool setInactive = false;
    public static bool stopCounter = false;
    bool gameStart = false;
    Material mat;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //amt = burneffekt hvor 0 = objekt er visibel og 1 = objekt er brændt væk
        amt = 1;
    }


    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        if (!setInactive)
        {
            propActiveStatus();
        }
        //amt = mat.GetFloat("_SliceAmount");
        //Ændrer space herunder til hvad vi finder ud af med VR.q
        if (Input.GetKeyDown(KeyCode.Space) && !gameStart) {
            fakeTimer = timer;
            Narrative.Play();
            gameStart = true;
        }
        timer = timer - fakeTimer;
        Debug.Log("timer = " + timer); 
        mat = rend[counter].material;

        //Starts calling function after specified time for each element.
        if (timer >= timerArray[counter] && timer < (timerArray[counter] + 7) && !amt1 && gameStart)
        {
            propCall(counter);
            
        }

        if (timer >= (timerArray[counter]+7) && !amt1 && gameStart)
        {
            propKill(counter);
        }

        if (counter > rend.Length-1)
        {
            counter = rend.Length - 1;
            stopCounter = true;
        }
    }



    void propCall(int i)
    {
        //AudioStart.Play(0);'
        if (!amt1)
        {
            prop[i].SetActive(true);
            //Debug.Log("i = " + i);
        }
        
        //Debug.Log(amt);
        amt -= 0.02f;
        mat.SetFloat("_SliceAmount", amt);
        if (amt <= 0)
        {
            amt1 = false;
            amt = 0;
        }
    }

    void propKill(int i)
    {
        //AudioEnd.Play(0);
        amt += 0.01f;
        //Ændrer sliceamount i dissolve2nd shaderen.    
        mat.SetFloat("_SliceAmount", amt);
        if (amt >= 1)
        {
            //amt1 = true;
            amt = 1;
            prop[i].SetActive(false);
            if (!stopCounter)
            {
               counter++;
            }
           
            //Debug.Log("Counter is = " + counter);
        }
    }
    void propActiveStatus()
    {
        for (int i = 0; i < rend.Length; i++)
        {
            prop[i].SetActive(false);
            if (i == rend.Length-1)
            {
                setInactive = true;
            }
        }
    }
}


