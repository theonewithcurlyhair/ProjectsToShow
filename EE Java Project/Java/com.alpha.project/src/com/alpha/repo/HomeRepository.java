/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alpha.repo;

import com.alpha.dataaccess.DAL;
import com.alpha.dataaccess.DALFactory;
import com.alpha.dataaccess.IDAL;
import com.alpha.dataaccess.IParameter;
import com.alpha.dataaccess.ParameterFactory;
import com.alpha.models.Employee;
import com.alpha.models.GetTeamsDto;
import com.alpha.models.IEmployee;
import com.alpha.models.IGetTeamsDto;
import com.alpha.models.ITeam;
import com.alpha.models.Team;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import javax.sql.rowset.CachedRowSet;
import org.joda.time.*;
import com.alpha.models.GetTeamsDto;
import java.sql.ResultSetMetaData;

/**
 *
 * @author MSI
 */
public class HomeRepository extends BaseRepository {

    private DAL dal = new DAL();

    public GetTeamsDto getOnCallTeam() {
        GetTeamsDto onCallTeam = new GetTeamsDto();

        ITeam getTeam = new Team();

        List<IEmployee> getTeamsEmployee = new ArrayList<>();

        IEmployee emp = new Employee();

        try {

            CachedRowSet rowSet = dal.executeFill("{call sp_getOnCallTeam()}", null);

            while (rowSet.next()) {
                emp.setFirstName(rowSet.getString("FirstName"));
                emp.setLastName(rowSet.getString("LastName"));
                getTeamsEmployee.add(emp);

                getTeam.setName(rowSet.getString("Name"));
            }

        } catch (Exception e) {
            System.out.print(e.getMessage());
        }

        onCallTeam.setTeam(getTeam);
        onCallTeam.setTeamEmployees(getTeamsEmployee);

        return onCallTeam;
    }

    public int currentDayCountOfJobs() {
        int count = 0;

        try {
            CachedRowSet rowSet = dal.executeFill("call sp_currentDateCountJobs()", null);
            if (rowSet != null) {
                while (rowSet.next()) {
                    count = rowSet.getInt("jobsNumber");
                }
            } else {
                count = 0;
            }

        } catch (Exception e) {
            System.out.print(e.getMessage());
        }

        return count;
    }

    public Map<String, List<Double>> retrieveDataForCalendar() {
        // GETTING todays date
        LocalDate localDate = new LocalDate();
        List<Double> monthRevenueCurrYear = new ArrayList<>();
        List<Double> monthRevenuePrevYear = new ArrayList<>();
        List<Double> monthCostCurrYear = new ArrayList<>();
        List<Double> monthCostPrevYear = new ArrayList<>();
        Map<String, List<Double>> dataForAnalysis = new HashMap<>();

        try {
            // This absolutely can be optimized using SQL and retrieving complex agregation table 
            for (int i = 1; i <= 12; i++) {
                List<IParameter> params = ParameterFactory.createListInstance();

                params.add(ParameterFactory.createInstance(localDate.getYear()));
                params.add(ParameterFactory.createInstance(i));

                CachedRowSet rowSet = dal.executeFill("call sp_getRevenueForMonth(?,?)", params);

                if (rowSet != null) {
                    while (rowSet.next()) {
                        

                        monthRevenueCurrYear.add(rowSet.getDouble("revenue"));


                        monthCostCurrYear.add(rowSet.getDouble("cost"));

                    }
                } else {
                    monthRevenueCurrYear.add(0.0);
                    monthCostCurrYear.add(0.0);
                }

                // doing the same thing for previous year
                params = ParameterFactory.createListInstance();

                params.add(ParameterFactory.createInstance(localDate.getYear() - 1));
                params.add(ParameterFactory.createInstance(i));

                rowSet = dal.executeFill("call sp_getRevenueForMonth(?,?)", params);

                if (rowSet != null) {
                    while (rowSet.next()) {


                        monthRevenuePrevYear.add(rowSet.getDouble("revenue"));

                        monthCostPrevYear.add(rowSet.getDouble("cost"));
                    }
                } else {
                    monthRevenuePrevYear.add(0.0);
                    monthCostPrevYear.add(0.0);
                }

            }

            dataForAnalysis.put("CurrentYearRevenue", monthRevenueCurrYear);
            dataForAnalysis.put("CurrentYearCost", monthCostCurrYear);
            dataForAnalysis.put("PrevYearRevenue", monthRevenuePrevYear);
            dataForAnalysis.put("PrevYearCost", monthCostPrevYear);

        } catch (Exception e) {
            System.out.print(e.getMessage());
        }
        return dataForAnalysis;
    }
}
