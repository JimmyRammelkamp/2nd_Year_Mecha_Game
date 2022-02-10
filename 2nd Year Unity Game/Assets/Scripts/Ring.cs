using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public bool passed;
    public bool passable;
    public GameObject Enemy;

    Color orange = new Color(1.0f, 0.5f, 0f, 1.0f);
    Color purple = new Color(0.4290655f, 0.2663759f, 0.7735849f, 1.0f);

    int childCount;

    // Start is called before the first frame update
    void Start()
    {
        childCount = this.transform.childCount;
        passable = false;
        passed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            passable = true;
        }

        if (!passable && !passed) GetComponent<Renderer>().material.SetColor("_WireColor", purple);
        if (passable && !passed) GetComponent<Renderer>().material.SetColor("_WireColor", orange);
        if (passed) GetComponent<Renderer>().material.SetColor("_WireColor", Color.green);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player" && passed == false && passable == true)
        {
            Debug.Log("Player passed");
            for(int i = 0; i < childCount;i++)
            {
                Instantiate(Enemy, this.transform.GetChild(i));
            }
            passed = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().AddTime(6);
            GameObject.Find("GameManager").GetComponent<GameManager>().AddScore(10);
        }
    }
}
