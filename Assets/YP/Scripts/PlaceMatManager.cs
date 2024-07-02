using Autohand;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaceMatManager : MonoBehaviour
{
    public PlacePoint placePoint;
    private CstmrController cstmrController;

    private bool[] playOnce = new bool[10];

    void OnEnable()
    {
        placePoint.OnPlaceEvent += OnPlace;
        placePoint.OnRemoveEvent += OnPlace;
    }

    private void OnDisable()
    {
        placePoint.OnPlaceEvent -= OnPlace;
        placePoint.OnRemoveEvent -= OnPlace;

    }

    private void OnPlace(PlacePoint point, Grabbable grab)
    {
        Debug.Log(grab.name);
        if (grab.CompareTag("Menu"))
        {
            Debug.Log("메뉴 행동!");
            if (!playOnce[0])
            {
                playOnce[0] = true;
                cstmrController = FindObjectOfType<CstmrController>();
                cstmrController.cstmrStat = "readingMenu";
            }
        }
        else if (grab.CompareTag("Cup"))
        {
            Debug.Log("컵 행동!");
            cstmrController = FindObjectOfType<CstmrController>();
            cstmrController.cstmrStat = "served";
            //var mix = grab.GetComponent<CupController>().mixture;
            var mix = grab.GetComponent<CupController>().mixture;
            var order = BaristaManager.Instance.order;
            string done = RecipeManager.Instance.MixtureFinder(mix, order);
            if (done != "other")
            {
                Debug.Log("맞음");
                cstmrController.cstmrStat = "matched";
            }
            else if (done == "other")
            {
                Debug.Log("틀림");
                cstmrController.cstmrStat = "mismatched";
            }
        }
    }

    private void OnRemove(PlacePoint point, Grabbable grab)
    {
        //Stuff happens when placed was removed

    }
}
