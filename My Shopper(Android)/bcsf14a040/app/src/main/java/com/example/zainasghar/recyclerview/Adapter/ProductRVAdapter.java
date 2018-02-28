package com.example.zainasghar.recyclerview.Adapter;

import android.Manifest;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Environment;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AlertDialog;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.RatingBar;
import android.widget.TextView;
import android.widget.Toast;

import com.example.zainasghar.recyclerview.Activities.DetailActivity;
import com.example.zainasghar.recyclerview.Activities.LoginActivity;
import com.example.zainasghar.recyclerview.Activities.UpdateProductActivity;
import com.example.zainasghar.recyclerview.Database.DBHelper;
import com.example.zainasghar.recyclerview.Globals;
import com.example.zainasghar.recyclerview.Models.Product;
import com.example.zainasghar.recyclerview.R;

import java.util.ArrayList;

/**
 * Created by Zain Asghar on 11/24/2017.
 */
public class ProductRVAdapter extends RecyclerView.Adapter<ProductRVAdapter.ProductRVViewHolder> {
    private Context context;
    private ArrayList<Product> alProducts;
    private LayoutInflater layoutInflater;

    public ProductRVAdapter(Context context, ArrayList<Product> alProducts)
    {
        this.context = context;
        this.alProducts = alProducts;
        this.layoutInflater = LayoutInflater.from(this.context);
    }

    @Override
    public ProductRVViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        Log.i("MainActivity1", "onCreate");
        View itemView = layoutInflater.inflate(R.layout.product_list_item, parent, false);
        ProductRVViewHolder studentRVViewHolder = new ProductRVViewHolder(itemView);
        return studentRVViewHolder;
    }

    @Override
    public void onBindViewHolder(ProductRVViewHolder holder, final int position) {
        Log.i("MainActivity1", "onBind");


        try {


            if (ContextCompat.checkSelfPermission(context, Manifest.permission.READ_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED) {
//            ActivityCompat.requestPermissions(context,
//                    new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE},
//                    Globals.WRITE_EXTERNAL);

                Toast.makeText(context, "Give Storage Permissions to See Pictures!", Toast.LENGTH_SHORT).show();


            } else {


                //Reading image
                //get frame path
                String photoPath = Environment.getExternalStorageDirectory() + "/" + Globals.IMAGE_FOLDER + "/" + alProducts.get(position).name + ".png";

                //get bitmap frame
                BitmapFactory.Options options = new BitmapFactory.Options();
                options.inPreferredConfig = Bitmap.Config.ARGB_8888;
                Bitmap bmp = BitmapFactory.decodeFile(photoPath, options);

                holder.ivDP.setImageBitmap(bmp);
                //Reading Image
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

        holder.tvName.setText(alProducts.get(position).name);
        holder.rbRating.setRating((float) alProducts.get(position).rating);



        holder.ivDP.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i =new Intent(context, DetailActivity.class);
                Product p = alProducts.get(position);
                i.putExtra("id", p.id);
                context.startActivity(i);

            }
        });

        holder.update.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i =new Intent(context, UpdateProductActivity.class);
                Product p = alProducts.get(position);
                i.putExtra("id", p.id);
                context.startActivity(i);

            }
        });

        holder.rbRating.setOnRatingBarChangeListener(new RatingBar.OnRatingBarChangeListener() {
            @Override
            public void onRatingChanged(RatingBar ratingBar, float rating, boolean fromUser) {
                Product p = alProducts.get(position);
                DBHelper db = new DBHelper(context);
                long check = db.update_rating(p.id,rating);
                if(check >0){
                    Toast.makeText(context, "Rating Updated!", Toast.LENGTH_SHORT).show();

                }
            }
        });

        holder.delete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                AlertDialog.Builder alert = new AlertDialog.Builder(context);
                //alert.setIcon();
                alert.setTitle("Delete Product");
                alert.setMessage("Are You Sure you Want to Delete?");
                alert.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        removeItem(alProducts.get(position), position);
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


    public void insertItem(int position, Product student)
    {

        alProducts.add(position,student);
        notifyItemInserted(position);
    }

    public void removeItem (Product product, int position) {

        DBHelper db = new DBHelper(context);
        long check = db.delete_product(product.id);
        if(check > 0) {
            Toast.makeText(context, "Removed! " , Toast.LENGTH_SHORT).show();
            alProducts.remove(product);
            notifyItemRemoved(position);
            notifyItemRangeChanged(position, getItemCount());
        }
        else {
            Toast.makeText(context, "Can't Remove! " + String.valueOf(product.id), Toast.LENGTH_SHORT).show();

        }

    }

    @Override
    public int getItemCount() {
        return alProducts.size();
    }


    public class ProductRVViewHolder extends RecyclerView.ViewHolder
    {
        private TextView tvName;
        private RatingBar rbRating;
        private ImageView ivDP;
        private ImageView delete;
        private ImageView update;

        public ProductRVViewHolder(View itemView) {
            super(itemView);

            tvName = (TextView) itemView.findViewById(R.id.tvName);
            rbRating = (RatingBar) itemView.findViewById(R.id.rbRating);
            ivDP = (ImageView) itemView.findViewById(R.id.ivDP);
            delete = (ImageView) itemView.findViewById(R.id.delete);
            update = (ImageView) itemView.findViewById(R.id.update);


        }
    }

}

