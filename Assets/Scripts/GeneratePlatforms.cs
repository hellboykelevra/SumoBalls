using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GeneratePlatforms : MonoBehaviour
{
    [SerializeField] GameObject plataforma;
    [SerializeField] int tiempo1, tiempo2, cooldown1, cooldown2;
    bool plataforma1, plataforma2;
    void Start()
    {
        tiempo1 = 5;
        tiempo2 = 5;
        cooldown1 = 3;
        cooldown2 = 3;
        plataforma1 = true;
        plataforma2 = false;
        StartCoroutine(cd1());
        StartCoroutine(cd2());
    }
    IEnumerator cd1()
    {
        yield return new WaitForSeconds(cooldown1);
        StartCoroutine(plat1());
    }
    IEnumerator cd2()
    {
        yield return new WaitForSeconds(cooldown2);
        StartCoroutine(plat2());
    }
    IEnumerator plat1()
    {
        GameObject nuevaplataforma1 = Instantiate(plataforma, new Vector2(-7, -2), Quaternion.identity);
        yield return new WaitForSeconds(tiempo1 - 1);
        nuevaplataforma1.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1);
        Destroy(nuevaplataforma1);
            if (plataforma1)
            {
                cooldown1 = 3;
                plataforma1 = false;
            }
            else
            {
                cooldown1 = 8;
                plataforma1 = true;

            
        }
        StartCoroutine(cd1());
    }
    IEnumerator plat2()
    {
        GameObject nuevaplataforma2 = Instantiate(plataforma, new Vector2(7, -2), Quaternion.identity);
        yield return new WaitForSeconds(tiempo2 - 1);
        nuevaplataforma2.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1);
        Destroy(nuevaplataforma2);
 
            if (plataforma2)
            {
                cooldown2 = 3;
                plataforma2 = false;
            }
            else
            {
                cooldown2 = 8;
                plataforma2 = true;

            
        }
        StartCoroutine(cd2());
    }
}
