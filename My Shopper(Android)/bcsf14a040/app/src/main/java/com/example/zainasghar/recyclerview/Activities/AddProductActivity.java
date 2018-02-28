package com.example.zainasghar.recyclerview.Activities;

import android.Manifest;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Environment;
import android.preference.PreferenceManager;
import android.provider.MediaStore;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RatingBar;
import android.widget.Toast;

import com.example.zainasghar.recyclerview.Database.DBHelper;
import com.example.zainasghar.recyclerview.Globals;
import com.example.zainasghar.recyclerview.R;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;

public class AddProductActivity extends AppCompatActivity {

    //navbar
    private Button allProducts;
    private Button addProduct;
    private Button logOut;
    //----

    private EditText name;
    private EditText price;
    private EditText quantity;
    private EditText description;
    private RatingBar rbRating_add;
    private Button btnInsert;
    private Button upload;

    private Bitmap bmp; //image upload

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_product);


        name = (EditText) findViewById(R.id.name);
        price = (EditText) findViewById(R.id.price);
        quantity = (EditText) findViewById(R.id.quantity);
        description = (EditText) findViewById(R.id.description);
        rbRating_add = (RatingBar) findViewById(R.id.rbRating_add);
        btnInsert = (Button) findViewById(R.id.btnInsert);
        upload = (Button) findViewById(R.id.upload);



        upload.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(Intent.ACTION_PICK, MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
                startActivityForResult(i,Globals.SELECTED_PICTURE);
            }
        });


        btnInsert.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                if (name.getText().toString().equals("") || price.getText().toString().equals("")|| quantity.getText().toString().equals("")|| description.getText().toString().equals("") )
                {
                    Toast.makeText(AddProductActivity.this, "All Fields Required!", Toast.LENGTH_SHORT).show();
                }
                else
                {
                    String name2 = name.getText().toString();
                    int price2 = Integer.valueOf(price.getText().toString());
                    int quantity2 = Integer.valueOf(quantity.getText().toString());
                    String desc = description.getText().toString();
                    float rating2 = (float) rbRating_add.getRating();
                    SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(AddProductActivity.this);
                    String user_id = preferences.getString(Globals.PREF_USER_ID, "");

                    if (ContextCompat.checkSelfPermission(AddProductActivity.this, Manifest.permission.WRITE_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED) {
                        ActivityCompat.requestPermissions(AddProductActivity.this,
                                new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE},
                                Globals.WRITE_EXTERNAL_IMAGE);
                    }
                    else {

                        saveImage(bmp,name2);

                        DBHelper db = new DBHelper(AddProductActivity.this);
                        long check = db.insert_product(name2, price2, quantity2, desc, rating2, user_id);
                        if (check > 0) {
                            Toast.makeText(AddProductActivity.this, "Product Added!", Toast.LENGTH_SHORT).show();
                        }
                    }
                }
            }
        });






        //navbar
        allProducts = (Button) findViewById(R.id.allProducts);
        addProduct = (Button) findViewById(R.id.addProduct);
        logOut = (Button) findViewById(R.id.logOut);

        allProducts.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
            {
                Intent i = new Intent(AddProductActivity.this, MainActivity.class);
                finish();
                startActivity(i);
            }
        });
//        addProduct.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v)
//            {
//                Intent i = new Intent(AddProductActivity.this, AddProductActivity.class);
//                finish();
//                startActivity(i);
//            }
//        });
        logOut.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
            {
                SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(AddProductActivity.this);
                preferences.edit().putBoolean(Globals.PREF_IS_ADMIN, false ).apply();

                preferences.edit().putBoolean(Globals.PREF_NOT_LOGIN, true).apply();
                Intent i = new Intent(AddProductActivity.this, LoginActivity.class);
                finish();
                startActivity(i);

            }
        });
        //---
    }


    private void saveImage(Bitmap subImg , String imgname){
        Bitmap bmp = subImg;



        FileOutputStream out = null;
        String filename=imgname+".png";

        File sd = new File(Environment.getExternalStorageDirectory() + "/"+Globals.IMAGE_FOLDER);
        boolean success = true;
        if(!sd.exists())
        {
            success = sd.mkdir();
        }
        if(success){
            File dest = new File(sd,filename);
            try {
                out = new FileOutputStream(dest);
                bmp.compress(Bitmap.CompressFormat.PNG, 100, out);
            }
            catch (Exception e)
            {
                e.printStackTrace();
                //Log.d(TAG,e.getMessage());
            }finally {
                {
                    try {
                        if(out != null){
                            out.close();
                            //Log.d(TAG, "Ok!!");
                        }
                    }
                    catch (IOException e){
                        //Log.d(TAG, e.getMessage() + "Error");
                        e.printStackTrace();
                    }
                }
            }
        }


    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        switch (requestCode){
            case Globals.SELECTED_PICTURE:
                if(resultCode == RESULT_OK){
                    Uri uri = data.getData();

                    String[]projection ={MediaStore.Images.Media.DATA};
                    Cursor cursor = getContentResolver().query(uri,projection,null,null,null);
                    cursor.moveToFirst();

                    int columnIndex = cursor.getColumnIndex(projection[0]);
                    String filePath = cursor.getString(columnIndex);
                    cursor.close();
                    bmp = BitmapFactory.decodeFile(filePath);
                }
        }
    }

    @Override
    public void onRequestPermissionsResult(int requestCode,
                                           String permissions[], int[] grantResults) {
        switch (requestCode) {
            case Globals.WRITE_EXTERNAL_IMAGE:
                if (grantResults.length > 0) {
                    for (int i = 0; i < grantResults.length; i++) {
                        if (PackageManager.PERMISSION_GRANTED == grantResults[i]) {
                            if (name.getText().toString().equals("") || price.getText().toString().equals("")|| quantity.getText().toString().equals("")|| description.getText().toString().equals("") )
                            {
                                Toast.makeText(AddProductActivity.this, "All Fields Required!", Toast.LENGTH_SHORT).show();
                            }
                            else {
                                String name2 = name.getText().toString();
                                int price2 = Integer.valueOf(price.getText().toString());
                                int quantity2 = Integer.valueOf(quantity.getText().toString());
                                String desc = description.getText().toString();
                                float rating2 = (float) rbRating_add.getRating();
                                SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(AddProductActivity.this);
                                String user_id = preferences.getString(Globals.PREF_USER_ID, "");

                                saveImage(bmp, name2);

                                DBHelper db = new DBHelper(AddProductActivity.this);
                                long check = db.insert_product(name2, price2, quantity2, desc, rating2, user_id);
                                if (check > 0) {
                                    Toast.makeText(AddProductActivity.this, "Product Added!", Toast.LENGTH_SHORT).show();
                                }
                            }
                        } else {
                            Toast.makeText(AddProductActivity.this, "Grant Permission To Add Product", Toast.LENGTH_SHORT).show();
                            //onBackPressed();
                        }
                    }
                }
                break;
        }
    }




    @Override
    public boolean onCreateOptionsMenu(Menu menu) {

        SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(this);
        if (preferences.getBoolean(Globals.PREF_IS_ADMIN, false)) {
            getMenuInflater().inflate(R.menu.database_menu, menu);
            return super.onCreateOptionsMenu(menu);
        }
        return super.onCreateOptionsMenu(menu);

    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.database:

                Intent i = new Intent(AddProductActivity.this, AndroidDatabaseManager.class);
                startActivity(i);
            default:
                return super.onOptionsItemSelected(item);
        }
    }


    boolean check = false;
    @Override
    public void onBackPressed() {
        if(!check){
            Toast.makeText(AddProductActivity.this, "Press Back again!", Toast.LENGTH_SHORT).show();
            check =true;
        }else {
            super.onBackPressed();
        }
    }
}
