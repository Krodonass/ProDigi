using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    [HideInInspector]
    public Vector3 closedPosition = Vector3.zero; // Start-/Closed-Position (wird in Start übernommen)
    public Vector3 openPosition = new Vector3(0,0,-0.4f); // Offset zur Closed-Position für das Öffnen
    public float animationTime = .5f;             // Zeit in Sekunden für das Öffnen/Schließen

    private bool isOpen = false;
    private bool isAnimating = false;

    void Start()
    {
        // Closed-Position initial speichern
        closedPosition = transform.localPosition;
    }

    public void ToggleDrawer()
    {
        if (!isAnimating)
        {
            StartCoroutine(AnimateDrawer());
        }
    }

    IEnumerator AnimateDrawer()
    {
        isAnimating = true;

        float timeElapsed = 0f;
        Vector3 startPos = transform.localPosition;
        // targetPos ist jetzt entweder closedPosition (zum Schließen)
        // oder closedPosition + openPosition (zum Öffnen)
        Vector3 targetPos = isOpen
            ? closedPosition
            : closedPosition + openPosition;

        while (timeElapsed < animationTime)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / animationTime;
            transform.localPosition = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        // am Ende exakt setzen
        transform.localPosition = targetPos;
        isOpen = !isOpen;
        isAnimating = false;
    }
}