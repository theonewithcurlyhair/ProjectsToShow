package com.capstone.ca.Models

import com.google.gson.annotations.Expose
import com.google.gson.annotations.SerializedName

data class Job (@SerializedName("ID")
                @Expose
                var ID:Int,
                @SerializedName("Name")
                @Expose
                var Name:String,
                @SerializedName("TimeStamp")
                @Expose
                var TimeStamp:Byte)
{

}