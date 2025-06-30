using System;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static MindWave.TGCConnectionController;

namespace MindWave
{
    public class NeuroskyGUIManager : MonoBehaviour
    {
        public TGCConnectionController controller;
        

        private int meditationValue = -1;
        private int attentionValue = -1;

        private float deltaValue = -1;
        private float thetaValue = -1;
        private float lowAlphaValue = -1;
        private float highAlphaValue = -1;
        private float lowBetaValue = -1;
        private float highBetaValue = -1;
        private float lowGammaValue = -1;
        private float highGammaValue = -1;

        private float minValue = 0f;
        private float deltaMaxValue = 100f;
        private float thetaMaxValue = 100f;
        private float lowAlphaMaxValue = 100f;
        private float highAlphaMaxValue = 100f;
        private float lowBetaMaxValue = 100f;
        private float highBetaMaxValue = 100f;
        private float lowGammaMaxValue = 100f;
        private float highGammaMaxValue = 100f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (controller == null)
            {
                Debug.LogError("TGCConnectionController is not assigned.");
                return;
            }

            // Subscribe to meditation event
            controller.UpdateMeditationEvent += OnMeditationReceived;
            controller.UpdateAttentionEvent += OnAttentionReceived;
            controller.UpdateDeltaEvent += OnDeltaReceived;
            controller.UpdateThetaEvent += OnThetaReceived;
            controller.UpdateLowAlphaEvent += OnLowAlphaReceived;
            controller.UpdateHighAlphaEvent += OnHighAlphaReceived;
            controller.UpdateLowBetaEvent += OnLowBetaReceived;
            controller.UpdateHighBetaEvent += OnHighBetaReceived;
            controller.UpdateLowGammaEvent += OnLowGammaReceived;
            controller.UpdateHighGammaEvent += OnHighGammaReceived;
    }

        private void OnAttentionReceived(int value)
        {
            attentionValue = value;
            UIStatusManager.Instance.UpdatePlayerStatus(0, value);
        }

        private void OnMeditationReceived(int value)
        {
            meditationValue = value;
            UIStatusManager.Instance.UpdatePlayerStatus(1, value);
        }

        private void OnDeltaReceived(float value)
        {
            if(value> deltaMaxValue) deltaMaxValue = value;
            deltaValue = Normalize(value,minValue, deltaMaxValue);
            UIStatusManager.Instance.UpdatePlayerStatus(2, (int)deltaValue);
        }

        private void OnThetaReceived(float value)
        {
            if (value > thetaMaxValue) thetaMaxValue = value;
            thetaValue = Normalize(value, minValue, thetaMaxValue);
            UIStatusManager.Instance.UpdatePlayerStatus(3, (int)thetaValue);
        }

        private void OnLowAlphaReceived(float value)
        {
            if (value > lowAlphaMaxValue) lowAlphaMaxValue = value;
            lowAlphaValue = Normalize(value, minValue, lowAlphaMaxValue);
            UIStatusManager.Instance.UpdatePlayerStatus(4, (int)lowAlphaValue);
        }

        private void OnHighAlphaReceived(float value)
        {
            if (value > highAlphaMaxValue) highAlphaMaxValue = value;
            highAlphaValue = Normalize(value, minValue, highAlphaMaxValue);
            UIStatusManager.Instance.UpdatePlayerStatus(5, (int)highAlphaValue);
        }

        private void OnLowBetaReceived(float value)
        {
            if (value > lowBetaMaxValue) lowBetaMaxValue = value;
            lowBetaValue = Normalize(value, minValue, lowBetaMaxValue);
            UIStatusManager.Instance.UpdatePlayerStatus(6, (int)lowBetaValue);
        }

        private void OnHighBetaReceived(float value)
        {
            if (value > highBetaMaxValue) highBetaMaxValue = value;
            highBetaValue = Normalize(value, minValue, highBetaMaxValue);
            UIStatusManager.Instance.UpdatePlayerStatus(7, (int)highBetaValue);
        }
        private void OnLowGammaReceived(float value)
        {
            if (value > lowGammaMaxValue) lowGammaMaxValue = value;
            lowGammaValue = Normalize(value, minValue, lowGammaMaxValue);
            UIStatusManager.Instance.UpdatePlayerStatus(8, (int)lowGammaValue);
        }
        private void OnHighGammaReceived(float value)
        {
            if (value > highGammaMaxValue) highGammaMaxValue = value;
            highGammaValue = Normalize(value, minValue, highGammaMaxValue);
            UIStatusManager.Instance.UpdatePlayerStatus(9, (int)highGammaValue);
        }

        
        private float Normalize(float value, float min, float max)
        {
            float clamped = Mathf.Clamp(value, min, max);
            return ((clamped - min) / (max - min)) * 100f;
        }



        // Update is called once per frame
        void Update()
        {
            //// Use the meditation value in your game logic here
            //if (meditationValue >= 0)
            //{
                
            //    // Example: display feedback based on meditation level
            //    if (meditationValue > 70)
            //    {
            //        Debug.Log("🧘‍♂️ Deep meditation");
            //    }
            //    else if (meditationValue > 40)
            //    {
            //        Debug.Log("🙂 Medium relaxation");
            //    }
            //    else
            //    {
            //        Debug.Log("😐 Low meditation");
            //    }
            //}
        }
    }
}

