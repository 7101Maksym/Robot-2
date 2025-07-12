using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayersRaftSetter : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;

    private Tilemap _myTilemap;

    private Tile _tile;

    private void Awake()
    {
        _tile = new Tile();
        _tile.sprite = _sprite;
        _myTilemap = GetComponent<Tilemap>();

        _myTilemap.SetTile(Vector3Int.zero, _tile);
    }
}
