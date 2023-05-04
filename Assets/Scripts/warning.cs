using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning : MonoBehaviour
{

    public MeshRenderer _meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(Blink());


    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator Blink()
    {
        while (true)
        {
            _meshRenderer.enabled = !_meshRenderer.enabled;
            yield return new WaitForSeconds(0.5f);
        }
    }


}
