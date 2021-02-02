package com.capstone.ca.Models

import com.google.gson.annotations.Expose
import com.google.gson.annotations.SerializedName

class Employee
{
    @SerializedName("Errors")
    @Expose
    private var errors: List<String?>? = null

    @SerializedName("ID")
    @Expose
    private var iD: Int? = null

    @SerializedName("Name")
    @Expose
    private var Name: String? = null

    @SerializedName("JobName")
    @Expose
    private var JobName: String? = null

    @SerializedName("DepartmentsName")
    @Expose
    private var DepartmentsName: String? = null

    @SerializedName("OfficeLocation")
    @Expose
    private var OfficeLocation: String? = null

    @SerializedName("CellPhone")
    @Expose
    private var cellPhone: String? = null

    @SerializedName("Email")
    @Expose
    private var email: String? = null


    fun getID(): Int? {
        return iD
    }

    fun setID(iD: Int?) {
        this.iD = iD
    }

    fun getName(): String? {
        return Name
    }

    fun setName(fName: String?) {
        this.Name = fName
    }


    fun getDepartmentName(): String? {
        return DepartmentsName
    }

    fun getJobName(): String? {
        return JobName
    }



    fun getOfficeLocation(): String? {
        return OfficeLocation
    }


    fun getCellPhoneNumber(): String? {
        return cellPhone
    }


    fun getEmail(): String? {
        return email
    }

}