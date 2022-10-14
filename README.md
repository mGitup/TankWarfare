# TankWarfare
基于 Unity 引擎的坦克大战

有单人和双人两种模式，地图是随机生成的，包括 5 种元素，分别是草丛、河流、木块、石块、Boss


草丛  子弹和坦克都可穿过

河流  子弹可穿过

木块  子弹可击毁

石块  子弹和坦克都不可穿过、不可击毁

Boss  子弹可击毁


最外面一圈没有石块生成，确保地图至少有一条通路，通过控制各种元素的数量控制地图的外观及密集程度。

敌方坦克 AI：每隔一段时间生成一个敌方坦克，每隔一段时间发射一颗子弹，每隔一段时间随机转变一次方向。三段时间都不相同，使得 AI 有较智能的表现。

玩家出生时短暂无敌

各方的子弹会穿过己方，不会造成伤害。


![tmp557](https://user-images.githubusercontent.com/88976609/195773152-e09e7fed-df3d-414f-84ad-87c647452e93.png)


![tmp1060](https://user-images.githubusercontent.com/88976609/195773163-9a9e197c-89ab-448f-9067-1ceac0178b78.png)


![tmpCB67](https://user-images.githubusercontent.com/88976609/195773178-953d2260-163e-4992-a8cc-8ecf21dce51a.png)
