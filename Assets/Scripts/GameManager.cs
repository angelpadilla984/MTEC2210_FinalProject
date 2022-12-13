using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public Transform leftTran;
    public Transform rightTran;
    public AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        InvokeRepeating("SpawnItem", 0, 2);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnItem()
    {
        float rndXValue = Random.Range(leftTran.position.x, rightTran.position.x);

        Vector2 spawnPos = new Vector2(rndXValue, leftTran.position.y);

        int index = Random.Range(0, itemPrefab.Length);
        Instantiate(itemPrefab[index], spawnPos, Quaternion.identity);
    }




    public void PlaySound(AudioClip clip)
    {

       audioSource.PlayOneShot(clip);

    }

    


}




