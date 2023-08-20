using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerAbilityData abilityData;

    private static GameManager _instance;
    public static GameManager Instance => _instance;

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
}
