using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine;

public class YourScript : MonoBehaviour
{
    public float distance = 2.0f; // Distance fixe à parcourir

    private void Start()
    {
        StartCoroutine(TranslateFixedDistance(distance, 2.0f)); // Appeler la coroutine avec la distance fixe et la durée
    }

    IEnumerator TranslateFixedDistance(float distanceToMove, float duration)
    {
        Vector3 startPosition = transform.localPosition;
       Vector3 endPosition = startPosition + new Vector3(0, 0, distanceToMove); // Translation le long de l'axe Y


        float startTime = Time.time;
        float journeyLength = Vector3.Distance(startPosition, endPosition);

        while (Time.time - startTime < duration)
        {
            float distCovered = (Time.time - startTime) * (journeyLength / duration);
            float fractionOfJourney = distCovered / journeyLength;

            transform.localPosition = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
/*
            foreach (var partChild in _children)
            {
                partChild.transform.localPosition = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
            }
*/
            yield return null;
        }

        // Vous pouvez ajouter une pause facultative ici si nécessaire

        // Inverser les positions pour retourner à la position de départ
        Vector3 temp = startPosition;
        startPosition = endPosition;
        endPosition = temp;

        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, endPosition);

        while (Time.time - startTime < duration)
        {
            float distCovered = (Time.time - startTime) * (journeyLength / duration);
            float fractionOfJourney = distCovered / journeyLength;

            transform.localPosition = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
/*
            foreach (var partChild in _children)
            {
                partChild.transform.localPosition = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
            }
*/
            yield return null;
        }

        // Vous pouvez répéter ce processus indéfiniment en utilisant une boucle ou en rappelant la coroutine au besoin.
    }
}
