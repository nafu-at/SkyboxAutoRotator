using UnityEngine;

namespace NafuSoft.SkyboxAutoRotater
{
    [ExecuteAlways]
    public class SkyboxAutoRotator : MonoBehaviour
    {
        [SerializeField] public bool isAutoRotate;
        [SerializeField] public float rotateSpeed = 0.1f;

        public float rotateValue;
        public Material targetSkybox;

        // Start is called before the first frame update
        private void Start()
        {
            if (ReferenceEquals(targetSkybox, null))
                targetSkybox = RenderSettings.skybox;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Application.isPlaying && isAutoRotate)
                rotateValue = Mathf.Repeat(targetSkybox.GetFloat("_Rotation") + rotateSpeed * Time.deltaTime, 360f);

            targetSkybox.SetFloat("_Rotation", rotateValue);
        }
    }
}
