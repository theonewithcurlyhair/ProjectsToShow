/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.web.controllers;

import com.alpha.models.Employee;
import com.alpha.models.EmployeeFactory;
import com.alpha.models.IEmployee;
import com.alpha.models.IGetTeamsDto;
import com.alpha.models.Team;
import com.alpha.service.EmployeeService;
import com.alpha.service.IEmployeeService;
import com.alpha.service.ITeamService;
import com.alpha.service.TeamService;
import com.web.models.ErrorViewModel;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author Nik
 */
public class TeamController extends CommonController {

    private static final String TEAMS_VIEW = "/teams.jsp";
    private static final String TEAMS_MAINT_VIEW = "/team.jsp";
    private static final String TEAM_SUMMARY_VIEW = "/teamsummary.jsp";
    private ITeamService teamService = new TeamService();
    private IEmployeeService employeeService = new EmployeeService();

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try {
            String pathInfo = request.getPathInfo();//gets the url  
            if (pathInfo != null) {
                //Populate drop down with employees
                //If no employees added yet return Error VM
                String[] pathParts = pathInfo.split("/");

                int id = super.getInteger(pathParts[1]);

                if (id != 0) {

                } else {
                    List<IEmployee> emps = employeeService.retrieveEmployees();
                    if (emps.size() == 0) {
                        request.setAttribute("error", new ErrorViewModel("No Employees Added Yet"));
                    } else {
                        request.setAttribute("emps", employeeService.retrieveEmployees());
                    }
                    super.setView(request, TEAMS_MAINT_VIEW);
                }

            } else {
                List<IGetTeamsDto> vm = teamService.getTeams();
                request.setAttribute("vm", vm);
                super.setView(request, TEAMS_VIEW);
            }

        } catch (Exception e) {
            super.setView(request, TEAMS_MAINT_VIEW);
            request.setAttribute("error", new ErrorViewModel("An error occurred attempting to maintain teams"));
        }

        super.getView().forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        super.setView(request, TEAMS_MAINT_VIEW);

        try {

            String action = super.getValue(request, "action");
            int id = super.getInteger(request, "hdnTeamId");

            //Declare team variable
            Team t = new Team();
            switch (action.toLowerCase()) {
                case "create":
                    loadTeamProperties(request, t);
                    request.setAttribute("createdTeam", teamService.saveTeam(t));
                    break;
                case "save":

                    break;
                case "delete":
                    int deleteid = super.getInteger(request, "id");

                    if (teamService.deleteTeam(deleteid) > 0) {
                        super.setView(request, TEAMS_VIEW);
                    }
                    break;
                case "onCall":
                    if(teamService.setTeamOnCall(id) == 0){
                        request.setAttribute("error", new ErrorViewModel("There is team on call already"));
                    }
                    break;
            }
        } catch (Exception e) {
            super.setView(request, TEAMS_MAINT_VIEW);
            request.setAttribute("error", new ErrorViewModel("An error occurred attempting to maintain teams"));
            //View doesn't have populated ddls
        }

        super.getView().forward(request, response);
    }

    @Override
    public String getServletInfo() {
        return "Short description";
    }

    private void loadTeamProperties(HttpServletRequest request, Team team) {
        team.setName(super.getValue(request, "teamName"));
        team.setIsOnCall(Boolean.parseBoolean(super.getValue(request, "teamIsOnCall"))); //Not working rn no checkbox on page

        IEmployee memberOne = new Employee();
        memberOne.setId(super.getInteger(request, "memberOne"));

        IEmployee memberTwo = new Employee();
        memberTwo.setId(super.getInteger(request, "memberTwo"));

        List<IEmployee> teamMembers = new ArrayList();
        teamMembers.add(memberOne);
        teamMembers.add(memberTwo);

        team.setTeamMbers(teamMembers);

    }

}
