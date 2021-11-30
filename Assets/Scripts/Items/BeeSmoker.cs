using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSmoker : MonoBehaviour, Interactable
{
    public void Interact(GameObject target)
    {
        BeeHive beehive = target.GetComponent<BeeHive>();
        if (!beehive) return;
        if (beehive.paralyzed) return;
        beehive.paralyzed = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
