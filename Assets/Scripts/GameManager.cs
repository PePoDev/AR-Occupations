using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FancyScrollView.Example01;
using ImgurAPI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Canvas result;
    public Canvas custom;

    public Image target;
    public Sprite[] occupations;
        
    public ScrollView scrollView = default;

    private int m_currentSelection;
    
    private void Awake()
    {
        Imgur.Init("4d7df76f84ab6ba442105ab432bf5abf0c5100a2");
    }

    private void Start()
    {
        var items = Enumerable.Range(0, occupations.Length)
            .Select(i => new ItemData(occupations[i]))
            .ToArray();

        scrollView.UpdateData(items);
        
        scrollView.scroller.OnSelectionChanged(id => { m_currentSelection = id;});
    }

    public void ChangeOccupation()
    {
        target.overrideSprite = occupations[m_currentSelection];
    }

    public void Capture()
    {
        
    }
}
