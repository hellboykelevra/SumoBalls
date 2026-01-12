using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GeneratePlatforms : MonoBehaviour
{
    [SerializeField] GameObject plataforma;
    int tiempo1, tiempo2, cooldown1, cooldown2;
    void Start()
    {

        tiempo1 = Random.Range(3, 6);
        tiempo2 = Random.Range(3, 6);
        cooldown1 = Random.Range(1, 5);
        cooldown2 = Random.Range(1, 5);
        StartCoroutine(cd1());
        StartCoroutine(cd2());
    }
    IEnumerator cd1()
    {
        yield return new WaitForSeconds(cooldown1);
        StartCoroutine(plat1());
        cooldown1 = Random.Range(1, 5);
    }
    IEnumerator cd2()
    {
        yield return new WaitForSeconds(cooldown2);
        StartCoroutine(plat2());
        cooldown2 = Random.Range(1, 5);
    }
    IEnumerator plat1()
    {
        GameObject nuevaplataforma1 = Instantiate(plataforma, new Vector2(-7, -2), Quaternion.identity);
        yield return new WaitForSeconds(tiempo1);
        Destroy(nuevaplataforma1);
        tiempo1 = Random.Range(3, 6);
        StartCoroutine(cd1());
    }
    IEnumerator plat2()
    {
        GameObject nuevaplataforma2 = Instantiate(plataforma, new Vector2(7, -2), Quaternion.identity);
        yield return new WaitForSeconds(tiempo2);
        Destroy(nuevaplataforma2);
        tiempo2 = Random.Range(3, 6);
        StartCoroutine(cd2());
    }
}
