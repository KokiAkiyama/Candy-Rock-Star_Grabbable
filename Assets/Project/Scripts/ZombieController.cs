using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    List<SkinnedMeshRenderer> renderers;
    List<Material> materials=new();
    [SerializeField]Material material;

    // Start is called before the first frame update
    void Start()
    {
       renderers = GetComponentsInChildren<SkinnedMeshRenderer>().ToList();
    
        foreach(var renderer in renderers)
        {
            materials.Add(renderer.material);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMat()
    {
        foreach (var renderer in renderers)
        {
            renderer.material=material;
        }
    }
}
