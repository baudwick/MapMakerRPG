using UnityEngine;

class GlobalProperties
{
    /* Button Names */
    public static string BUTTON_FOREST_SMALL = "Button_Forest_Small";
    public static string BUTTON_FOREST_MEDIUM = "Button_Forest_Medium";
    public static string BUTTON_FOREST_LARGE = "Button_Forest_Large";


    /* FOREST GLOBAL PROPERTIES */
    public static float BOUNDS_BUFFER_ZONE = 5.0f;

    // SMALL FOREST
    public static Vector3 FOREST_SMALL_BOUNDS = new Vector3(64, 0, 64);
    public static int FOREST_SMALL_TREE_MIN_COUNT = 20;
    public static int FOREST_SMALL_TREE_MAX_COUNT = 40;
    public static int FOREST_SMALL_FOLIAGE_MIN_COUNT = 40;
    public static int FOREST_SMALL_FOLIAGE_MAX_COUNT = 80;

    // MEDIUM FOREST
    public static Vector3 FOREST_MEDIUM_BOUNDS = new Vector3(80, 0, 80);
    public static int FOREST_MEDIUM_TREE_MIN_COUNT = 60;
    public static int FOREST_MEDIUM_TREE_MAX_COUNT = 80;
    public static int FOREST_MEDIUM_FOLIAGE_MIN_COUNT = 120;
    public static int FOREST_MEDIUM_FOLIAGE_MAX_COUNT = 160;

    // LARGE FOREST
    public static Vector3 FOREST_LARGE_BOUNDS = new Vector3(128, 0, 128);
    public static int FOREST_LARGE_TREE_MIN_COUNT = 100;
    public static int FOREST_LARGE_TREE_MAX_COUNT = 150;
    public static int FOREST_LARGE_FOLIAGE_MIN_COUNT = 200;
    public static int FOREST_LARGE_FOLIAGE_MAX_COUNT = 300;
}
