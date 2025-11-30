using CosmicCuration.Bullets;
using UnityEngine;

namespace CosmicCuration.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private Bulletpool bulletpool;

        public PlayerService(PlayerView playerViewPrefab, PlayerScriptableObject playerScriptableObject, BulletView bulletPrefab, BulletScriptableObject bulletScriptableObject)
        {
           
            bulletpool = new Bulletpool(bulletPrefab,bulletScriptableObject);
            playerController = new PlayerController(playerViewPrefab, playerScriptableObject, bulletpool);
        }

        public PlayerController GetPlayerController() => playerController;

        public Vector3 GetPlayerPosition() => playerController.GetPlayerPosition();


        public void ReturnTothePool(BulletController bullet)
        {
            bulletpool.ReturningtoBulletPool(bullet);
        }

    } 
}