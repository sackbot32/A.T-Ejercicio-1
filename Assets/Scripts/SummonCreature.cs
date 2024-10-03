using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonCreature : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] 
    private GameObject creaturePrefab;
    [SerializeField]
    private int howMany;
    [SerializeField]
    private float repeatTime;
    [SerializeField]
    private KeyCode keyToPush;
    [Header("Position variable")]
    [SerializeField]
    private float maxXvar;
    [SerializeField] 
    private float maxZvar;
    //Variables needed to start and stop summoning
    private bool active;
    private int summoned;

    private void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        //When the key is pushed it will call an repeating Invoke to call the summon 
        if(Input.GetKeyDown(keyToPush) && !active)
        {
            InvokeRepeating("Summon", 0f, repeatTime);
            active = true;
        }
        //Debug tool to clear summoned creatures
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
    /// <summary>
    /// Summons creature on a random point from the game object
    /// </summary>
    public void Summon()
    {
        if(summoned < howMany)
        {
            //Creates position from the base gameobject + a random vector3
            Vector3 summonPos = gameObject.transform.position + new Vector3 (Random.Range(-maxXvar,maxXvar), 0, Random.Range(-maxZvar, maxZvar));
            Instantiate(creaturePrefab, summonPos, Quaternion.identity).transform.parent = gameObject.transform;
            print("Summoned on " + gameObject.name +" on coord: " + summonPos);
            summoned++;
        } else
        {
            CancelInvoke();
            active = false;
            summoned = 0;
        }
    }
}
