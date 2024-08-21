using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SceneLoadManager : MonoBehaviour
{
    private AssetReference currentScene;

    public AssetReference map;

    private Vector2Int currentRoomVector;

    [Header("广播")]
    public ObjectEventSO afterRoomLoadedEvent;

    public async void OnLoadRoomEvent(object data)
    {
        if (data is Room)
        {
            Room currentRoom = data as Room;

            var currentData = currentRoom.roomData;

            currentRoomVector = new(currentRoom.column,currentRoom.line);

            currentScene = currentData.sceneToLoad;
        }

        await UnloadSceneTask();
        //加载房间
        await LoadSceneTask();

        afterRoomLoadedEvent.RaiseEvent(currentRoomVector,this);
    }

    private async Awaitable LoadSceneTask()
    {
        var s = currentScene.LoadSceneAsync(LoadSceneMode.Additive);

        await s.Task;

        if (s.Status == AsyncOperationStatus.Succeeded)
        {
            SceneManager.SetActiveScene(s.Result.Scene);
        }
    }

    private async Awaitable UnloadSceneTask()
    {
        await SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    public async void LoadMap(){
        await UnloadSceneTask();

        currentScene = map;

        await LoadSceneTask();
    }
}
