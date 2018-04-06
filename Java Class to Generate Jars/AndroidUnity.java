package com.bugdev.asus.app_2;

import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.util.Log;
import android.widget.Toast;
import android.content.Context;
/**
 * Created by ASUS on 2/7/2018.
 */

public class AndroidUnity {

    private Context context;
    public static AndroidUnity instance;

    public AndroidUnity()
    {
        instance = this;
    }

    public static AndroidUnity instance() {
        if (instance == null) {
            instance = new AndroidUnity();
        }
        return instance;
    }

    public void setContext(Context context) {
        this.context = context;
    }

    public void ShowToast(String message) {
        Toast.makeText(context, message, Toast.LENGTH_LONG).show();
    }

    public String ReadData(String packageName) {

        String my_data = "";
        try {
            Context con = context.createPackageContext(packageName, 0);//first app package name is "com.sharedpref1"
            SharedPreferences pref = con.getSharedPreferences(
                    "sharedpref", Context.MODE_PRIVATE);
            my_data = pref.getString("sharedstring", "No Value");
        }
        catch (PackageManager.NameNotFoundException e) {
            Log.e("Not data shared", e.toString());
        }

        return my_data;
    }

    public String WriteData(String dataToSave) {
        SharedPreferences prefs = context.getSharedPreferences("sharedpref",
                Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = prefs.edit();
        editor.putString("sharedstring", dataToSave);
        editor.commit();
        Toast.makeText(context, dataToSave, Toast.LENGTH_LONG).show();
        return  dataToSave;
    }
}
