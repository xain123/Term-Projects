package com.example.zainasghar.recyclerview.Activities;

import android.content.Intent;
import android.database.Cursor;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.zainasghar.recyclerview.Database.DBHelper;
import com.example.zainasghar.recyclerview.R;

public class SginupActivity extends AppCompatActivity {

    private EditText signup_userid;
    private EditText signup_password;
    private Button signup_btn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sgin_up);

        signup_userid = (EditText) findViewById(R.id.signup_userid);
        signup_password = (EditText) findViewById(R.id.signup_password);
        signup_btn = (Button) findViewById(R.id.signup_btn);

        signup_userid.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                signup_userid.setBackgroundColor(0xFFFFFFFF);

            }
        });
        signup_password.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                signup_password.setBackgroundColor(0xFFFFFFFF);

            }
        });

        signup_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String userid = signup_userid.getText().toString();
                String pass = signup_password.getText().toString();
                if (userid.equals("")) {
                    signup_userid.setBackgroundColor(0xFFFF4545);
                }
                else {
                    signup_userid.setBackgroundColor(0xFFFFFFFF);
                }
                if (pass.equals("")) {
                    signup_password.setBackgroundColor(0xFFFF4545);
                }
                else {
                    signup_password.setBackgroundColor(0xFFFFFFFF);

                }
                if (pass.equals("") && userid.equals("")) {
                    int a=0;
                } else {
                    DBHelper db = new DBHelper(SginupActivity.this);
                    Cursor cursor = db.check_user(userid);

                    if (cursor.moveToFirst()) // data?
                    {
                        Toast.makeText(SginupActivity.this, "User ID Not Available!", Toast.LENGTH_SHORT).show();
                        cursor.close(); // that's important too, otherwise you're gonna leak cursors
                    }
                    else{
                        register(userid, pass);
                    }
                }
            }
        });


    }

    private void register(String userId, String password) {


        DBHelper db = new DBHelper(SginupActivity.this);
        long check = db.register_user(userId, password);
        if(check >0 ) {

            Toast.makeText(SginupActivity.this, "Registered!", Toast.LENGTH_SHORT).show();

            Intent i = new Intent(SginupActivity.this, LoginActivity.class);
            finish();
            startActivity(i);
        }
        else {
            Toast.makeText(SginupActivity.this, "Unable to Register!", Toast.LENGTH_SHORT).show();
        }
    }

    boolean check = false;
    @Override
    public void onBackPressed() {
        if(!check){
            Toast.makeText(SginupActivity.this, "Press Back again!", Toast.LENGTH_SHORT).show();
            check =true;
        }else {
            super.onBackPressed();
        }
    }

}
