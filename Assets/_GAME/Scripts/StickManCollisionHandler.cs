using System.Collections;
using UnityEngine;

public class StickManCollisionHandler : MonoBehaviour
{
    public bool flying=false;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            flying = false;
            StopCoroutine(TimeCounter());

        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            flying = true;
            StartCoroutine(TimeCounter());
        }
    }
    

    IEnumerator TimeCounter()
    {
        yield return new WaitForSeconds(5f);
        if (flying)
        {
            gameObject.SetActive(false);
        }
        yield return null;
    }
}
