using UnityEngine;

namespace Platforms
{
    public class Block : MonoBehaviour
    {
        [SerializeField]
        private float distance = 3.1f;

        private float minX = -2.35f;
        private float maxX = 2.35f;

        private float startingYPoint;
        public GameObject[] platforms;

        public void Spawn(float yPoint)
        {
            startingYPoint = yPoint;
            for (int i = 0; i < platforms.Length; i++)
            {
                if (platforms[i].gameObject.tag != "BasicPlatform")
                {
                    float xPos = Random.Range(minX, maxX);
                    Vector3 pos = new Vector3(xPos, startingYPoint + (distance * i), 0);
                    Instantiate(platforms[i], pos, Quaternion.identity);
                }
                else
                {
                    Vector3 pos = new Vector3(0, startingYPoint + (distance * i), 0);
                    Instantiate(platforms[i], pos, Quaternion.identity);
                }

            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
