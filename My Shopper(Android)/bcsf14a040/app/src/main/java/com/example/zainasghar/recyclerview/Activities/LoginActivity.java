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
import android.widget.TextView;
import android.widget.Toast;
import android.support.design.widget.Snackbar;

import com.example.zainasghar.recyclerview.Database.DBHelper;
import com.example.zainasghar.recyclerview.Globals;
import com.example.zainasghar.recyclerview.R;

public class LoginActivity extends AppCompatActivity {
    private EditText login_userid;
    private EditText login_password;
    private TextView incorect_attampt_view;
    private Button login_btn;
    private Button login_registerbtn;
    private int counter = 5;
    private View snackview;
    private Snackbar snackbar;
    @Override
    protected void onCreate(Bundle savedInstanceState) {

        setTheme(R.style.AppTheme);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        login_userid = (EditText) findViewById(R.id.login_userid);
        login_password = (EditText) findViewById(R.id.login_password);
        incorect_attampt_view = (TextView) findViewById(R.id.incorect_attampt_view);
        login_btn = (Button) findViewById(R.id.login_btn);
        login_registerbtn = (Button) findViewById(R.id.login_registerbtn);

        login_password.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                login_password.setBackgroundColor(0xFFFFFFFF);
            }
        });
        login_userid.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                login_userid.setBackgroundColor(0xFFFFFFFF);
            }
        });



        login_registerbtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(LoginActivity.this, SginupActivity.class);
                finish();
                startActivity(i);
            }
        });

        login_btn.setOnClickListener(new View.OnClickListener()
        {

            @Override
            public void onClick(View v) {
                String userid = login_userid.getText().toString();
                String pass = login_password.getText().toString();
                if (userid.equals("")) {
                    login_userid.setBackgroundColor(0xFFFF4545);
                }
                else {
                    login_userid.setBackgroundColor(0xFFFFFFFF);
                }
                if (pass.equals("")) {
                    login_password.setBackgroundColor(0xFFFF4545);
                }
                else {
                    login_password.setBackgroundColor(0xFFFFFFFF);

                }
                if (pass.equals("") && userid.equals("")) {
                    int a=0;
                } else {
                    validate(login_userid.getText().toString(), login_password.getText().toString());
                }
            }
        });

    }

    private void validate(String userId, String password)
    {
        DBHelper db = new DBHelper(LoginActivity.this);
        Cursor cursor = db.check_user(userId);

        if (cursor.moveToFirst()) // data?
        {
            String dbUserid = cursor.getString(cursor.getColumnIndex(DBHelper.U_ID));
            String dbPassword = cursor.getString(cursor.getColumnIndex(DBHelper.PASSWORD));

            if((userId.equals(dbUserid)) && (password.equals(dbPassword)))
            {
                SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(this);

                if(dbUserid.equals("Admin"))
                {
                    preferences.edit().putBoolean(Globals.PREF_IS_ADMIN, true ).commit();

                }

                preferences.edit().putBoolean(Globals.PREF_NOT_LOGIN, false).apply();
                preferences.edit().putString(Globals.PREF_USER_ID, dbUserid).apply();
                Intent i = new Intent(LoginActivity.this, MainActivity.class);
                finish();
                startActivity(i);
            }
            else
            {
                Toast.makeText(LoginActivity.this, "Incorect Password!", Toast.LENGTH_SHORT).show();
                counter --;
                incorect_attampt_view.setText("No of Attempts Remaining: " + String.valueOf(counter));
                if(counter == 0 ){



                    snackview= findViewById(android.R.id.content);
                    snackbar = Snackbar.make(snackview, "Login Blocked!", Snackbar.LENGTH_LONG)
                            .setAction("Dismiss", new View.OnClickListener() {
                                @Override
                                public void onClick(View view) {
                                    snackbar.dismiss();
                                }
                            });
                    snackbar.show();
                    login_btn.setEnabled(false);
                    login_btn.setBackgroundColor(0xFFFF4545);
                    login_userid.setEnabled(false);
                    login_password.setEnabled(false);
                    incorect_attampt_view.setText("Login Blocked! ");
                    //Snackbar snackbar1 = Snackbar.make(coordinatorLayout, "Message is restored!", Snackbar.LENGTH_SHORT);
                    //snackbar1.show();
                }
            }
        }
        else
        {
            Toast.makeText(LoginActivity.this, "Register First!", Toast.LENGTH_SHORT).show();
            counter --;
            incorect_attampt_view.setText("No of Attempts Remaining: " + String.valueOf(counter));
            if(counter == 0 ){

                snackview= findViewById(android.R.id.content);
                snackbar = Snackbar.make(snackview, "Login Blocked!", Snackbar.LENGTH_LONG)
                        .setAction("Dismiss", new View.OnClickListener() {
                            @Override
                            public void onClick(View view) {
                                snackbar.dismiss();
                            }
                        });
                snackbar.show();
                login_btn.setEnabled(false);
                login_btn.setBackgroundColor(0xFFFF4545);
                login_userid.setEnabled(false);
                login_password.setEnabled(false);
                incorect_attampt_view.setText("Login Blocked! ");
                //Snackbar snackbar1 = Snackbar.make(coordinatorLayout, "Message is restored!", Snackbar.LENGTH_SHORT);
                //snackbar1.show();
            }
        }
    }

    boolean check = false;
    @Override
    public void onBackPressed() {
        if(!check){
            Toast.makeText(LoginActivity.this, "Press Back again!", Toast.LENGTH_SHORT).show();
            check =true;
        }else {
            super.onBackPressed();
        }
    }
}
