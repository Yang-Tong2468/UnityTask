using UnityEngine;

public class Room : MonoBehaviour
{
    public int column;

    public int line;


    private SpriteRenderer spriteRenderer;

    public RoomDataSO roomData;

    public RoomState roomState;

    private void Awake(){
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start(){
        SetupRoom(column:0, line:0, roomData);
    }

    private void OnMouseDown(){
        //处理点击事件
        Debug.Log("点击了房间：" + roomData.roomType);
    }

    //外部创建房间时调用配置房间

    public void SetupRoom(int column,int line,RoomDataSO roomData){
        this.column = column;
        this.line = line;
        this.roomData = roomData;

        spriteRenderer.sprite = roomData.roomIcon;
    }
}