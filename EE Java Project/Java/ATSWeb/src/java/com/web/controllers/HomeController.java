/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.web.controllers;

import com.alpha.models.GetTeamsDto;
import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import com.alpha.service.HomeService;
import java.util.List;
import java.util.Map;

/**
 *
 * @author MSI
 */
public class HomeController extends CommonController {

    private HomeService homeService = new HomeService();

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        Map<String, List<Double>> data = homeService.GetDataForCurrentAndPrevYear();
        
        GetTeamsDto onCallTeam = homeService.getOnCallTeam();
        request.setAttribute("onCallTeam", onCallTeam);
        
        int todaysJobsCount = homeService.currentDayCountOfJobs();
        request.setAttribute("todaysJobsCount", todaysJobsCount);

        // making string representation of arrays to display in months graph
        String CurrentYearRevenue = "[";
        for (Double object : data.get("CurrentYearRevenue")) {
            CurrentYearRevenue += object.toString() + ",";
        }
        CurrentYearRevenue += "]";
        request.setAttribute("CurrentYearRevenue", CurrentYearRevenue);

        String PrevYearRevenue = "[";
        for (Double object : data.get("PrevYearRevenue")) {
            PrevYearRevenue += object.toString() + ",";
        }
        PrevYearRevenue += "]";
        request.setAttribute("PrevYearRevenue", PrevYearRevenue);

        // counting current and previous year Revenue and cost
        Double PrevYearSum = 0.0;
        for (Double object : data.get("PrevYearRevenue")) {
            PrevYearSum += object;
        }
        request.setAttribute("PrevYearSumRev", PrevYearSum);

        Double CurrYearSumRev = 0.0;
        for (Double object : data.get("CurrentYearRevenue")) {
            CurrYearSumRev += object;
        }
        request.setAttribute("CurrYearSumRev", CurrYearSumRev);

        Double PrevYearCost = 0.0;
        for (Double object : data.get("PrevYearCost")) {
            PrevYearCost += object;
        }
        request.setAttribute("PrevYearCost", PrevYearCost);

        Double CurrYearSumCost = 0.0;
        for (Double object : data.get("CurrentYearCost")) {
            CurrYearSumCost += object;
        }
        request.setAttribute("CurrYearSumCost", CurrYearSumCost);

        super.setView(request, "/index.jsp");
        super.getView().forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

    }

}
