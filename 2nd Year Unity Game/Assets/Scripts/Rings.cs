using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour
{
    int childCount;
    // Start is called before the first frame update
    void Start()    
    {
        childCount = transform.childCount;
        Debug.Log("Ring count " + childCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(childCount - 1).GetComponent<Ring>().passed == true)
        {
            GameObject.Find("UIManager").GetComponent<UIManager>().Finished();
            Debug.Log("Final ring pass");
        }
        for ( int i = 0; i < childCount; i++)
        {
            GameObject ring = transform.GetChild(i).gameObject;
            if (transform.GetChild(i).GetComponent<Ring>().passed == true)
            {
                transform.GetChild(i + 1).gameObject.SetActive(true);
            }

        }
        
    }
}
