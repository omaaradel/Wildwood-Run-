using System.Collections;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    private Collect manager;
    private float starsDeserved;

    [SerializeField] Star[] stars;
    [SerializeField] float enlargeScale = 1.5f;
    [SerializeField] float shrinkScale = 1f;
    [SerializeField] float enlargeDuration = 0.25f;
    [SerializeField] float shrinkDuration = 0.25f;

    void Start()    
    {
        
        manager = GameObject.Find("Player").GetComponent<Collect>();
    }

    public void showStars(int numberOfStars)
    {
        StartCoroutine(ShowStarsRoutine(numberOfStars));
    }

    private IEnumerator ShowStarsRoutine(int numberOfStars)
    {
        foreach (Star star in stars)
        {
            star.YellowStar.transform.localScale = Vector3.zero;
        }
        if (manager.scoreAddedOneLevel>=manager.gemsNeeded) { starsDeserved = 3; }
        else if (manager.scoreAddedOneLevel >= manager.gemsNeeded / 2) { starsDeserved = 2; }
        else { starsDeserved = 1; }

        for (int i = 0; i < starsDeserved; i++)
        {
            yield return StartCoroutine(EnlargeAndShrinkStar(stars[i]));
        }
    }

    private IEnumerator EnlargeAndShrinkStar(Star star)
    {
        yield return StartCoroutine(ChangeStarScale(star, enlargeScale, enlargeDuration));
        yield return StartCoroutine(ChangeStarScale(star, shrinkScale, shrinkDuration));
    }

    private IEnumerator ChangeStarScale(Star star, float targetScale, float duration)
    {
        Vector3 initialScale = star.YellowStar.transform.localScale;
        Vector3 finalScale = new Vector3(targetScale, targetScale, targetScale);

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            star.YellowStar.transform.localScale = Vector3.Lerp(initialScale, finalScale, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        star.YellowStar.transform.localScale = finalScale;
    }
}


