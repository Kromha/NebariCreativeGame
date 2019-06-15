using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLine2D : MonoBehaviour
{

    [SerializeField]
    protected LineRenderer m_LineRenderer;
    [SerializeField]
    protected bool m_AddCollider = false;
    [SerializeField]
    protected EdgeCollider2D m_EdgeCollider2D;
    [SerializeField]
    protected Camera m_Camera;
    protected List<Vector2> m_Points;

    public Color lineColor;
    public float lineWidth;
    public GameObject parent;
    private GameObject child;
    public bool draw;

    private float drawTimer;
    public float maxDrawTime;
    private float deltaImage;
    public Image circle;

    public virtual LineRenderer lineRenderer
    {
        get
        {
            return m_LineRenderer;
        }
    }

    public virtual bool addCollider
    {
        get
        {
            return m_AddCollider;
        }
    }

    public virtual EdgeCollider2D edgeCollider2D
    {
        get
        {
            return m_EdgeCollider2D;
        }
    }

    public virtual List<Vector2> points
    {
        get
        {
            return m_Points;
        }
    }

    protected virtual void Awake()
    {
        draw = false;
        drawTimer = 0.0f;
        deltaImage = 1.0f / maxDrawTime;

        if (m_LineRenderer == null)
        {
            Debug.LogWarning("DrawLine: Line Renderer not assigned, Adding and Using default Line Renderer.");
            CreateDefaultLineRenderer();
        }
        if (m_EdgeCollider2D == null && m_AddCollider)
        {
            Debug.LogWarning("DrawLine: Edge Collider 2D not assigned, Adding and Using default Edge Collider 2D.");
            CreateDefaultEdgeCollider2D();
        }
        if (m_Camera == null)
        {
            m_Camera = Camera.main;
        }
        m_Points = new List<Vector2>();
    }

    protected virtual void Update()
    {
        if (draw)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Reset();
            }
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePosition = m_Camera.ScreenToWorldPoint(Input.mousePosition);
                if (!m_Points.Contains(mousePosition))
                {
                    //Interface
                    drawTimer += Time.deltaTime;
                    circle.fillAmount -= deltaImage * Time.deltaTime;

                    m_Points.Add(mousePosition);
                    m_LineRenderer.positionCount = m_Points.Count;
                    m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, mousePosition);
                    if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                    {
                        m_EdgeCollider2D.points = m_Points.ToArray();
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                CreateDefaultLineRenderer();
                CreateDefaultEdgeCollider2D();
            }
            /*
            //Hay contacto
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Reset();
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 mousePosition = m_Camera.ScreenToWorldPoint(touch.position);
                    if (!m_Points.Contains(mousePosition))
                    {
                         //Interface
                        drawTimer += Time.deltaTime;
                        circle.fillAmount -= deltaImage * Time.deltaTime;

                        m_Points.Add(mousePosition);
                        m_LineRenderer.positionCount = m_Points.Count;
                        m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, mousePosition);
                        if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                        {
                            m_EdgeCollider2D.points = m_Points.ToArray();
                        }
                    }
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    CreateDefaultLineRenderer();
                    CreateDefaultEdgeCollider2D();
                }
            }
            */
            if (drawTimer >= maxDrawTime)
            {
                draw = false;
            }
        }
    }

    protected virtual void Reset()
    {
        if (m_LineRenderer != null)
        {
            m_LineRenderer.positionCount = 0;
        }
        if (m_Points != null)
        {
            m_Points.Clear();
        }
        if (m_EdgeCollider2D != null && m_AddCollider)
        {
            m_EdgeCollider2D.Reset();
        }
    }

    protected virtual void CreateDefaultLineRenderer()
    {
        child = new GameObject("line");
        child.transform.parent = parent.transform;

        m_LineRenderer = child.AddComponent<LineRenderer>();
        m_LineRenderer.positionCount = 0;
        m_LineRenderer.material = new Material(Shader.Find("UnityLibrary/Particles/Additive Scrolling UV"));
        m_LineRenderer.startColor = lineColor;
        m_LineRenderer.endColor = lineColor;
        m_LineRenderer.startWidth = lineWidth;
        m_LineRenderer.endWidth = lineWidth;
        m_LineRenderer.useWorldSpace = true;
        m_LineRenderer.sortingLayerName = "Objects";
    }

    protected virtual void CreateDefaultEdgeCollider2D()
    {
        m_EdgeCollider2D = child.AddComponent<EdgeCollider2D>();
    }

    public void recalculateDeltaImage(float time)
    {
        deltaImage = 1.0f / time;
    }
}
