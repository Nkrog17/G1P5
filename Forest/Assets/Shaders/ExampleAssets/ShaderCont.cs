using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderCont : MonoBehaviour
{
    float timer = 0f;
    public Renderer[] rend;
    //public Renderer rend;
    float amt;
    bool amt1 = false;
    public GameObject[] prop;
    int[] timerArray = new int[10] {26, 59, 98, 119, 157, 191, 252, 268, 307, 328 };
    public static int counter = 0;
    public static bool setInactive = false;
    public static bool stopCounter = false;

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
        if (!setInactive)
        {
            propActiveStatus();
            
        }

        timer += Time.deltaTime;
        //amt = mat.GetFloat("_SliceAmount");


        //Debug.Log(timer);

        mat = rend[counter].material;
        
        if (timer >= timerArray[counter] && timer < (timerArray[counter] + 5) && !amt1)
        {
            propCall(counter);
        }

        if (timer >= timerArray[counter]+5 && !amt1)
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
        prop[i].SetActive(true);

        amt -= 0.01f;
        mat.SetFloat("_SliceAmount", amt);
        if (amt <= 0)
        {
            amt1 = false;
            amt = 0;
        }
    }

    void propKill(int i)
    {
        amt += 0.01f;
        //Ændrer sliceamount i dissolve2nd shaderen.    
        mat.SetFloat("_SliceAmount", amt);
        if (amt >= 1)
        {
            //amt1 = true;
            amt = 1;
            if (!stopCounter)
            {
               counter++;
            }
           
            Debug.Log("Counter is = " + counter);
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


