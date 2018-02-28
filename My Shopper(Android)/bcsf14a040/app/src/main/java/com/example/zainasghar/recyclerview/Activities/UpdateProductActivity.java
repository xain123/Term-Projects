package com.example.zainasghar.recyclerview.Activities;

import android.content.Intent;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.preference.PreferenceManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RatingBar;
import android.widget.Toast;

import com.example.zainasghar.recyclerview.Database.DBHelper;
import com.example.zainasghar.recyclerview.Globals;
import com.example.zainasghar.recyclerview.R;

public class UpdateProductActivity extends AppCompatActivity {


    //navbar
    private Button allProducts;
    private Button addProduct;
    private Button logOut;
    //----

    private EditText name;
    private EditText price;
    private EditText quantity;
    private EditText description;
    private RatingBar rbRating_update;
    private Button btnUpdate;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update_product);


        name = (EditText) findViewById(R.id.name_update);
        price = (EditText) findViewById(R.id.price_update);
        quantity = (EditText) findViewById(R.id.quantity_update);
        description = (EditText) findViewById(R.id.description_update);
        rbRating_update = (RatingBar) findViewById(R.id.rbRating_update);
        btnUpdate = (Button) findViewById(R.id.btnupdate__update);


        Intent i = getIntent();
        final int p_id = i.getIntExtra("id",-1);
        if(p_id != -1)
        {

            DBHelper db = new DBHelper(this);
            Cursor cursor = db.retrive_product_detail(p_id);

            if (cursor.moveToFirst()) // data?
            {
                String dbname = cursor.getString(cursor.getColumnIndex(DBHelper.NAME));
                String dbdescription = cursor.getString(cursor.getColumnIndex(DBHelper.DESCRIPTION));
                int dbprice = cursor.getInt(cursor.getColumnIndex(DBHelper.PRICE));
                int dbquantity = cursor.getInt(cursor.getColumnIndex(DBHelper.QUANTITY));
                float dbrating = cursor.getFloat(cursor.getColumnIndex(DBHelper.RATING));



                name.setText(dbname);
                name.setEnabled(false);
                description.setText(dbdescription);
                price.setText( String.valueOf(dbprice));
                quantity.setText(String.valueOf(dbquantity));
                rbRating_update.setRating(dbrating);

            }
        }


        btnUpdate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                if (name.getText().toString().equals("") || price.getText().toString().equals("")|| quantity.getText().toString().equals("")|| description.getText().toString().equals("") )
                {
                    Toast.makeText(UpdateProductActivity.this, "All Fields Required!", Toast.LENGTH_SHORT).show();
                }
                else
                {
                    String name2 = name.getText().toString();
                    int price2 = Integer.valueOf(price.getText().toString());
                    int quantity2 = Integer.valueOf(quantity.getText().toString());
                    String desc = description.getText().toString();
                    float rating2 = (float) rbRating_update.getRating();

                    SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(UpdateProductActivity.this);
                    String user_id = preferences.getString(Globals.PREF_USER_ID, "");


                    DBHelper db = new DBHelper(UpdateProductActivity.this);
                    //(int id, String name, int price, int quantity, String description, float rating)
                    long check = db.update_product(p_id,name2, price2, quantity2, desc, rating2);
                    if (check > 0) {
                        Toast.makeText(UpdateProductActivity.this, "Product Updated!", Toast.LENGTH_SHORT).show();
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
                Intent i = new Intent(UpdateProductActivity.this, MainActivity.class);
                finish();
                startActivity(i);
            }
        });
        addProduct.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
            {
                Intent i = new Intent(UpdateProductActivity.this, AddProductActivity.class);
                finish();
                startActivity(i);
            }
        });
        logOut.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
            {
                SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(UpdateProductActivity.this);
                preferences.edit().putBoolean(Globals.PREF_IS_ADMIN, false ).apply();

                preferences.edit().putBoolean(Globals.PREF_NOT_LOGIN, true).apply();
                Intent i = new Intent(UpdateProductActivity.this, LoginActivity.class);
                finish();
                startActivity(i);

            }
        });
        //---
    }

    boolean check = false;
    @Override
    public void onBackPressed() {
        if(!check){
            Toast.makeText(UpdateProductActivity.this, "Press Back again!", Toast.LENGTH_SHORT).show();
            check =true;
        }else {
            super.onBackPressed();
        }
    }
}
