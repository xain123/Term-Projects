package com.example.zainasghar.recyclerview.Database;

import android.database.MatrixCursor;
import android.database.sqlite.SQLiteException;
import android.database.sqlite.SQLiteOpenHelper;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import java.util.ArrayList;

/**
 * Created by Zain Asghar on 1/19/2018.
 */
public class DBHelper extends SQLiteOpenHelper {


    public static final String TABLE_NAME_P = "Products";
    public static final String TABLE_NAME_U = "Users";

    //COLUMN NAMES User
    public static final String U_ID = "U_ID";
    public static final String PASSWORD = "passworwd";

    //COLUMN NAMES Products
    public static final String P_ID = "P_ID";
    public static final String NAME = "name";
    public static final String PRICE = "price";
    public static final String QUANTITY = "quantity";
    public static final String DESCRIPTION = "description";
    public static final String USER_ID = "user_id";
    public static final String RATING = "rating";

    //COLUMN TYPES
    public static final String TYPE_TEXT = " TEXT ";
    public static final String TYPE_INT = " INT ";
    public static final String TYPE_REAL = " REAL ";
    public static final String SEPERATOR = ", ";
    private static final String DATABASE_NAME = "my_shopper.db";


    public DBHelper(Context context) {
        super(context, DATABASE_NAME, null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String create_query_1 = "Create table " + TABLE_NAME_U + " ("
                + U_ID + TYPE_TEXT + SEPERATOR
                + PASSWORD + TYPE_TEXT + ");";
        db.execSQL(create_query_1);

        String create_query = "Create table " + TABLE_NAME_P + " ("
                + P_ID +  " INTEGER PRIMARY KEY AUTOINCREMENT " + SEPERATOR
                + NAME + TYPE_TEXT + SEPERATOR
                + PRICE + TYPE_INT + SEPERATOR
                + QUANTITY + TYPE_INT + SEPERATOR
                + DESCRIPTION + TYPE_TEXT + SEPERATOR
                + USER_ID + TYPE_TEXT + SEPERATOR
                + RATING + TYPE_REAL + ");";
        db.execSQL(create_query);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {

        String drop_query = "drop database if exists " + DATABASE_NAME;
        db.execSQL(drop_query);
        onCreate(db);
    }

    public Cursor check_user(String id) {
        SQLiteDatabase db = getReadableDatabase();
        Cursor findEntry = db.query(TABLE_NAME_U, new String[]{U_ID, PASSWORD}, U_ID + "=?", new String[] { id }, null, null, null);

        return findEntry;
    }

    public Cursor retrive_products(String u_id) {
        SQLiteDatabase db = getReadableDatabase();
        Cursor allProducts = db.query(TABLE_NAME_P, new String[]{P_ID, NAME, PRICE, QUANTITY, DESCRIPTION, RATING, USER_ID}, USER_ID + "=?", new String[] { u_id }, null, null, null);

        return allProducts;
    }

    public Cursor retrive_product_detail(int p_id) {
        SQLiteDatabase db = getReadableDatabase();
        Cursor product = db.query(TABLE_NAME_P, new String[]{P_ID, NAME, PRICE, QUANTITY, DESCRIPTION, RATING }, P_ID + "=?", new String[] { String.valueOf(p_id) }, null, null, null);
        return product;
    }
    public Cursor retrive_all_products() {
        SQLiteDatabase db = getReadableDatabase();
        Cursor allProducts = db.query(TABLE_NAME_P, new String[]{P_ID, NAME, PRICE, QUANTITY, DESCRIPTION, RATING, USER_ID}, null, null, null, null, null);

        return allProducts;
    }

    public long insert_product(String name, int price, int quantity, String description, float rating, String userid) {
        SQLiteDatabase db = getWritableDatabase();
        ContentValues cv = new ContentValues();
        cv.put(NAME, name);
        cv.put(PRICE, price);
        cv.put(QUANTITY, quantity);
        cv.put(DESCRIPTION, description);
        cv.put(USER_ID, userid);
        cv.put(RATING, rating);
        long i = db.insert(TABLE_NAME_P, null, cv);
        Log.d("Database_helper", String.valueOf(i));
        //be sure to close database after work is done
        db.close();
        return i;
    }

    public long register_user(String userID, String password) {
        SQLiteDatabase db = getWritableDatabase();
        ContentValues cv = new ContentValues();
        cv.put(U_ID, userID);
        cv.put(PASSWORD, password);
        long i = db.insert(TABLE_NAME_U, null, cv);
        Log.d("Database_helper", String.valueOf(i));
        //be sure to close database after work is done
        db.close();
        return i;
    }

    public long delete_product(int id) {
        SQLiteDatabase db = getReadableDatabase();
        long res = db.delete(TABLE_NAME_P, P_ID + "=?", new String[] { String.valueOf( id) });
        return res;
    }

    public long update_rating(int id, Float rating) {
        SQLiteDatabase db = getReadableDatabase();

        ContentValues cv = new ContentValues();
        cv.put(DBHelper.RATING, rating);
        long res = db.update(DBHelper.TABLE_NAME_P, cv, P_ID + "=?", new String[] { String.valueOf( id) });

        return res;
    }
    public long update_product(int id, String name, int price, int quantity, String description, float rating) {
        SQLiteDatabase db = getReadableDatabase();

        ContentValues cv = new ContentValues();
        cv.put(DBHelper.RATING, rating);
        cv.put(DBHelper.NAME, name);
        cv.put(DBHelper.PRICE, price);
        cv.put(DBHelper.QUANTITY, quantity);
        cv.put(DBHelper.DESCRIPTION, description);
        long res = db.update(DBHelper.TABLE_NAME_P, cv, P_ID + "=?", new String[] { String.valueOf( id) });

        return res;
    }



    public ArrayList<Cursor> getData(String Query){
        //get writable database
        SQLiteDatabase sqlDB = this.getWritableDatabase();
        String[] columns = new String[] { "message" };
        //an array list of cursor to save two cursors one has results from the query
        //other cursor stores error message if any errors are triggered
        ArrayList<Cursor> alc = new ArrayList<Cursor>(2);
        MatrixCursor Cursor2= new MatrixCursor(columns);
        alc.add(null);
        alc.add(null);

        try{
            String maxQuery = Query ;
            //execute the query results will be save in Cursor c
            Cursor c = sqlDB.rawQuery(maxQuery, null);

            //add value to cursor2
            Cursor2.addRow(new Object[] { "Success" });

            alc.set(1,Cursor2);
            if (null != c && c.getCount() > 0) {

                alc.set(0,c);
                c.moveToFirst();

                return alc ;
            }
            return alc;
        } catch(SQLiteException sqlEx){
            Log.d("printing exception", sqlEx.getMessage());
            //if any exceptions are triggered save the error message to cursor an return the arraylist
            Cursor2.addRow(new Object[] { ""+sqlEx.getMessage() });
            alc.set(1,Cursor2);
            return alc;
        } catch(Exception ex){
            Log.d("printing exception", ex.getMessage());

            //if any exceptions are triggered save the error message to cursor an return the arraylist
            Cursor2.addRow(new Object[] { ""+ex.getMessage() });
            alc.set(1,Cursor2);
            return alc;
        }
    }

}
