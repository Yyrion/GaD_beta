using UnityEngine;

public class Rope : MonoBehaviour
{

    private LineRenderer _lineRenderer;
    public Transform StartRope;
    public Transform EndRope;

    void Start()
    {
        StartRope = transform.Find("Start").transform;
        EndRope = transform.Find("End").transform ;
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.SetPosition(0, transform.Find("Origin").transform.position);
        _lineRenderer.SetPosition(1, StartRope.position);
        _lineRenderer.SetPosition(2, EndRope.position);
        _lineRenderer.alignment = LineAlignment.View;
    }
}
