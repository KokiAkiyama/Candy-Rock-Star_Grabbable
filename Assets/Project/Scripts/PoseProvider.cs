using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseProvider : MonoBehaviour
{
    public static PoseProvider Instance;


    [SerializeField] PoseSet paper;
    public PoseSet Paper => paper;


    [Serializable]
    public class PoseSet
    {
        [SerializeField] ActiveStateSelector right;
        [SerializeField] ActiveStateSelector left;

        public ActiveStateSelector Right => right;
        public ActiveStateSelector Left => left;

        public void AddWhenSelectedLR(Action action)
        {
           
            Right.WhenSelected += action; 
            Left.WhenSelected  += action; 
        }
        public void RemoveWhenSelectedLR(Action action)
        {
           
            Right.WhenSelected -= action; 
            Left.WhenSelected  -= action; 
        }
        
        public void AddWhenUnselectedLR(Action action)
        {
           
            Right.WhenUnselected += action; 
            Left .WhenUnselected += action; 
        }
        public void RemoveWhenUnselectedLR(Action action)
        {

            Right.WhenUnselected -= action;
            Left .WhenUnselected -= action;
        }
        public Action WhenUnselected = delegate { };
    }

    void Awake()
    {
        Instance = this;
    }
}
