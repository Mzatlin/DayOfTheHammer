using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevelOnElevator : MonoBehaviour
{
    [SerializeField]
    string name = "";

    IElevatorStart start;
    // Start is called before the first frame update
    void Start()
    {
        start = GetComponent<IElevatorStart>();
        start.OnElevatorStart += HandleStart;
    }

    private void HandleStart()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

}
