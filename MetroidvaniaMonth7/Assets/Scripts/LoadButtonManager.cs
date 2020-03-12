using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButtonManager : MonoBehaviour
{
    [SerializeField]
    Button newGameButton;
    [SerializeField]
    Button continueButton;
    [SerializeField]
    SaveSystemSO saveSystem;

    // Start is called before the first frame update
    void Start()
    {
        if (saveSystem.CheckIfSaved())
        {
            continueButton.interactable = true;
        }
        else
        {
            continueButton.interactable = false;
        }
    }

}
