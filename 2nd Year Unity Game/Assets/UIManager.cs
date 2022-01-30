using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text ammo;

    public TMP_Text health;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammo.text = "Ammo " + player.GetComponent<PlayerController>().ammo;
        health.text = "Health " + player.GetComponent<PlayerController>().health;
    }
}
