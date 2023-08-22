using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerAbilityData abilityData;
    [SerializeField] private int stageCount = 0;
    //[SerializeField] private GameOverPopupController gameOver;
    
    private static GameManager _instance;
    //private GameOverPopupController _gameOver;
    public static GameManager Instance => _instance;
    [SerializeField]private bool ifLoseDecide = true;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        
        EventCenter.Instance.AddListener<int,int,int>("AbilityDataChange",AbilityDataChange);
        DontDestroyOnLoad(gameObject);
    }

    public void AbilityDataChange(int intelligenceChange, int virtueChange, int bodyChange)
    {
        abilityData.intelligence += intelligenceChange;
        abilityData.virtue += virtueChange;
        abilityData.body += bodyChange;

        if (stageCount > 0 && ifLoseDecide)
        {
            LoseEnd();
        }
        
        
        // //ensure all the values are in the range of (0,100)
        abilityData.intelligence = abilityData.intelligence switch
        {
            <= 0 => 0,
            > 100 => 100,
            _ => abilityData.intelligence
        };
        abilityData.virtue = abilityData.virtue switch
        {
            <= 0 => 0,
            > 100 => 100,
            _ => abilityData.virtue
        };
        abilityData.body = abilityData.body switch
        {
            <= 0 => 0,
            > 100 => 100,
            _ => abilityData.body
        };
        
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
        EventCenter.Instance.RemoveEventListener<int,int,int>("AbilityDataChange",AbilityDataChange);
    }

    public void UpdateStageCount(int count)
    {
        if (_instance == null)
        {
            return;
        }

        stageCount = count;
    }

    private void LoseEnd()
    {
        if (abilityData.intelligence <= 0 || abilityData.virtue <= 0 || abilityData.body <= 0)
        {
            EventCenter.Instance.EventTrigger("LoseEnd");
        }
    }
}
