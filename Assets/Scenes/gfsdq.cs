using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class gfsdq : MonoBehaviour
{
    public Image square;

    // Start is called before the first frame update
    void Start()
    {
        square.transform.DORotate(new Vector3(0,0,90),3).SetLoops(-1).SetEase(Ease.Linear);
        square.transform.DOScale(new Vector3(2,10,1),10).SetLoops(-1,LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
