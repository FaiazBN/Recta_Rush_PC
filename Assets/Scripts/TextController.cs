using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] GameObject timeControlText;
    [SerializeField] GameObject mechanicsText;
    [SerializeField] GameObject enemyText;
    [SerializeField] GameObject recoilText;
    [SerializeField] GameObject goodLuckText;
    [SerializeField] AudioClip popUpSFX;
    [SerializeField] [Range(0,1)] float popUpVolume = 0.5f;
    void Start()
    {
        StartCoroutine(DeleteText());
    }
    private IEnumerator DeleteText()
    {
        yield return new WaitForSeconds(0.8f);
        mechanicsText.SetActive(true);
        AudioSource.PlayClipAtPoint(popUpSFX,Camera.main.transform.position,popUpVolume);
        yield return new WaitForSeconds(2.5f);
        mechanicsText.SetActive(false);
        yield return new WaitForSeconds(0.3f);

        enemyText.SetActive(true);
        AudioSource.PlayClipAtPoint(popUpSFX, Camera.main.transform.position, popUpVolume);
        yield return new WaitForSeconds(3.5f);
        enemyText.SetActive(false);
        yield return new WaitForSeconds(0.3f);

        timeControlText.SetActive(true);
        AudioSource.PlayClipAtPoint(popUpSFX, Camera.main.transform.position, popUpVolume);
        yield return new WaitForSeconds(2.5f);
        timeControlText.SetActive(false);
        yield return new WaitForSeconds(0.3f);

        recoilText.SetActive(true);
        AudioSource.PlayClipAtPoint(popUpSFX, Camera.main.transform.position, popUpVolume);
        yield return new WaitForSeconds(2.5f);
        recoilText.SetActive(false);
        yield return new WaitForSeconds(0.3f);

        goodLuckText.SetActive(true);
        AudioSource.PlayClipAtPoint(popUpSFX, Camera.main.transform.position, popUpVolume);
        yield return new WaitForSeconds(2.5f);
        goodLuckText.SetActive(false);
        yield return new WaitForSeconds(2f);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
