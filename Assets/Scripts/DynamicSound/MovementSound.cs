using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicAudio;
using UnityEngine.Tilemaps;
[RequireComponent(typeof(AudioSource))]
public class MovementSound : MonoBehaviour
{
   
    public DynamicAudio.SoundHolder sound;
    public AudioSource audioSource;
    public LayerMask layer;
    public List<TileData> _tileDatas;

    
    public Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach(var tileData in _tileDatas)
        {
            foreach(var tile in tileData.tileDataSet)
            {
                Debug.Log(tile.tile + " ," +  tileData);

                dataFromTiles.Add(tile.tile, tileData);
            }
        }
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * 0.5f,Color.red);
    }
    public void WalkSound()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, layer);
        if(ray.collider != null)
        {
            Debug.Log("hit");   
            if (ray.collider.GetComponent<Tilemap>())
            {   
                var map = ray.collider.GetComponent<Tilemap>();
                Vector3Int gridposition = map.LocalToCell(ray.point);
                gridposition.y -= 1;

                TileBase hitTile = map.GetTile(gridposition);
                if (dataFromTiles.ContainsKey(hitTile))
                {
                    Debug.Log(dataFromTiles[hitTile].type);
                    DynamicSound.PlaySound(dataFromTiles[hitTile].type, sound, this.gameObject);

                }


            }
            if (ray.collider.GetComponent<ObjectInfo>())
            {
                Debug.Log("here");
                DynamicSound.PlaySound(ray.collider.GetComponent<ObjectInfo>(),sound);

            }
        }
    }
}
