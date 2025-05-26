using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Drawer : MonoBehaviour
{
    [HideInInspector]
    public Vector3 closedPosition = Vector3.zero;      // Start-/Closed-Position (wird in Start übernommen)
    public Vector3 openPosition = new Vector3(0, 0, -0.4f); // Offset zur Closed-Position für das Öffnen
    public float animationTime = 0.5f;                 // Zeit in Sekunden für das Öffnen/Schließen

    private bool isOpen = false;
    private bool isAnimating = false;
    private float timeElapsed = 0f;
    private Vector3 startPos;
    private Vector3 targetPos;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;       // Physics laufen nicht, wir bewegen per MovePosition
        rb.freezeRotation = true;    // Rotation einfrieren, falls gewünscht
    }

    void Start()
    {
        // Closed-Position initial speichern (lokal)
        closedPosition = transform.localPosition;
    }

    public void ToggleDrawer()
    {
        if (isAnimating) return;

        // Animation vorbereiten
        isAnimating = true;
        timeElapsed = 0f;
        startPos = transform.localPosition;
        targetPos = isOpen
            ? closedPosition
            : closedPosition + openPosition;
    }

    void FixedUpdate()
    {
        if (!isAnimating) return;

        // Zeit fortschreiben
        timeElapsed += Time.fixedDeltaTime;
        float t = Mathf.Clamp01(timeElapsed / animationTime);

        // Neue Zielposition (lokal)
        Vector3 newLocalPos = Vector3.Lerp(startPos, targetPos, t);

        // In globale Position umrechnen, falls es einen Parent gibt
        Vector3 newGlobalPos = transform.parent != null
            ? transform.parent.TransformPoint(newLocalPos)
            : newLocalPos;

        // Rigidbody bewegen
        rb.MovePosition(newGlobalPos);

        // Am Ende sauber abschließen
        if (t >= 1f)
        {
            isAnimating = false;
            isOpen = !isOpen;
        }
    }
}