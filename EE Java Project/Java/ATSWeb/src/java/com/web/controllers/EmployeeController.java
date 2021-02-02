/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.web.controllers;

import com.alpha.models.EmployeeFactory;
import com.alpha.models.GetEmployeeDetailDtoFactory;
import com.alpha.models.IEmployee;
import com.alpha.models.IGetEmployeeDetailDto;
import com.alpha.models.ITask;
import com.alpha.models.TaskFactory;
import com.alpha.service.EmployeeServiceFactory;
import com.alpha.service.IEmployeeService;
import com.alpha.service.TaskService;
import com.web.models.EmployeeViewModel;
import com.web.models.ErrorViewModel;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author MSI
 */
public class EmployeeController extends CommonController {

    private static final String EMPLOYEES_VIEW = "/employees.jsp";
    private static final String EMPLOYEE_MAINT_VIEW = "/employee.jsp";

    private static final IEmployeeService empserv = EmployeeServiceFactory.createInstance();
    private TaskService taskService = new TaskService();

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        String pathInfo = request.getPathInfo();//gets the url  
        IEmployee emp = EmployeeFactory.createInstance();

        EmployeeViewModel vm = null;
        if (pathInfo != null) {
            String[] pathParts = pathInfo.split("/");

            int id = super.getInteger(pathParts[1]);

            List<ITask> allSkills = TaskFactory.createListInstance();
            allSkills = taskService.getTasks();

            if (id != 0) {
                IGetEmployeeDetailDto queriedEmp = empserv.retrieveEmployee(id);

                if (queriedEmp.getEmployee() != null) {
                    vm = new EmployeeViewModel(queriedEmp);
                    vm.setTasks(allSkills);
                    request.setAttribute("vm", vm);
                    super.setView(request, EMPLOYEE_MAINT_VIEW);
                } else {
                    super.setView(request, "/404");
                }

            } else {
                request.setAttribute("allSkills", taskService.getTasks());
                super.setView(request, EMPLOYEE_MAINT_VIEW);
            }
        } else {
//             creating list of employees and send them to the frontend
            List<IEmployee> employees = EmployeeFactory.createListInstance();
            employees = empserv.retrieveEmployees();
            request.setAttribute("employees", employees);
            super.setView(request, EMPLOYEES_VIEW);
        }
        super.getView().forward(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        super.setView(request, EMPLOYEE_MAINT_VIEW);
        //Invoice service instance

        try {
            String action = super.getValue(request, "action");
            Integer returnId = 0;
            IEmployee emp = null;
            IGetEmployeeDetailDto empDTO = GetEmployeeDetailDtoFactory.createInstance();

            switch (action.toLowerCase()) {
                case "create":
                    emp = EmployeeFactory.createInstance(
                            super.getValue(request, "firstName"),
                            super.getValue(request, "lastName"),
                            super.getValue(request, "Sin"),
                            super.getInteger(request, "hourlyRate")
                    );
                    empDTO.setEmployee(emp);
                    if (request.getParameterValues("skills") != null) {
                        empDTO.setEmployeeSkills(getSkills(request.getParameterValues("skills")));
                    }

                    returnId = empserv.insertEmployee(empDTO);
                    if (returnId >= 0) {
                        response.sendRedirect("/ATSWeb/employees");
                        return;
                    }
                    break;
                case "update":
                    emp = EmployeeFactory.createInstance(
                            super.getValue(request, "firstName"),
                            super.getValue(request, "lastName"),
                            super.getValue(request, "Sin"),
                            super.getDouble(request, "hourlyRate")
                    );
                    emp.setId(super.getInteger(request, "id"));

                    empDTO.setEmployee(emp);
                    if (request.getParameterValues("skills") != null) {
                        empDTO.setEmployeeSkills(getSkills(request.getParameterValues("skills")));
                    }

                    int isUpdated = empserv.updateEmployee(empDTO);

                    if (isUpdated > 0) {
                        response.sendRedirect("/ATSWeb/employees");
                        return;
                    }
                    break;
                case "delete":
                    int id = super.getInteger(request, "id");

                    returnId = empserv.deleteEmployee(id);

                    if (returnId > 0) {
                        response.sendRedirect("/ATSWeb/employees");
                        return;
                    }
                    break;

                case "search":
                    List<IEmployee> employees = EmployeeFactory.createListInstance();
                    String search = super.getValue(request, "searchInput");

                    employees = empserv.searchforEmployee(search);
                    request.setAttribute("employees", employees);
                    super.setView(request, EMPLOYEES_VIEW);
            }
        } catch (Exception e) {
            super.setView(request, EMPLOYEE_MAINT_VIEW);
            request.setAttribute("error", new ErrorViewModel(e.getMessage() + "</br>" + e.getStackTrace()));
        }

        super.getView().forward(request, response);

    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

    private List<ITask> getSkills(String[] skills) {
        List<ITask> sk = new ArrayList<>();
        ITask empSkill = null;
        for (String skill : skills) {
            empSkill = TaskFactory.createInstance();
            int id = Integer.parseInt(skill);
            empSkill.setId(id);
            sk.add(empSkill);
        }

        return sk;
    }

}
