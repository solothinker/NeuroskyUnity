# NeuroskyUnity
Developing BCI (Brain-Computer Interface) games in Unity using the NeuroSky headset. During research, it was observed that many available plugins rely on older versions of Unity. The repository [tgraupmann/unity_neurosky](https://github.com/tgraupmann/unity_neurosky.git) was identified as a useful starting point, as it connects to NeuroSky using the ThinkGear Connector (TGC). The code structure from that repository was adapted to work with Unity version 6000.0.29f1.

Updated the **TGCConnectionController** code for following Packet-
- {"eSense":{"attention":13,"meditation":100},"eegPower":{"delta":271241,"theta":31509,"lowAlpha":22531,"highAlpha":3945,"lowBeta":12849,"highBeta":4603,"lowGamma":2144,"highGamma":871},"poorSignalLevel":0}
- Updated the Game UI to show the different brain wave strength.
![GameUI](https://github.com/solothinker/NeuroskyUnity/blob/main/GameImg/GUI.png)
