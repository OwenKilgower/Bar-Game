using System;
using UnityEngine;

namespace Divij_Assets.Scripts
{
    public class ScoreText : MonoBehaviour
    {
        public float riseSpeed = 1f;
        public float lifeTime = 1f;

        private TextMesh textMesh;

        private void Awake()
        {
            textMesh = GetComponent<TextMesh>();
        }
        

        public void SetText(string text)
        {
            if (textMesh == null)
            {
                textMesh = GetComponent<TextMesh>();
                
                Destroy(gameObject, lifeTime);
            
            }

            if (textMesh != null)
            {
                textMesh.text = text;
            }


            
        }
        
        void Update()
        {
            transform.position += Vector3.up * riseSpeed * Time.deltaTime;


        }
    }
}
