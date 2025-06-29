using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace MindWave
{

    public class UdateStatus : MonoBehaviour
    {
        public Image CurrentImage;
        [HideInInspector] public int currentStatus;
        public TextMeshProUGUI WaveValue;
        private int maxStatus = 100;
        private float lerpSpeed;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            currentStatus = maxStatus;
        }

        // Update is called once per frame
        void Update()
        {
            WaveValue.text = currentStatus.ToString();
            lerpSpeed = 3f * Time.deltaTime;

            WaveValueFiller();
            colorChanger();
        }

        private void colorChanger()
        {
            Color statusColor = Color.Lerp(Color.red, Color.green, ((float)currentStatus / maxStatus));
            CurrentImage.color = statusColor;
        }

        private void WaveValueFiller()
        {
            CurrentImage.fillAmount = Mathf.Lerp(CurrentImage.fillAmount, ((float)currentStatus / maxStatus), lerpSpeed);
        }

        public void SetStatus(int newStatus)
        {
            currentStatus = Mathf.Clamp(newStatus, 0, maxStatus);
        }
    }
}