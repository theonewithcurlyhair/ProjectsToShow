package com.capstone.ca.Models

import com.google.gson.annotations.Expose
import com.google.gson.annotations.SerializedName

class Department {
    @SerializedName("Errors")
    @Expose
    private var errors: List<Any?>? = null

    @SerializedName("DepartmentID")
    @Expose
    private var departmentID: Int? = null

    @SerializedName("Name")
    @Expose
    private var name: String? = null

    @SerializedName("Description")
    @Expose
    private var description: Any? = null

//    @SerializedName("InvocDate")
//    @Expose
//    private var invocDate: String? = null
//
//    @SerializedName("TimeStamp")
//    @Expose
//    private var timeStamp: Any? = null

    @SerializedName("Error")
    @Expose
    private var error: Any? = null

    fun getErrors(): List<Any?>? {
        return errors
    }

    fun setErrors(errors: List<Any?>?) {
        this.errors = errors
    }

    fun getDepartmentID(): Int? {
        return departmentID
    }

    fun setDepartmentID(departmentID: Int?) {
        this.departmentID = departmentID
    }

    fun getName(): String? {
        return name
    }

    fun setName(name: String?) {
        this.name = name
    }

    fun getDescription(): Any? {
        return description
    }

    fun setDescription(description: Any?) {
        this.description = description
    }

//    fun getInvocDate(): String? {
//        return invocDate
//    }
//
//    fun setInvocDate(invocDate: String?) {
//        this.invocDate = invocDate
//    }
//
//    fun getTimeStamp(): Any? {
//        return timeStamp
//    }
//
//    fun setTimeStamp(timeStamp: Any?) {
//        this.timeStamp = timeStamp
//    }

    fun getError(): Any? {
        return error
    }

    fun setError(error: Any?) {
        this.error = error
    }

}