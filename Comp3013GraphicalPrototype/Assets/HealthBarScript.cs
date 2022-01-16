using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] GameObject L;
    [SerializeField] GameObject I;
    [SerializeField] GameObject F;
    [SerializeField] GameObject E;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OneHP()
    {
        L.SetActive(true);
        I.SetActive(false);
        F.SetActive(false);
        E.SetActive(false);
    }

    public void TwoHP()
    {
        L.SetActive(true);
        I.SetActive(true);
        F.SetActive(false);
        E.SetActive(false);
    }

    public void ThreeHP()
    {
        L.SetActive(true);
        I.SetActive(true);
        F.SetActive(true);
        E.SetActive(false);
    }

    public void FourHP()
    {
        L.SetActive(true);
        I.SetActive(true);
        F.SetActive(true);
        E.SetActive(true);
    }

}
