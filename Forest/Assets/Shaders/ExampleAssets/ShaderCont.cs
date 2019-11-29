using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderCont : MonoBehaviour
{
    float timer = 0f;
    public float SliceAmount = 0.0f;
    //public Renderer[] rend;
    public Renderer rend;
    float amt;
    bool amt1;
    public GameObject objectName;
   
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = rend.material;
        objectName.SetActive(false);
        amt = 1;
    }
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //amt = mat.GetFloat("_SliceAmount");
        

        Debug.Log(timer);
          if (timer >= 5 && timer < 10 && !amt1){
            objectName.SetActive(true);

            amt -= 0.01f;
            mat.SetFloat("_SliceAmount", amt);
            if (amt <= 0)
            {
                amt1 = false;
            }
        }
          
          if (timer >= 10 && amt1 == false)
        {
            amt += 0.01f;
            mat.SetFloat("_SliceAmount", amt);
            if (amt >= 1)
            {
                amt1 = true;
            }
        }
        
                
    }
}
