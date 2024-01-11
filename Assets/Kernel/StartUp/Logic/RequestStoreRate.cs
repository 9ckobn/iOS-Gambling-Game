using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.iOS;

public class RequestStoreRate : MonoBehaviour
{
    async void Awake()
    {
        DontDestroyOnLoad(this);

        await WaitForRequest();
    }

    private async UniTask WaitForRequest()
    {
        await UniTask.Delay(35000);

        Device.RequestStoreReview();
    }
}
