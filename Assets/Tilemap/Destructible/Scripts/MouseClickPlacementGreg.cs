using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseClickPlacementGreg : MonoBehaviour {

    Vector3 lastFramePosition;


    public TileBase m_Border;
    public TileBase m_Terrainstandard;
    public TileBase m_Cuivre;
    public TileBase m_Fer;

    public TileBase m_Usinecuivre;
    public TileBase m_Usinefer;
    public GameObject go_Usinefer;

    private Grid m_Grid;
    private Tilemap m_Foreground;
    private Tilemap m_BackGround;
    private GridInformation m_Info;

    //public const string k_Key = "exploded";

    // Use this for initialization
    void Start () {
        m_Grid = GetComponent<Grid>();
        m_Info = GetComponent<GridInformation>();
        m_Foreground = GameObject.Find("Foreground").GetComponent<Tilemap>();
        m_BackGround = GameObject.Find("Background").GetComponent<Tilemap>();
    }
	
	// Update is called once per frame
	void Update () {
 
        Vector3 currFramePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            Vector3 diff = lastFramePosition - currFramePostion;
             
            Camera.main.transform.Translate(diff);
        }
        lastFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Camera.main.orthographicSize -= Camera.main.orthographicSize * Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 3f, 15f);

        if (m_Grid && Input.GetMouseButtonDown(0))
        {
            Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = m_Grid.WorldToCell(world);
            Debug.Log(gridPos);

            //placement d une usine
            Placementusine(gridPos);

        }
    }

    private void Placementusine(Vector3Int position)
    {
        Debug.Log(m_Info.GetPositionProperty(position, "usine", 1));

        if (m_Foreground.GetTile(position) == m_Fer  && m_Info.GetPositionProperty(position, "usine", 1)!=2 )
        {
            m_Foreground.SetTile(position, m_Usinefer);
            m_Info.ErasePositionProperty(position, "");
            m_Info.SetPositionProperty(position, "usine", 2); //2 pour usine déjà placée
            GameObject usinefer = Instantiate(go_Usinefer, m_Grid.CellToLocalInterpolated(position + new Vector3(0.5f, 0.5f)), Quaternion.identity);
            usinefer.transform.parent = GameObject.Find("Usines").transform;
            


        }
        else if (m_Foreground.GetTile(position) == m_Cuivre && m_Info.GetPositionProperty(position, "usine", 1) != 2)
        {
            m_Foreground.SetTile(position, m_Usinecuivre);
            m_Info.ErasePositionProperty(position, "");
            m_Info.SetPositionProperty(position, "usine", 2); //2 pour usine déjà placée
            
            //GameObject.Instantiate(m_Explosion, m_Grid.CellToLocalInterpolated(position + new Vector3(0.5f, 0.5f)), Quaternion.identity);
        }
        else
        {
            return;
        }
    }


   

}
