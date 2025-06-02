using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIBlurEffect : MonoBehaviour
{
    [Range(0, 10)] public float blurSize = 2f;
    [ColorUsage(true, true)] public Color blurColor = new Color(1, 1, 1, 0.5f);

    private Camera blurCamera;
    private RenderTexture renderTexture;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        CreateBlurEffect();
    }

    void CreateBlurEffect()
    {
        // 1. Создаем RenderTexture
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        renderTexture.Create();

        // 2. Создаем камеру для захвата фона
        blurCamera = new GameObject("BlurCamera").AddComponent<Camera>();
        blurCamera.CopyFrom(Camera.main); // Копируем настройки основной камеры
        blurCamera.targetTexture = renderTexture;
        blurCamera.clearFlags = CameraClearFlags.SolidColor;
        blurCamera.backgroundColor = Color.clear; // Прозрачный фон
        blurCamera.cullingMask = LayerMask.GetMask("Default"); // Настраиваем, что рендерить

        // 3. Назначаем материал с шейдером
        var material = new Material(Shader.Find("UI/BlurBackground"));
        material.SetTexture("_BackgroundTex", renderTexture);
        material.SetFloat("_BlurSize", blurSize);
        material.SetColor("_Color", blurColor);

        image.material = material;
    }

    void Update()
    {
        // Обновляем размытие каждый кадр (если фон динамический)
        if (image.material != null)
        {
            image.material.SetFloat("_BlurSize", blurSize);
            image.material.SetColor("_Color", blurColor);
        }
    }

    void OnDestroy()
    {
        if (renderTexture != null) renderTexture.Release();
        if (blurCamera != null) Destroy(blurCamera.gameObject);
    }
}