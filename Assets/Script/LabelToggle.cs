using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelToggle : MonoBehaviour
{
    // Start is called before the first frame update
    int flag = 1;
    
    // Update is called once per frame
    public void Toggle()
    {
        if (flag == 1)
        {
            transform.gameObject.SetActive(false);
            flag = 0;
        }
        else
        {
            transform.gameObject.SetActive(true);
            flag = 1;
        }
    }
}
