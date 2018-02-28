package com.example.zainasghar.recyclerview.Activities;

import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.os.Environment;
import android.preference.PreferenceManager;
import android.support.design.widget.Snackbar;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.content.SharedPreferences;
import android.widget.Toast;

import com.example.zainasghar.recyclerview.Database.DBHelper;
import com.example.zainasghar.recyclerview.Globals;
import com.example.zainasghar.recyclerview.Models.Product;
import com.example.zainasghar.recyclerview.Adapter.ProductRVAdapter;
import com.example.zainasghar.recyclerview.R;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Locale;

import jxl.Workbook;
import jxl.WorkbookSettings;
import jxl.write.Label;
import jxl.write.WritableSheet;
import jxl.write.WritableWorkbook;

public class MainActivity extends AppCompatActivity {
    //navbar
    private Button allProducts;
    private Button addProduct;
    private Button logOut;
    //----
    private View snackview;
    private Snackbar snackbar;

    private RecyclerView rvProducts;
    private ArrayList<Product> alProducts;
    private ProductRVAdapter rvaStudents;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setTheme(R.style.AppTheme);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        getIntent().setAction("Already created");

        SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(this);
        if (preferences.getBoolean(Globals.PREF_NOT_LOGIN, true)) {

            Intent i = new Intent(MainActivity.this, LoginActivity.class);
            finish();
            startActivity(i);
        }
        else {

            //navbar
            allProducts = (Button) findViewById(R.id.allProducts);
            addProduct = (Button) findViewById(R.id.addProduct);
            logOut = (Button) findViewById(R.id.logOut);

//            allProducts.setOnClickListener(new View.OnClickListener() {
//                @Override
//                public void onClick(View v)
//                {
//                    Intent i = new Intent(MainActivity.this, MainActivity.class);
//                    finish();
//                    startActivity(i);
//                }
//            });
            addProduct.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v)
                {
                    Intent i = new Intent(MainActivity.this, AddProductActivity.class);
                    finish();
                    startActivity(i);
                }
            });
            logOut.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v)
                {
                    SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(MainActivity.this);
                    preferences.edit().putBoolean(Globals.PREF_IS_ADMIN, false ).apply();
                    preferences.edit().putBoolean(Globals.PREF_FIRST_START, true).apply();
                    preferences.edit().putBoolean(Globals.PREF_NOT_LOGIN, true).apply();

                    Intent i = new Intent(MainActivity.this, LoginActivity.class);
                    finish();
                    startActivity(i);
                }
            });
            //---


            rvProducts = (RecyclerView) findViewById(R.id.rvProducts);


            alProducts = new ArrayList<Product>();


            DBHelper db = new DBHelper(this);
            String user_id = preferences.getString(Globals.PREF_USER_ID, "");
            Cursor cursor;
            if (!(preferences.getBoolean(Globals.PREF_IS_ADMIN, false))) {
                cursor = db.retrive_products(user_id);
            }
            else {
                cursor = db.retrive_all_products();
            }
            while (cursor.moveToNext())
            {
                Product p = new Product();
                p.name = cursor.getString(cursor.getColumnIndex(DBHelper.NAME));
                p.id = cursor.getInt(cursor.getColumnIndex(DBHelper.P_ID));
                p.rating = cursor.getDouble(cursor.getColumnIndex(DBHelper.RATING));
                alProducts.add(p);
            }

            rvaStudents = new ProductRVAdapter(this, alProducts);
            rvProducts.setAdapter(rvaStudents);

            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);
            linearLayoutManager.setOrientation(LinearLayoutManager.VERTICAL);


            rvProducts.setLayoutManager(linearLayoutManager);



            if (preferences.getBoolean(Globals.PREF_FIRST_START, true)) {
                //Checking for Permissions
                if (ContextCompat.checkSelfPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED) {
                    ActivityCompat.requestPermissions(this,
                            new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE},
                            Globals.WRITE_EXTERNAL);
                }
                if (ContextCompat.checkSelfPermission(this, Manifest.permission.READ_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED) {
                    ActivityCompat.requestPermissions(this,
                            new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE},
                            Globals.READ_EXTERNAL_IMAGE);
                }
                //Updating Shared Preferences
                preferences.edit().putBoolean(Globals.PREF_FIRST_START, false).apply();
            }

        }
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.main_menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.download:

                //Checking for Permissions
                if (ContextCompat.checkSelfPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED) {
                    ActivityCompat.requestPermissions(this,
                            new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE},
                            Globals.WRITE_EXTERNAL);
                }
                else{
                    download();
                }
            default:
                return super.onOptionsItemSelected(item);
        }
    }


    @Override
    public void onRequestPermissionsResult(int requestCode,
                                           String permissions[], int[] grantResults) {
        switch (requestCode) {
            case Globals.WRITE_EXTERNAL:
                if (grantResults.length > 0) {
                    for (int i = 0; i < grantResults.length; i++) {
                        if (PackageManager.PERMISSION_GRANTED == grantResults[i]) {
                            download();
                        } else {
                            Toast.makeText(MainActivity.this, "Permission denied", Toast.LENGTH_SHORT).show();
                            //onBackPressed();
                        }
                    }
                }
                break;
        }
    }






    public void download(){
        SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(MainActivity.this);
        String user_id = preferences.getString(Globals.PREF_USER_ID, "");
        File sd = Environment.getExternalStorageDirectory();
        String csvFile = user_id+".xls";

        File directory = new File(sd.getAbsolutePath()+ "/My Shopper");
        //create directory if not exist
        if (!directory.isDirectory()) {
            directory.mkdirs();
        }
        try {

            //file path
            File file = new File(directory, csvFile);
            WorkbookSettings wbSettings = new WorkbookSettings();
            wbSettings.setLocale(new Locale("en", "EN"));
            WritableWorkbook workbook;
            workbook = Workbook.createWorkbook(file, wbSettings);
            //Excel sheet name. 0 represents first sheet
            WritableSheet sheet = workbook.createSheet("Product List", 0);
            // column and row
            sheet.addCell(new Label(0, 0, "Name"));
            sheet.addCell(new Label(1, 0, "Price"));
            sheet.addCell(new Label(2, 0, "Quantity"));
            sheet.addCell(new Label(3, 0, "Description"));
            sheet.addCell(new Label(4, 0, "Rating"));
            sheet.addCell(new Label(5, 0, "User Name"));

            DBHelper db = new DBHelper(this);

            Cursor cursor;
            if (!(preferences.getBoolean(Globals.PREF_IS_ADMIN, false))) {
                cursor = db.retrive_products(user_id);
            }
            else {
                cursor = db.retrive_all_products();
            }
            if (cursor.moveToFirst()) {
                do {

                    String name = cursor.getString(cursor.getColumnIndex(DBHelper.NAME));
                    String price = cursor.getString(cursor.getColumnIndex(DBHelper.PRICE));
                    int quantity = cursor.getInt(cursor.getColumnIndex(DBHelper.QUANTITY));
                    String description = cursor.getString(cursor.getColumnIndex(DBHelper.DESCRIPTION));
                    String username = cursor.getString(cursor.getColumnIndex(DBHelper.USER_ID));
                    double rating = cursor.getDouble(cursor.getColumnIndex(DBHelper.RATING));


                    int i = cursor.getPosition() + 1;
                    sheet.addCell(new Label(0, i, name));
                    sheet.addCell(new Label(1, i, price));
                    sheet.addCell(new Label(2, i, String.valueOf(quantity)));
                    sheet.addCell(new Label(3, i, description));
                    sheet.addCell(new Label(4, i, String.valueOf(rating)));
                    sheet.addCell(new Label(5, i, username));
                } while (cursor.moveToNext());
            }

            //closing cursor
            cursor.close();
            workbook.write();
            workbook.close();


            snackview= findViewById(android.R.id.content);
            snackbar = Snackbar.make(snackview, "Data Exported To An Excel File!", Snackbar.LENGTH_LONG)
                    .setAction("Dismiss", new View.OnClickListener() {
                        @Override
                        public void onClick(View view) {
                            snackbar.dismiss();
                        }
                    });
            snackbar.show();

        } catch(Exception e){
            e.printStackTrace();
        }

    }

    @Override
    protected void onResume() {
        Log.v("Example", "onResume");

        String action = getIntent().getAction();
        // Prevent endless loop by adding a unique action, don't restart if action is present
        if(action == null || !action.equals("Already created")) {
            Log.v("Example", "Force restart");
            Intent intent = new Intent(this, MainActivity.class);
            startActivity(intent);
            finish();
        }
        // Remove the unique action so the next time onResume is called it will restart
        else
            getIntent().setAction(null);

        super.onResume();
    }



    boolean check = false;
    @Override
    public void onBackPressed() {
        if(!check){
            Toast.makeText(MainActivity.this, "Press Back again!", Toast.LENGTH_SHORT).show();
            check =true;
        }else {
            super.onBackPressed();
        }
    }




}
