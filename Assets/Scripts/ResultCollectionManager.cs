using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultCollectionManager : MonoBehaviour
{
    [SerializeField] private GameObject stage2Button;
    [SerializeField] private GameObject stage3Button;


    [Header("Stage 1 Stars")]
    [SerializeField] private GameObject[] stage1Stars; // Drag Star1, Star2, Star3 here.
    [Header("Stage 2 Stars")]
    [SerializeField] private GameObject[] stage2Stars;
    [Header("Stage 3 Stars")]
    [SerializeField] private GameObject[] stage3Stars;




    void Update()
    {
        checkUnlockStage();
        checkStage1UnlockStars();
        checkStage2UnlockStars();
        checkStage3UnlockStars();
        
    }

    private void checkUnlockStage()
    {
        if(ResultCollection.Stage2Unlocked == true)
        {
            stage2Button.SetActive(true);
        }

        if (ResultCollection.Stage3Unlocked == true)
        {
            stage3Button.SetActive(true);
        }
    }

    private void checkStage1UnlockStars()
    {
        if(ResultCollection.Stage1Star == 1)
        {
            stage1Stars[0].SetActive(true);
        }
        if (ResultCollection.Stage1Star == 2)
        {
            stage1Stars[0].SetActive(true);
            stage1Stars[1].SetActive(true);
        }
        if (ResultCollection.Stage1Star == 3)
        {
            stage1Stars[0].SetActive(true);
            stage1Stars[1].SetActive(true);
            stage1Stars[2].SetActive(true);
        }
    }

    private void checkStage2UnlockStars()
    {
        if (ResultCollection.Stage2Star == 1)
        {
            stage2Stars[0].SetActive(true);
        }
        if (ResultCollection.Stage2Star == 2)
        {
            stage2Stars[0].SetActive(true);
            stage2Stars[1].SetActive(true);
        }
        if (ResultCollection.Stage2Star == 3)
        {
            stage2Stars[0].SetActive(true);
            stage2Stars[1].SetActive(true);
            stage2Stars[2].SetActive(true);
        }
    }

    private void checkStage3UnlockStars()
    {
        if (ResultCollection.Stage3Star == 1)
        {
            stage3Stars[0].SetActive(true);
        }
        if (ResultCollection.Stage3Star == 2)
        {
            stage3Stars[0].SetActive(true);
            stage3Stars[1].SetActive(true);
        }
        if (ResultCollection.Stage3Star == 3)
        {
            stage3Stars[0].SetActive(true);
            stage3Stars[1].SetActive(true);
            stage3Stars[2].SetActive(true);
        }
    }
}
