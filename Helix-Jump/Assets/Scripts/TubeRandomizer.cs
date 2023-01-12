using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeRandomizer : MonoBehaviour
{
    [SerializeField]
    private Material deathMaterial;

    [SerializeField]
    private int maxToDeath = 2;
    [SerializeField]
    private int maxToDelete = 2;

    private int count = 0;
    
    void Start()
    {
        foreach (Transform position in transform)
        {
            if (position.tag != "Finish")
            {
                count = 0;
                
                int rangeToDeath = Random.Range(0, maxToDeath);
                int rangeToDelete = Random.Range(1, maxToDelete);

                foreach (Transform nextposition in position.transform)
                {
                    if (nextposition.tag != "Score")
                    {
                        if (count > rangeToDeath)
                            break;

                        bool toDeath = (Random.value > 0.5f);
                        if (toDeath)
                        {
                            nextposition.gameObject.tag = "Death";
                            nextposition.gameObject.GetComponent<Renderer>().material = deathMaterial;
                            count++;
                        }
                    }
                }

                count = 0;

                foreach (Transform nextposition in position.transform)
                {
                    if (nextposition.tag != "Score")
                    {
                        if (count > rangeToDelete)
                            break;

                        bool toDelete = (Random.value > 0.5f);
                        if (toDelete)
                        {
                            nextposition.gameObject.SetActive(false);
                            count++;
                        }
                    }
                }

                if (count == 0)
                {
                    position.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
}
