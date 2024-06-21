using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(Vector3.one * 3, 2f)
            .SetLoops(5, LoopType.Restart)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                Debug.Log("Move Done");
            });
        transform.DOScale(Vector3.one * 2, 1f)
            .SetLoops(-2, LoopType.Yoyo)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
             {
                 Debug.Log("Scale Done");
             });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
