package com.example.zainasghar.recyclerview;

import android.content.SharedPreferences;

/**
 * Created by zkingleo2009 on 1/17/2018.
 *
 * @package pk.edu.pucit.app.application
 * @project Application
 */

public class Globals {

    public static SharedPreferences prefs;


    // SHARED PREFERENCES KEYS
    public static final String PREF_NOT_LOGIN="not_login";
    public static final String PREF_USER_ID="user_id";
    public static final String PREF_IS_ADMIN="is_admin";


    // Permissions Request Code
    public  static final int WRITE_EXTERNAL = 6788;
    public  static final int WRITE_EXTERNAL_IMAGE = 4444;
    public  static final int READ_EXTERNAL_IMAGE = 5555;

    // SHARED PREFERENCES KEYS
    public static final String PREF_FIRST_START="first_start";
    //intent request code
    public  static final int SELECTED_PICTURE = 1234;

    //images folder name
    public static final String IMAGE_FOLDER="my_shopper_images";


}
