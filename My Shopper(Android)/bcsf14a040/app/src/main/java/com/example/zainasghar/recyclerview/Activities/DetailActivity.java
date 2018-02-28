package com.example.zainasghar.recyclerview.Activities;

import android.Manifest;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Environment;
import android.preference.PreferenceManager;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.RatingBar;
import android.widget.TextView;
import android.widget.Toast;

import com.example.zainasghar.recyclerview.Database.DBHelper;
import com.example.zainasghar.recyclerview.Globals;
import com.example.zainasghar.recyclerview.R;

public class DetailActivity extends AppCompatActivity {

    //navbar
    private Button allProducts;
    private Button addProduct;
    private Button logOut;
    //----


    private TextView tvName_detail;
    private TextView tvprice_detail;
    private TextView tvquantity_detail;
    private RatingBar rbRating_detail;
    private TextView tvdescription_detail;
    private ImageView delete_detail;
    private ImageView ivDP_detail;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_detail);

        Intent i = getIntent();
        final int p_id = i.getIntExtra("id",-1);
        if(p_id != -1)
        {
            //Toast.makeText(this, "Product !" + String.valueOf(p_id), Toast.LENGTH_SHORT).show();
            tvName_detail = (TextView) findViewById(R.id.tvName_detail);
            tvprice_detail = (TextView) findViewById(R.id.tvprice_detail);
            tvquantity_detail = (TextView) findViewById(R.id.tvquantity_detail);
            tvdescription_detail = (TextView) findViewById(R.id.tvdescription_detail);
            rbRating_detail = (RatingBar) findViewById(R.id.rbRating_detail);
            delete_detail = (ImageView) findViewById(R.id.delete_detail);
            ivDP_detail = (ImageView) findViewById(R.id.ivDP_detail);

            DBHelper db = new DBHelper(this);
            Cursor cursor = db.retrive_product_detail(p_id);

            if (cursor.moveToFirst()) // data?
            {
                String dbname = cursor.getString(cursor.getColumnIndex(DBHelper.NAME));
                String dbdescription = cursor.getString(cursor.getColumnIndex(DBHelper.DESCRIPTION));
                int dbprice = cursor.getInt(cursor.getColumnIndex(DBHelper.PRICE));
                int dbquantity = cursor.getInt(cursor.getColumnIndex(DBHelper.QUANTITY));
                float dbrating = cursor.getFloat(cursor.getColumnIndex(DBHelper.RATING));

                tvName_detail.setText("Name: " + dbname);
                tvprice_detail.setText("Price: " +String.valueOf(dbprice));
                tvquantity_detail.setText("Quantity: " +String.valueOf(dbquantity));
                tvdescription_detail.setText("Description: " +dbdescription);
                rbRating_detail.setRating(dbrating);



                try {


                    if (ContextCompat.checkSelfPermission(DetailActivity.this, Manifest.permission.READ_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED) {
//            ActivityCompat.requestPermissions(context,
//                    new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE},
//                    Globals.WRITE_EXTERNAL);

                        Toast.makeText(DetailActivity.this, "Give Storage Permissions to See Pictures!", Toast.LENGTH_SHORT).show();


                    } else {


                        //Reading image
                        //get frame path
                        String photoPath = Environment.getExternalStorageDirectory() + "/" + Globals.IMAGE_FOLDER + "/" + dbname + ".png";

                        //get bitmap frame
                        BitmapFactory.Options options = new BitmapFactory.Options();
                        options.inPreferredConfig = Bitmap.Config.ARGB_8888;
                        Bitmap bmp = BitmapFactory.decodeFile(photoPath, options);

                        ivDP_detail.setImageBitmap(bmp);
                        //Reading Image
                    }
                }
                catch (Exception e)
                {
                    e.printStackTrace();
                }




                rbRating_detail.setOnRatingBarChangeListener(new RatingBar.OnRatingBarChangeListener() {
                    @Override
                    public void onRatingChanged(RatingBar ratingBar, float rating, boolean fromUser) {

                        DBHelper db = new DBHelper(DetailActivity.this);
                        long check = db.update_rating(p_id,rating);
                        if(check >0){
                            Toast.makeText(DetailActivity.this, "Rating Updated!", Toast.LENGTH_SHORT).show();

                        }
                    }
                });

                delete_detail.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {

                        AlertDialog.Builder alert = new AlertDialog.Builder(DetailActivity.this);
                        //alert.setIcon();
                        alert.setTitle("Delete Product");
                        alert.setMessage("Are You Sure you Want to Delete?");
                        alert.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                DBHelper db = new DBHelper(DetailActivity.this);
                                long check = db.delete_product(p_id);
                                if(check > 0) {
                                    Toast.makeText(DetailActivity.this, "Removed! " , Toast.LENGTH_SHORT).show();
                                    finish();

                                }
                                else {
                                    Toast.makeText(DetailActivity.this, "Can't Remove! " + String.valueOf(p_id), Toast.LENGTH_SHORT).show();

                                }
                            }
                        });
                        alert.setNegativeButton("No", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                dialog.cancel();
                            }
                        });
                        alert.show();
                    }
                });



            }
        }



        //navbar
        allProducts = (Button) findViewById(R.id.allProducts);
        addProduct = (Button) findViewById(R.id.addProduct);
        logOut = (Button) findViewById(R.id.logOut);

            allProducts.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v)
                {
                    Intent i = new Intent(DetailActivity.this, MainActivity.class);
                    finish();
                    startActivity(i);
                }
            });
        addProduct.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
            {
                Intent i = new Intent(DetailActivity.this, AddProductActivity.class);
                finish();
                startActivity(i);
            }
        });
        logOut.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
            {
                SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(DetailActivity.this);
                preferences.edit().putBoolean(Globals.PREF_IS_ADMIN, false ).apply();

                preferences.edit().putBoolean(Globals.PREF_NOT_LOGIN, true).apply();
                Intent i = new Intent(DetailActivity.this, LoginActivity.class);
                finish();
                startActivity(i);
            }
        });
        //---
    }
}
