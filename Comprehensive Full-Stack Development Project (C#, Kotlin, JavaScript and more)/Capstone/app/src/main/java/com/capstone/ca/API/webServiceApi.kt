package com.capstone.ca.API

import com.capstone.ca.Models.Department
import io.reactivex.Single
import retrofit2.http.GET
import retrofit2.http.Path
import retrofit2.http.Query

interface webServiceApi {

    @GET("departments")
    fun getDepartments(): Single<String>

    @GET("departments/{id}")
    fun getEmployeeByDepartmentsId(
        @Path("id") id: Int
    ): Single<String>

    @GET("searchemployee")
    fun searchEmployeeById(
        @Query("id") id: Int
    ):Single<String>

    @GET("searchemployee")
    fun getAllEmployees(
    ): Single<String>

    @GET("searchemployee")
    fun searchEmployeeByLastName(
        @Query("lastName") lastName: String
    ): Single<String>





}