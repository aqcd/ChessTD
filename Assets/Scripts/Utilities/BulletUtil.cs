using UnityEngine;

public class BulletUtil {
    public static void activateBullet(GameObject bullet) {
        bullet.SetActive(true);
    }

    public static void deactivateBullet(GameObject bullet) {
        bullet.GetComponent<TrailRenderer>().Clear();
        bullet.SetActive(false);
    }
}