package com.capstone.ca

import android.content.Intent
import android.os.Bundle
import android.os.Handler
import androidx.appcompat.app.AppCompatActivity


class SplashActivity : AppCompatActivity()
{
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.splash_activity)

        object :Handler(){}.postDelayed({
            var intent=Intent(this,MainActivity::class.java)
            startActivity(intent)
            finish()
        },500)
    }







}