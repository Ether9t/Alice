using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDialog : MonoBehaviour
{
    public GameObject EnterEDialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player")) 
        {
            EnterEDialog.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            EnterEDialog.SetActive(false);
        }

    }
}
