using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public enum Direction { NORTH, NORTH_EAST, EAST, SOUTH_EAST, SOUTH, SOUTH_WEST, WEST, NORTH_WEST };

    public enum BulletBehavhior { NORMAL, LOB }

    public enum TowerType { NORMAL, VERT, LOB }

    //Normal Tower Presets
    public static Color NORMAL_COLOR = Color.blue;
    public static float NORMAL_FIRE_RATE = 1;
    public static float NORMAL_SPEED = 5f;
    public static int NORMAL_DAMAGE = 1;
    public static Direction[] NORMAL_DIRECTIONS = new Direction[1] { Direction.EAST };
    public static BulletBehavhior NORMAL_BULLET_BEHAVHIOR = BulletBehavhior.NORMAL;
    public static int NORMAL_DISTANCE = 1;

    //Vert Tower Presets
    public static Color VERT_COLOR = Color.green;
    public static float VERT_FIRE_RATE = 1;
    public static float VERT_SPEED = 5f;
    public static int VERT_DAMAGE = 1;
    public static Direction[] VERT_DIRECTIONS = new Direction[2] { Direction.NORTH, Direction.SOUTH };
    public static BulletBehavhior VERT_BULLET_BEHAVHIOR = BulletBehavhior.NORMAL;
    public static int VERT_DISTANCE = 1;

    //Lob Tower Presets
    public static float LOB_FIRE_RATE = 1;
    public static float LOB_SPEED = 5f;
    public static int LOB_DAMAGE = 1;
    public static Direction[] LOB_DIRECTIONS = new Direction[2] { Direction.NORTH, Direction.SOUTH };
    public static BulletBehavhior LOB_BULLET_BEHAVHIOR = BulletBehavhior.NORMAL;
    public static int LOB_DISTANCE = 1;
}
